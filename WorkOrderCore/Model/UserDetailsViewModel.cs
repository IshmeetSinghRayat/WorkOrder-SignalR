using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOrderCore.Model
{
    public class UserDetailsViewModel
    {
        public int EmployeeId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Firstname { get; set; }

        public string LastName { get; set; }

        public short EmployeeType { get; set; }
        public string NationalityId { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string JobDescription { get; set; }
        public int? PersonStatus { get; set; }

    }
}
