using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Software
    {
        public Software()
        {
            Multisoftware = new HashSet<Multisoftware>();
        }

        public int SoftId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SerialKey { get; set; }

        public ICollection<Multisoftware> Multisoftware { get; set; }
    }
}
