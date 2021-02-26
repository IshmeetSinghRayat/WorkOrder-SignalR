using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeOccupancy = new HashSet<EmployeeOccupancy>();
            JobCardsTransactions = new HashSet<JobCardsTransactions>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public short EmployeeType { get; set; }
        public string NationalityId { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string JobDescription { get; set; }
        public int? PersonStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<EmployeeOccupancy> EmployeeOccupancy { get; set; }
        public virtual ICollection<JobCardsTransactions> JobCardsTransactions { get; set; }
    }
}
