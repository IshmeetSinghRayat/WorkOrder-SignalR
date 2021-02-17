using System;
using System.Collections.Generic;

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class Lookups
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string MasterName { get; set; }

        public LookupMaster MasterNameNavigation { get; set; }
    }
}
