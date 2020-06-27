using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Multicomponents
    {
        public int ComponentsComponentId { get; set; }
        public int StationsStationId { get; set; }

        public Components ComponentsComponent { get; set; }
        public Stations StationsStation { get; set; }
    }
}
