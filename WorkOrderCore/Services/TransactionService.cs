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
        Task<JobCardsTransactions> GetTransactionByTransactionId(short Id);
        Task<JobCardsTransactions> AddTransaction(JobCardsTransactions model);
        Task<bool> UpdateTransaction(RiderChangeStatusViewModel model);
        Task<bool> CheckDuplicatePrioritySequence(int jobCardId, short prioritySequence);
        Task<JobCardsTransactions> EditTransaction(JobCardsTransactions model);
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
            var transactions = await (from a in _context.JobCardsTransactions
                                      join d in _context.JobActivities on a.JobActivityId equals d.Id
                                      join e in _context.JobCards on a.JobCardId equals e.Id
                                      join b in _context.Employee on a.EmployeeId equals b.Id
                                      join c in _context.AspNetUsers on b.UserId equals c.Id
                                      select new JobcardTransactionsViewModel
                                      {
                                          Id = a.Id,
                                          JobCardId = a.JobCardId,
                                          JobNumber = e.JobNumber,
                                          JobActivityId = a.JobActivityId,
                                          EmployeeId = a.EmployeeId,
                                          ActivityName = d.JobActivityDescriptioin,
                                          EmployeeFullName = c.Firstname + " " + c.LastName,
                                          JobCardsTransactionsStartDate = a.JobCardsTransactionsStartDate,
                                          JobCardsTransactionsEndDate = a.JobCardsTransactionsEndDate,
                                          JobCardsTransactionsStatus = a.JobCardsTransactionsStatus,
                                          JobCardsTransactionsRemarks = a.JobCardsTransactionsRemarks,
                                          JobCardsTransactionsClosedAt = a.JobCardsTransactionsClosedAt,
                                          PrioritySequence = a.PrioritySequence,
                                          CreatedBy = a.CreatedBy,
                                          UpdatedBy = a.UpdatedBy,
                                          CreatedDate = a.CreatedDate,
                                          UpdatedDate = a.UpdatedDate,
                                      }).OrderByDescending(x => x.CreatedDate).ToListAsync();


            return transactions;
        }
        public async Task<List<JobcardTransactionsViewModel>> GetEmployeeTransactions()
        {
            var transactions = await GetAllTransactions();
            var GetAssignedTransactions = await _context.AssignTransaction.Where(s => s.EmployeeId == Convert.ToInt64(EmployeeId)).Select(t => t.TransactionId).ToListAsync();
            var employeeTransactions = transactions.Where(v => v.EmployeeId == Convert.ToInt16(EmployeeId)).ToList();
            for (int i = 0; i < employeeTransactions.Count; i++)
            {
                if (employeeTransactions[i].JobCardsTransactionsStatus == "Open" || employeeTransactions[i].JobCardsTransactionsStatus == "Hold")
                {
                    if (GetAssignedTransactions.Contains(employeeTransactions[i].Id))
                    {
                        employeeTransactions[i].EmployeeTransactionStatus = "Active";
                    }
                    else
                    {
                        employeeTransactions[i].EmployeeTransactionStatus = "NotActive";
                    }
                }
                else
                {
                    employeeTransactions[i].EmployeeTransactionStatus = "Finished";
                }

            }
            return employeeTransactions.OrderBy(c=>c.PrioritySequence).ToList();
        }
        public async Task<JobCardsTransactions> GetTransactionByTransactionId(short Id)
        {
            var transactionDetails = await _context.JobCardsTransactions.Where(d => d.Id == Id).FirstOrDefaultAsync();
            return transactionDetails;
        }

        public async Task<JobCardsTransactions> AddTransaction(JobCardsTransactions model)
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
                _context.JobCardsTransactions.Add(model);
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

        private async Task<JobCardsTransactions> GetTransactionPriority(int jobCardId)
        {
             return await _context.JobCardsTransactions.Where(c => c.JobCardId == jobCardId).OrderByDescending(c => c.CreatedDate).FirstOrDefaultAsync();
        }

        public async Task<JobCardsTransactions> EditTransaction(JobCardsTransactions model)
        {
            try
            {
                model.UpdatedBy = LoginUserid;
                model.UpdatedDate = DateTime.Now;
                model.CreatedBy = LoginUserid;
                _context.JobCardsTransactions.Update(model);
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
            JobCardsTransactions result = await _context.JobCardsTransactions.Where(v => v.Id == model.Id).FirstOrDefaultAsync();
            result.JobCardsTransactionsStatus = model.JobCardsTransactionsStatus;
            result.JobCardsTransactionsClosedAt = DateTime.Now;
            result.UpdatedBy = LoginUserid;
            result.UpdatedDate = DateTime.Now;
            _context.JobCardsTransactions.Update(result);
            await _context.SaveChangesAsync();
            if (result.JobCardsTransactionsStatus == "Close")
            {
                AssignTransaction removeDetails = new AssignTransaction
                {
                    TransactionId = result.Id,
                    EmployeeId = result.EmployeeId
                };
                _context.AssignTransaction.Remove(removeDetails);
                await _context.SaveChangesAsync();

                var getNextEmployee = await _context.JobCardsTransactions.AsNoTracking().Where(c => c.JobCardId == result.JobCardId && c.PrioritySequence == result.PrioritySequence + 1).FirstOrDefaultAsync();
                if (getNextEmployee != null)
                {
                    AssignTransaction details = new AssignTransaction
                    {
                        TransactionId = getNextEmployee.Id,
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
            return await _context.JobCardsTransactions.AsNoTracking().Where(c => c.JobCardId == jobCardId && c.PrioritySequence == prioritySequence).AnyAsync();
        }
    }
}
