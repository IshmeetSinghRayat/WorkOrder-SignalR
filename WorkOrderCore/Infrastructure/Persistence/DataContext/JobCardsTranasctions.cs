using System;
using System.Collections.Generic;

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class JobCardsTranasctions
    {
        public JobCardsTranasctions()
        {
            JobCardsTranasctionsLobs = new HashSet<JobCardsTranasctionsLobs>();
        }

        public short Id { get; set; }
        public int JobCardId { get; set; }
        public int JobActivityId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime JobCardsTranasctionsStartDate { get; set; }
        public DateTime JobCardsTranasctionsEndDate { get; set; }
        public string JobCardsTranasctionsStatus { get; set; }
        public string JobCardsTranasctionsRemarks { get; set; }
        public DateTime? JobCardsTranasctionsClosedAt { get; set; }
        public short? PrioritySequence { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Employee Employee { get; set; }
        public JobActivities JobActivity { get; set; }
        public JobCards JobCard { get; set; }
        public ICollection<JobCardsTranasctionsLobs> JobCardsTranasctionsLobs { get; set; }
    }
}
