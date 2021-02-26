using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class JobActivities
    {
        public JobActivities()
        {
            JobCardsTransactions = new HashSet<JobCardsTransactions>();
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

        public virtual BusinessUnit BuninessUnit { get; set; }
        public virtual ICollection<JobCardsTransactions> JobCardsTransactions { get; set; }
    }
}
