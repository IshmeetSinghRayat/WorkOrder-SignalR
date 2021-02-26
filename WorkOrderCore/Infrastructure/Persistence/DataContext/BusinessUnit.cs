using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class BusinessUnit
    {
        public BusinessUnit()
        {
            JobActivities = new HashSet<JobActivities>();
            JobCards = new HashSet<JobCards>();
        }

        public int Id { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }

        public virtual ICollection<JobActivities> JobActivities { get; set; }
        public virtual ICollection<JobCards> JobCards { get; set; }
    }
}
