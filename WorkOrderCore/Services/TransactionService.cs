using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrderCore.Infrastructure.Helpers;
using WorkOrderCore.Infrastructure.Persistence.DataContext;
using WorkOrderCore.Model;

namespace WorkOrderCore.Services
{
    public interface ITransactionService
    {
        Task<List<JobcardTransactionsViewModel>> GetAllTransactions();
        Task<List<JobcardTransactionsViewModel>> GetEmployeeTransactions();
        Task<JobCardsTranasctions> GetTransactionByTransactionId(short Id);
        Task<JobCardsTranasctions> AddTransaction(JobCardsTranasctions model);
        Task<bool> UpdateTransaction(RiderChangeStatusViewModel model);
        Task<bool> CheckDuplicatePrioritySequence(int jobCardId, short prioritySequence);
        Task<JobCardsTranasctions> EditTransaction(JobCardsTranasctions model);
        Task<List<AssignTransaction>> AssignedTransactionsByEmployeeId();

    }
    public class TransactionService : BaseService, ITransactionService
    {
        public TransactionService(WorkOrderDBContext context, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
        }

        public async Task<List<JobcardTransactionsViewModel>> GetAllTransactions()
        {
            var transactions = await (from a in _context.JobCardsTranasctions
                                      join d in _context.JobActivities on a.JobActivityId equals d.Id
                                      join b in _context.Employee on a.EmployeeId equals b.Id
                                      join c in _context.AspNetUsers on b.UserId equals c.Id
                                      select new JobcardTransactionsViewModel
                                      {
                                          Id = a.Id,
                                          JobCardId = a.JobCardId,
                                          JobActivityId = a.JobActivityId,
                                          EmployeeId = a.EmployeeId,
                                          ActivityName = d.JobActivityDescriptioin,
                                          EmployeeFullName = c.Firstname + " " + c.LastName,
                                          JobCardsTranasctionsStartDate = a.JobCardsTranasctionsStartDate,
                                          JobCardsTranasctionsEndDate = a.JobCardsTranasctionsEndDate,
                                          JobCardsTranasctionsStatus = a.JobCardsTranasctionsStatus,
                                          JobCardsTranasctionsRemarks = a.JobCardsTranasctionsRemarks,
                                          JobCardsTranasctionsClosedAt = a.JobCardsTranasctionsClosedAt,
                                          PrioritySequence = a.PrioritySequence,
                                          CreatedBy = a.CreatedBy,
                                          UpdatedBy = a.UpdatedBy,
                                          CreatedDate = a.CreatedDate,
                                          UpdatedDate = a.UpdatedDate,
                                      }).ToListAsync();


            return transactions;
        }
        public async Task<List<JobcardTransactionsViewModel>> GetEmployeeTransactions()
        {
            var transactions = await GetAllTransactions();
            var GetAssignedTransactions = await _context.AssignTransaction.Where(s => s.EmployeeId == Convert.ToInt64(EmployeeId)).Select(t => t.TransactionId).ToListAsync();
            return transactions.Where(v => GetAssignedTransactions.Contains(v.Id)).ToList();
        }
        public async Task<JobCardsTranasctions> GetTransactionByTransactionId(short Id)
        {
            var transactionDetails = await _context.JobCardsTranasctions.Where(d => d.Id == Id).FirstOrDefaultAsync();
            return transactionDetails;
        }

        public async Task<JobCardsTranasctions> AddTransaction(JobCardsTranasctions model)
        {
            try
            {
                short lastPriorityNumber = 0;
                var jobPriority = await GetTransactionPriority(model.JobCardId);
                if (jobPriority != null)
                {
                    lastPriorityNumber = (short)(jobPriority.PrioritySequence.Value + 1);
                }
                else
                {
                    lastPriorityNumber = 1;
                }
                model.CreatedDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                model.CreatedBy = LoginUserid;
                model.PrioritySequence = lastPriorityNumber;
                _context.JobCardsTranasctions.Add(model);
                _context.SaveChanges();

                if (model.PrioritySequence == 1)
                {
                    AssignTransaction details = new AssignTransaction
                    {
                        TransactionId = model.Id,
                        EmployeeId = model.EmployeeId
                    };
                    _context.AssignTransaction.Add(details);
                    _context.SaveChanges();
                }
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private async Task<JobCardsTranasctions> GetTransactionPriority(int jobCardId)
        {
             return await _context.JobCardsTranasctions.Where(c => c.JobCardId == jobCardId).OrderByDescending(c => c.CreatedDate).FirstOrDefaultAsync();
        }

        public async Task<JobCardsTranasctions> EditTransaction(JobCardsTranasctions model)
        {
            try
            {
                model.UpdatedBy = LoginUserid;
                model.UpdatedDate = DateTime.Now;
                model.CreatedBy = LoginUserid;
                _context.JobCardsTranasctions.Update(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> UpdateTransaction(RiderChangeStatusViewModel model)
        {
            JobCardsTranasctions result = await _context.JobCardsTranasctions.Where(v => v.Id == model.Id).FirstOrDefaultAsync();
            result.JobCardsTranasctionsStatus = model.JobCardsTranasctionsStatus;
            result.JobCardsTranasctionsClosedAt = DateTime.Now;
            result.UpdatedBy = LoginUserid;
            result.UpdatedDate = DateTime.Now;
            _context.JobCardsTranasctions.Update(result);
            await _context.SaveChangesAsync();
            if (result.JobCardsTranasctionsStatus == "Close")
            {
                AssignTransaction removeDetails = new AssignTransaction
                {
                    TransactionId = result.Id,
                    EmployeeId = result.EmployeeId
                };
                _context.AssignTransaction.Remove(removeDetails);
                await _context.SaveChangesAsync();

                var getNextEmployee = await _context.JobCardsTranasctions.Where(c => c.JobCardId == result.JobCardId && c.PrioritySequence == result.PrioritySequence + 1).FirstOrDefaultAsync();
                if (getNextEmployee != null)
                {
                    AssignTransaction details = new AssignTransaction
                    {
                        TransactionId = result.Id,
                        EmployeeId = getNextEmployee.EmployeeId
                    };
                    _context.AssignTransaction.Add(details);
                    await _context.SaveChangesAsync();
                }
            }
            return true;
        }

        public async Task<List<AssignTransaction>> AssignedTransactionsByEmployeeId()
        {
            return await _context.AssignTransaction.Where(c => c.EmployeeId == Convert.ToInt16(EmployeeId)).ToListAsync();
        }

        public async Task<bool> CheckDuplicatePrioritySequence(int jobCardId, short prioritySequence)
        {
            return await _context.JobCardsTranasctions.Where(c => c.JobCardId == jobCardId && c.PrioritySequence == prioritySequence).AnyAsync();
        }
    }
}
