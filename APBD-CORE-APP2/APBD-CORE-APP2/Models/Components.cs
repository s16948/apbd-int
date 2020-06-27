using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Components
    {
        public Components()
        {
            Multicomponents = new HashSet<Multicomponents>();
        }

        public int ComponentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public ICollection<Multicomponents> Multicomponents { get; set; }
    }
}
