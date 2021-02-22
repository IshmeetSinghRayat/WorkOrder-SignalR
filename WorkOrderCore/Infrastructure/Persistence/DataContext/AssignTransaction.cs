using System;
using System.Collections.Generic;

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class AssignTransaction
    {
        public short TransactionId { get; set; }
        public int? EmployeeId { get; set; }

        public Employee Employee { get; set; }
        public JobCardsTranasctions Transaction { get; set; }
    }
}
