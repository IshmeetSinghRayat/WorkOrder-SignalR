using System;
using System.Collections.Generic;

namespace WorkOrderCore.Persistence.DataContext
{
    public partial class JobCardsTranasctions
    {
        public short JobCardsTranasctionsId { get; set; }
        public int JobCardId { get; set; }
        public int JobActivityId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime JobCardsTranasctionsStart { get; set; }
        public DateTime JobCardsTranasctionsEnd { get; set; }
        public string JobCardsTranasctionsStatus { get; set; }
        public string JobCardsTranasctionsRemarks { get; set; }
        public DateTime? JobCardsTranasctionsClosedAt { get; set; }

        public Employee Employee { get; set; }
        public JobActivities JobActivity { get; set; }
        public JobCards JobCard { get; set; }
    }
}
