using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class EmployeeOccupancy
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public short? AssignedActivities { get; set; }
        public DateTime? LastAssignedDate { get; set; }
        public short? CompletedActivities { get; set; }
        public DateTime? LastCompletedDate { get; set; }
        public short? CancelActivites { get; set; }
        public DateTime? LastCancelDate { get; set; }
        public short? OverDueActivities { get; set; }

        public virtual Employee Person { get; set; }
    }
}
