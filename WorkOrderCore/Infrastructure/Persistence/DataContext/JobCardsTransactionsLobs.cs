using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class JobCardsTransactionsLobs
    {
        public short Id { get; set; }
        public short JobCardsTransactionsId { get; set; }
        public byte[] Lobdata { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DocumentDescription { get; set; }

        public virtual JobCardsTransactions JobCardsTransactions { get; set; }
    }
}
