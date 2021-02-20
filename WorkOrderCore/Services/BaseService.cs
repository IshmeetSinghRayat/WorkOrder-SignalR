using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using WorkOrderCore.Infrastructure.Persistence.DataContext;

namespace WorkOrderCore.Services
{
    public class BaseService
    {
        public readonly WorkOrderDBContext _context;
        public readonly string LoginUserid;
        public readonly string EmployeeId; 
        private readonly IHttpContextAccessor _httpContextAccessor;


        public BaseService(WorkOrderDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            LoginUserid = _httpContextAccessor.HttpContext.Session.GetString("LoginUserid");
            EmployeeId = _httpContextAccessor.HttpContext.Session.GetString("EmployeeId");
        }
    }
}
