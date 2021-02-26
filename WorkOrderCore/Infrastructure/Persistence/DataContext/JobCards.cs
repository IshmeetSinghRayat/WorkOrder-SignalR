using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class JobCards
    {
        public JobCards()
        {
            JobCardsTransactions = new HashSet<JobCardsTransactions>();
        }

        public int Id { get; set; }
        public string JobNumber { get; set; }
        public int? BuninessUnitId { get; set; }
        public string JobDescription { get; set; }
        public short? JobDuration { get; set; }
        public string JobStatus { get; set; }
        public string JobCardsRemarks { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual BusinessUnit BuninessUnit { get; set; }
        public virtual ICollection<JobCardsTransactions> JobCardsTransactions { get; set; }
    }
}
