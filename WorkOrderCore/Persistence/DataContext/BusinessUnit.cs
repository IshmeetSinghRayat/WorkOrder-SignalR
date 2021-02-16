using System;
using System.Collections.Generic;

namespace WorkOrderCore.Persistence.DataContext
{
    public partial class BusinessUnit
    {
        public BusinessUnit()
        {
            JobCards = new HashSet<JobCards>();
        }

        public short BusinessUnitId { get; set; }
        public string BusinessUniteDesc { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }

        public ICollection<JobCards> JobCards { get; set; }
    }
}
