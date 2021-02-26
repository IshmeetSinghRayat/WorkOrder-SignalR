using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class Lookups
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string MasterName { get; set; }
        public bool? IsActive { get; set; }

        public virtual LookupMaster MasterNameNavigation { get; set; }
    }
}
