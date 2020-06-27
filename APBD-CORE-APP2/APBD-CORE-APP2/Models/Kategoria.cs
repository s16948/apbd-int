using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Kategoria
    {
        public Kategoria()
        {
            Pokoj = new HashSet<Pokoj>();
        }

        public int IdKategoria { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }

        public ICollection<Pokoj> Pokoj { get; set; }
    }
}
