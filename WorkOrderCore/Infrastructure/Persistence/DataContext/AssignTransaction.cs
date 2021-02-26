using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class AssignTransaction
    {
        public short TransactionId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
