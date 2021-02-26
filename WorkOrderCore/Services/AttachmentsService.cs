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
        Task<List<JobCardsTransactionsLobs>> GetAttachmentsByTransactionId(short TransactionId);
        Task<JobCardsTransactionsLobs> GetAttachmentById(short Id);
        Task<bool> PostAttachments(List<JobCardsTransactionsLobs> model);
    }
    public class AttachmentsService : BaseService, IAttachmentsService
    {
        public AttachmentsService(WorkOrderDBContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor)
        {
        }

        public async Task<JobCardsTransactionsLobs> GetAttachmentById(short Id)
        {
            return await _context.JobCardsTransactionsLobs.Where(c => c.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<JobCardsTransactionsLobs>> GetAttachmentsByTransactionId(short TransactionId)
        {
            return await _context.JobCardsTransactionsLobs.Where(c => c.JobCardsTransactionsId == TransactionId).ToListAsync();
        }

        public async Task<bool> PostAttachments(List<JobCardsTransactionsLobs> model)
        {
            if (model.Count > 0)
            {
                _context.JobCardsTransactionsLobs.AddRange(model);
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
