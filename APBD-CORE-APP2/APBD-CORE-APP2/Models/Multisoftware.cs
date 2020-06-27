using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Multisoftware
    {
        public int StationsStationId { get; set; }
        public int SoftwareSoftId { get; set; }

        public Software SoftwareSoft { get; set; }
        public Stations StationsStation { get; set; }
    }
}
