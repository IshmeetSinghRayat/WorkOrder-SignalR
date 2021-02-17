using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrderCore.Infrastructure.Persistence.DataContext;

namespace WorkOrderApplication.Models
{
    public class CreateJobCardViewModel
    {
        public JobCards JobCardDetails { get; set; }
        public List<SelectListItem> BusinessUnitsDD { get; set; }
        public List<SelectListItem> StatusDD { get; set; }
        public List<SelectListItem> DurationDD { get; set; }
    }
}
