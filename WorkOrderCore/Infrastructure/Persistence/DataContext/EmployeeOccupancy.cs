using System;
using System.Collections.Generic;

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

        public Employee Person { get; set; }
    }
}
