using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class JobCardsTransactions
    {
        public JobCardsTransactions()
        {
            JobCardsTransactionsLobs = new HashSet<JobCardsTransactionsLobs>();
        }

        public short Id { get; set; }
        public int JobCardId { get; set; }
        public int JobActivityId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime JobCardsTransactionsStartDate { get; set; }
        public DateTime JobCardsTransactionsEndDate { get; set; }
        public string JobCardsTransactionsStatus { get; set; }
        public string JobCardsTransactionsRemarks { get; set; }
        public DateTime? JobCardsTransactionsClosedAt { get; set; }
        public short? PrioritySequence { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual JobActivities JobActivity { get; set; }
        public virtual JobCards JobCard { get; set; }
        public virtual ICollection<JobCardsTransactionsLobs> JobCardsTransactionsLobs { get; set; }
    }
}
