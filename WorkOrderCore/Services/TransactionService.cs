using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrderCore.Infrastructure.Persistence.DataContext;

namespace WorkOrderCore.Services
{
    public interface ITransactionService
    {
        Task<List<JobCardsTranasctions>> GetAllTransactions();
        Task<List<JobCardsTranasctions>> GetEmployeeTransactions();

        Task<JobCardsTranasctions> AddTransaction(JobCardsTranasctions model);
        Task<bool> UpdateAssignment(JobCardsTranasctions model);

    }
    public class TransactionService : BaseService, ITransactionService
    {
        public TransactionService(WorkOrderDBContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor)
        {
        }

        public async Task<List<JobCardsTranasctions>> GetAllTransactions()
        {
            var assignedActivities = await _context.JobCardsTranasctions.ToListAsync();
            return assignedActivities.ToList();
        }
        public async Task<List<JobCardsTranasctions>> GetEmployeeTransactions()
        {
            var transactions = await _context.JobCardsTranasctions.ToListAsync();
            return transactions.Where(v=>v.EmployeeId == Convert.ToInt64(EmployeeId)).ToList();
        }

        public async Task<JobCardsTranasctions> AddTransaction(JobCardsTranasctions model)
        {
            try
            {
                model.CreatedDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                model.CreatedBy = Userid;
                _context.JobCardsTranasctions.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public async Task<bool> UpdateAssignment(JobCardsTranasctions model)
        {
            //model.UpdatedBy = "19ef8691-ba36-45e6-8fc9-4ac0e84a7249";
            _context.JobCardsTranasctions.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
