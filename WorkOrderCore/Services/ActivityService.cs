using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrderCore.Infrastructure.Persistence.DataContext;

namespace WorkOrderCore.Services
{
    public interface IActivityService
    {
        Task<List<JobActivities>> GetAllActivities();
        Task<List<JobActivities>> GetJobActivities(int jobCardId);

        Task<JobActivities> AddActivity(JobActivities model);
        Task<bool> UpdateActivity(JobActivities model);

    }
    public class ActivityService : IActivityService
    {
        private readonly WorkOrderDBContext _context;

        public ActivityService(WorkOrderDBContext Context)
        {
            _context = Context;
        }
        public async Task<List<JobActivities>> GetAllActivities()
        {
            var activities = await _context.JobActivities.ToListAsync();
            return activities.ToList();
        }
        public async Task<List<JobActivities>> GetJobActivities(int jobCardId)
        {
            var activities = await _context.JobActivities.ToListAsync();
            return activities.ToList();
        }

        public async Task<JobActivities> AddActivity(JobActivities model)
        {
            try
            {
                model.CreatedDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                model.CreatedBy = "19ef8691-ba36-45e6-8fc9-4ac0e84a7249";
                _context.JobActivities.Add(model);
                _context.SaveChanges();
                return model;
            }
            catch (Exception es)
            {
                throw;
            }
           
        }

        public async Task<bool> UpdateActivity(JobActivities model)
        {
            //model.UpdatedBy = "19ef8691-ba36-45e6-8fc9-4ac0e84a7249";
            _context.JobActivities.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
