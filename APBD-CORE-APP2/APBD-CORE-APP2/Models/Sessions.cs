using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Sessions
    {
        public Sessions()
        {
            Handles = new HashSet<Handles>();
            StationUsed = new HashSet<StationUsed>();
        }

        public int SessionId { get; set; }
        public string SDate { get; set; }
        public int Hours { get; set; }
        public int ClientsClientId { get; set; }
        public int? IsPaid { get; set; }

        public Clients ClientsClient { get; set; }
        public ICollection<Handles> Handles { get; set; }
        public ICollection<StationUsed> StationUsed { get; set; }
    }
}
