using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Dydaktycy
    {
        public Dydaktycy()
        {
            InversePodlegaNavigation = new HashSet<Dydaktycy>();
            Oceny = new HashSet<Oceny>();
        }

        public int OsobaId { get; set; }
        public int? Podlega { get; set; }
        public DateTime? DataZatrudnienia { get; set; }
        public int? StopienId { get; set; }

        public Osoby Osoba { get; set; }
        public Dydaktycy PodlegaNavigation { get; set; }
        public StopnieTytuly Stopien { get; set; }
        public ICollection<Dydaktycy> InversePodlegaNavigation { get; set; }
        public ICollection<Oceny> Oceny { get; set; }
    }
}
