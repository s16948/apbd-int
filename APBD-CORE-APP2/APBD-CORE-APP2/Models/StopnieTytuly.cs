using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class StopnieTytuly
    {
        public StopnieTytuly()
        {
            Dydaktycy = new HashSet<Dydaktycy>();
        }

        public int StopienId { get; set; }
        public string StopienSkrot { get; set; }
        public string Stopien { get; set; }

        public ICollection<Dydaktycy> Dydaktycy { get; set; }
    }
}
