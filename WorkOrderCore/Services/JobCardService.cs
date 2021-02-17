using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOrderCore.Infrastructure.Persistence.DataContext;

namespace WorkOrderCore.Services
{
    public interface IJobCardService
    {
        Task<List<JobCards>> GetAllJobCards();
        Task<bool> AddJobCard(JobCards model);
        Task<bool> UpdateJobCard(JobCards model);

    }
    public class JobCardService :BaseService, IJobCardService
    {
        public JobCardService(WorkOrderDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task<List<JobCards>> GetAllJobCards()
        {
            return await _context.JobCards.ToListAsync();
        }

        public async Task<bool> AddJobCard(JobCards model)
        {
            try
            {
                model.CreationDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                model.CreatedBy = "19ef8691-ba36-45e6-8fc9-4ac0e84a7249";
                _context.JobCards.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception es)
            {

                throw;
            }
           
        }

        public async Task<bool> UpdateJobCard(JobCards model)
        {
            model.UpdatedBy = Userid;
            _context.JobCards.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
