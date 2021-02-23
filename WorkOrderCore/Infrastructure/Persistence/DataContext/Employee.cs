using System;
using System.Collections.Generic;

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeOccupancy = new HashSet<EmployeeOccupancy>();
            JobCardsTranasctions = new HashSet<JobCardsTranasctions>();
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

        public ICollection<EmployeeOccupancy> EmployeeOccupancy { get; set; }
        public ICollection<JobCardsTranasctions> JobCardsTranasctions { get; set; }
    }
}
