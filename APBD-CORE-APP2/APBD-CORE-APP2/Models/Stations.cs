using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Stations
    {
        public Stations()
        {
            Multicomponents = new HashSet<Multicomponents>();
            Multisoftware = new HashSet<Multisoftware>();
            StationUsed = new HashSet<StationUsed>();
        }

        public int StationId { get; set; }
        public int Nr { get; set; }

        public ICollection<Multicomponents> Multicomponents { get; set; }
        public ICollection<Multisoftware> Multisoftware { get; set; }
        public ICollection<StationUsed> StationUsed { get; set; }
    }
}
