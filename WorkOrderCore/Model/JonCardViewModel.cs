using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOrderCore.Model
{
    public class JonCardViewModel
    {
        public int Id { get; set; }
        public int? BuninessUnitId { get; set; }
        public string BuninessUnitName { get; set; }
        public string JobDescription { get; set; }
        public short? JobDuration { get; set; }
        public string JobStatus { get; set; }
        public string JobCardsRemarks { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
