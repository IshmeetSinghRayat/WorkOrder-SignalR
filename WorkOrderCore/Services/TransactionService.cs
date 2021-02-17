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
        Task<List<JobCardsTranasctions>> GetAllAssignedActivities();
        Task<List<JobCardsTranasctions>> GetAssignActivity(int jobCardId);

        Task<JobCardsTranasctions> AssignActivity(JobCardsTranasctions model);
        Task<bool> UpdateAssignment(JobCardsTranasctions model);

    }
    public class TransactionService : ITransactionService
    {
        private readonly WorkOrderDBContext _context;

        public TransactionService(WorkOrderDBContext Context)
        {
            _context = Context;
        }
        public async Task<List<JobCardsTranasctions>> GetAllAssignedActivities()
        {
            var assignedActivities = await _context.JobCardsTranasctions.ToListAsync();
            return assignedActivities.ToList();
        }
        public async Task<List<JobCardsTranasctions>> GetAssignActivity(int jobCardId)
        {
            var activities = await _context.JobCardsTranasctions.ToListAsync();
            return activities.Where(v=>v.JobCardId == jobCardId).ToList();
        }

        public async Task<JobCardsTranasctions> AssignActivity(JobCardsTranasctions model)
        {
            try
            {
                //model.CreationDate = DateTime.Now;
                //model.UpdatedDate = DateTime.Now;
                //model.CreatedBy = "19ef8691-ba36-45e6-8fc9-4ac0e84a7249";
                _context.JobCardsTranasctions.Add(model);
                _context.SaveChanges();


                return model;
            }
            catch (Exception es)
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
