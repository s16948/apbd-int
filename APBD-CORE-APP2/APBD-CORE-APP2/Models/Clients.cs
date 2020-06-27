using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Clients
    {
        public Clients()
        {
            Sessions = new HashSet<Sessions>();
        }

        public int ClientId { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }

        public ICollection<Sessions> Sessions { get; set; }
    }
}
