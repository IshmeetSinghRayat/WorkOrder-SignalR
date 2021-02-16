using System;
using System.Collections.Generic;

namespace WorkOrderCore.Persistence.DataContext
{
    public partial class JobCards
    {
        public JobCards()
        {
            JobActivities = new HashSet<JobActivities>();
            JobCardsTranasctions = new HashSet<JobCardsTranasctions>();
        }

        public int Id { get; set; }
        public short? BuninessUnitId { get; set; }
        public string JobDescription { get; set; }
        public short? JobDuration { get; set; }
        public string JobStatus { get; set; }
        public string JobCardsRemarks { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public BusinessUnit BuninessUnit { get; set; }
        public ICollection<JobActivities> JobActivities { get; set; }
        public ICollection<JobCardsTranasctions> JobCardsTranasctions { get; set; }
    }
}
