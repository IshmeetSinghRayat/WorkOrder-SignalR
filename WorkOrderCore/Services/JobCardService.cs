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
    public interface IJobCardService
    {
        Task<List<JobCards>> GetAllJobCards();
        Task<JobCards> GetJobCardsById(int id);
        Task<bool> AddJobCard(JobCards model);
        Task<bool> UpdateJobCard(JobCards model);
        Task<bool> CheckDuplicateJobNumber(string number);

    }
    public class JobCardService :BaseService, IJobCardService
    {
        public JobCardService(WorkOrderDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task<List<JobCards>> GetAllJobCards()
        {
            return await _context.JobCards.OrderByDescending(x=>x.CreationDate).Include(c=>c.BuninessUnit).ToListAsync();
        }

        public async Task<bool> AddJobCard(JobCards model)
        {
            try
            {
                model.CreationDate = DateTime.Now;
                model.UpdatedDate = DateTime.Now;
                model.CreatedBy = LoginUserid;
                model.JobNumber = model.JobNumber + "-" + DateTime.Now.ToString("yy");
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
            model.UpdatedDate = DateTime.Now;
            model.UpdatedBy = LoginUserid;
            _context.JobCards.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<JobCards> GetJobCardsById(int id)
        {
            return await _context.JobCards.Where(c=>c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> CheckDuplicateJobNumber(string number)
        {
            string jobNumber = number + "-" + DateTime.Now.ToString("yy");
            return await _context.JobCards.Where(v => v.JobNumber == jobNumber).AnyAsync();
        }
    }
}
