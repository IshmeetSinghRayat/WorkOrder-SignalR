using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkOrderCore.Persistence.DataContext;

namespace WorkOrderCore.Services
{
    public interface ILookupService
    {
        Task<List<BusinessUnit>> GetBusinessUnits();
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
    }
}
