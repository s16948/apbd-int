using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Oceny
    {
        public int PrzedmiotId { get; set; }
        public DateTime DataWystawienia { get; set; }
        public int Student { get; set; }
        public int Dydaktyk { get; set; }
        public decimal? Ocena { get; set; }

        public Dydaktycy DydaktykNavigation { get; set; }
        public Przedmioty Przedmiot { get; set; }
        public Studenci StudentNavigation { get; set; }
    }
}
