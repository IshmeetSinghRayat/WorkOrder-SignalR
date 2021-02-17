using System;
using System.Collections.Generic;

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

        public ICollection<JobActivities> JobActivities { get; set; }
        public ICollection<JobCards> JobCards { get; set; }
    }
}
