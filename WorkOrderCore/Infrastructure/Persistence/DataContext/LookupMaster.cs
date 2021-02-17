using System;
using System.Collections.Generic;

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class LookupMaster
    {
        public LookupMaster()
        {
            Lookups = new HashSet<Lookups>();
        }

        public string Alias { get; set; }
        public string Name { get; set; }

        public ICollection<Lookups> Lookups { get; set; }
    }
}
