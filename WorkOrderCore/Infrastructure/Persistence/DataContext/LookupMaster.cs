using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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

        public virtual ICollection<Lookups> Lookups { get; set; }
    }
}
