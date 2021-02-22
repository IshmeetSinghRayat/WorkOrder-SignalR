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
    public interface IAttachmentsService
    {
        Task<List<JobCardsTranasctionsLobs>> GetAttachmentsByTransactionId(short TransactionId);
        Task<JobCardsTranasctionsLobs> GetAttachmentById(short Id);
        Task<bool> PostAttachments(List<JobCardsTranasctionsLobs> model);
    }
    public class AttachmentsService : BaseService, IAttachmentsService
    {
        public AttachmentsService(WorkOrderDBContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor)
        {
        }

        public async Task<JobCardsTranasctionsLobs> GetAttachmentById(short Id)
        {
            return await _context.JobCardsTranasctionsLobs.Where(c => c.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<JobCardsTranasctionsLobs>> GetAttachmentsByTransactionId(short TransactionId)
        {
            return await _context.JobCardsTranasctionsLobs.Where(c => c.JobCardsTranasctionsId == TransactionId).ToListAsync();
        }

        public async Task<bool> PostAttachments(List<JobCardsTranasctionsLobs> model)
        {
            if (model.Count > 0)
            {
                _context.JobCardsTranasctionsLobs.AddRange(model);
                await _context.SaveChangesAsync();

                if (model[0].Id != 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
