using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class StationUsed
    {
        public int StationsStationId { get; set; }
        public int SessionsSessionId { get; set; }

        public Sessions SessionsSession { get; set; }
        public Stations StationsStation { get; set; }
    }
}
