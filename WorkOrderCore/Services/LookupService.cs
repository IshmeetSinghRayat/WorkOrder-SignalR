using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrderCore.Infrastructure.Helpers;
using WorkOrderCore.Infrastructure.Persistence.DataContext;
using static WorkOrderCore.Infrastructure.Helpers.DataEnums;

namespace WorkOrderCore.Services
{
    public interface ILookupService
    {
        Task<List<BusinessUnit>> GetBusinessUnits();
        Task<List<Lookups>> GetLookups(string MasterLookupName);

    }
    public class LookupService :BaseService, ILookupService
    {
        public LookupService(WorkOrderDBContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor)
        {
        }

        public async Task<List<BusinessUnit>> GetBusinessUnits()
        {
            return await _context.BusinessUnit.ToListAsync();
        }

        public async Task<List<Lookups>> GetLookups(string MasterLookupName)
        {
            return await _context.Lookups.Where(c => c.MasterName == MasterLookupName).ToListAsync();
        }
    }
}
