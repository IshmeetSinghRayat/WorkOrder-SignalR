using System;
using System.Collections.Generic;

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class JobCardsTranasctionsLobs
    {
        public short Id { get; set; }
        public short JobCardsTranasctionsId { get; set; }
        public byte[] Lobdata { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DocumentDescription { get; set; }

        public JobCardsTranasctions JobCardsTranasctions { get; set; }
    }
}
