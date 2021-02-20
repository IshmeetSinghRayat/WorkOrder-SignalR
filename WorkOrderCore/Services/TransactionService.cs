using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrderCore.Infrastructure.Persistence.DataContext;
using WorkOrderCore.Model;

namespace WorkOrderCore.Services
{
    public interface ITransactionService
    {
        Task<List<JobCardsTranasctions>> GetAllTransactions();
        Task<List<JobCardsTranasctions>> GetEmployeeTransactions();
        Task<JobCardsTranasctions> GetTransactionByTransactionId(short Id);
        Task<JobCardsTranasctions> AddTransaction(JobCardsTranasctions model);
        Task<bool> UpdateTransaction(RiderChangeStatusViewModel model);
    }
    public class TransactionService : BaseService, ITransactionService
    {
        public TransactionService(WorkOrderDBContext context, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
        }

        public async Task<List<JobCardsTranasctions>> GetAllTransactions()
        {
            var transactions = (from a in _context.JobCardsTranasctions
                                join b in _context.Employee on a.EmployeeId equals b.Id
                                join c in _context.AspNetUsers on b.UserId equals c.Id
                                select new JobcardTransactionsViewModel
                                {
                                    Id = a.Id,
                                    JobCardId = a.JobCardId,
                                    JobActivityId = a.JobActivityId,
                                    EmployeeId = a.EmployeeId,
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
                                });


            var assignedActivities = await _context.JobCardsTranasctions.ToListAsync();
            return assignedActivities.ToList();
        }
        public async Task<List<JobCardsTranasctions>> GetEmployeeTransactions()
        {
            var transactions = await _context.JobCardsTranasctions.ToListAsync();
            return transactions.Where(v => v.EmployeeId == Convert.ToInt64(EmployeeId)).ToList();
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
                model.CreatedDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                model.CreatedBy = LoginUserid;
                _context.JobCardsTranasctions.Add(model);
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
            result.UpdatedBy = LoginUserid;
            result.UpdatedDate = DateTime.Now;
            _context.JobCardsTranasctions.Update(result);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
