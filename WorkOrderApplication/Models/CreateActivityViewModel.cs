using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrderCore.Infrastructure.Persistence.DataContext;

namespace WorkOrderApplication.Models
{
    public class CreateActivityViewModel
    {
        public JobActivities JobActivitiesDetails { get; set; }
        public List<SelectListItem> BusinessUnitsList { get; set; }
    }
}
