using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrderCore.Persistence.DataContext;

namespace WorkOrderApplication.Models
{
    public class CreateJobCardViewModel
    {
        public JobCards JobCardDetails { get; set; }
        public List<SelectListItem> BusinessUnitsList { get; set; }
    }
}
