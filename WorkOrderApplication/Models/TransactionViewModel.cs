using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrderCore.Infrastructure.Persistence.DataContext;

namespace WorkOrderApplication.Models
{
    public class TransactionViewModel
    {
        public List<SelectListItem> JobcardDD { get; set; }
        public List<SelectListItem> JobActivityDD { get; set; }
        public List<SelectListItem> EmployeesDD { get; set; }
        public JobCardsTranasctions TransactionDetails { get; set; }
    }
}
