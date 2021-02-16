using System;
using System.Collections.Generic;

namespace WorkOrderCore.Persistence.DataContext
{
    public partial class JobActivities
    {
        public JobActivities()
        {
            JobCardsTranasctions = new HashSet<JobCardsTranasctions>();
        }

        public int Id { get; set; }
        public int? JobCardId { get; set; }
        public short? BuninessUnitId { get; set; }
        public string JobActivityDescriptioin { get; set; }
        public int? JobActivitiesStatus { get; set; }
        public short? MinDuration { get; set; }
        public short? MaxDuration { get; set; }

        public JobCards JobCard { get; set; }
        public ICollection<JobCardsTranasctions> JobCardsTranasctions { get; set; }
    }
}
