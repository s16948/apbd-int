using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Studenci
    {
        public Studenci()
        {
            Oceny = new HashSet<Oceny>();
        }

        public int OsobaId { get; set; }
        public string NrIndeksu { get; set; }
        public DateTime? DataRekrutacji { get; set; }

        public Osoby Osoba { get; set; }
        public ICollection<Oceny> Oceny { get; set; }
    }
}
