using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Przedmioty
    {
        public Przedmioty()
        {
            Oceny = new HashSet<Oceny>();
        }

        public int PrzedmiotId { get; set; }
        public string PrzedmiotSkrot { get; set; }
        public string Przedmiot { get; set; }

        public ICollection<Oceny> Oceny { get; set; }
    }
}
