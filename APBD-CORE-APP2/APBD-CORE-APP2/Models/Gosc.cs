using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Gosc
    {
        public Gosc()
        {
            Rezerwacja = new HashSet<Rezerwacja>();
        }

        public int IdGosc { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int? ProcentRabatu { get; set; }

        public ICollection<Rezerwacja> Rezerwacja { get; set; }
    }
}
