using System;
using System.Collections.Generic;

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class JobActivities
    {
        public JobActivities()
        {
            JobCardsTranasctions = new HashSet<JobCardsTranasctions>();
        }

        public int Id { get; set; }
        public int? BuninessUnitId { get; set; }
        public string JobActivityDescriptioin { get; set; }
        public string JobActivitiesStatus { get; set; }
        public short? MinDuration { get; set; }
        public short? MaxDuration { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public BusinessUnit BuninessUnit { get; set; }
        public ICollection<JobCardsTranasctions> JobCardsTranasctions { get; set; }
    }
}
