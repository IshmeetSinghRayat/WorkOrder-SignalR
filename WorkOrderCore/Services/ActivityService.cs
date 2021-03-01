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
    public interface IActivityService
    {
        Task<List<JobActivities>> GetAllActivities();
        Task<List<JobActivities>> GetJobActivities(int jobCardId);
        Task<List<JobActivities>> GetActivitiesByJobCardId(short jobCardId);
        Task<JobActivities> AddActivity(JobActivities model);
        Task<JobActivities> GetActivityById(int id);
        Task<bool> UpdateActivity(JobActivities model);

    }
    public class ActivityService : BaseService, IActivityService
    {
        public ActivityService(WorkOrderDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task<List<JobActivities>> GetAllActivities()
        {
            var activities = await _context.JobActivities.OrderByDescending(x => x.CreatedDate).Include(v=>v.BuninessUnit).ToListAsync();
            return activities.ToList();
        }
        public async Task<List<JobActivities>> GetActivitiesByJobCardId(short jobCardId)
        {
            var businessUnitOfJobCard = await _context.JobCards.Where(c=>c.Id == jobCardId).Select(c=>c.BuninessUnitId).FirstOrDefaultAsync();
            if (businessUnitOfJobCard != null || businessUnitOfJobCard != 0)
            {
                return await _context.JobActivities.Where(v => v.BuninessUnitId == businessUnitOfJobCard).ToListAsync();
            }
            return new List<JobActivities>();
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
                model.CreatedBy = LoginUserid;
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
            model.UpdatedDate = DateTime.Now;
            model.UpdatedBy = LoginUserid;
            _context.JobActivities.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<JobActivities> GetActivityById(int id)
        {
            return await _context.JobActivities.Where(d => d.Id == id).FirstOrDefaultAsync();
        }
    }
}
