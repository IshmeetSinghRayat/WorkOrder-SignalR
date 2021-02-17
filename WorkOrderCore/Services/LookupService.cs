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
    public class LookupService : ILookupService
    {
        private readonly WorkOrderDBContext _context;

        public LookupService(WorkOrderDBContext Context)
        {
            _context = Context;
        }
        public async Task<List<BusinessUnit>> GetBusinessUnits()
        {
            return await _context.BusinessUnit.ToListAsync();
        }

        public Task<List<Lookups>> GetLookups(string MasterLookupName)
        {
            return _context.Lookups.Where(c => c.MasterId == 1).ToListAsync();
        }
    }
}
