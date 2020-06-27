using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Pokoj
    {
        public Pokoj()
        {
            Rezerwacja = new HashSet<Rezerwacja>();
        }

        public int NrPokoju { get; set; }
        public int IdKategoria { get; set; }
        public int LiczbaMiejsc { get; set; }

        public Kategoria IdKategoriaNavigation { get; set; }
        public ICollection<Rezerwacja> Rezerwacja { get; set; }
    }
}
