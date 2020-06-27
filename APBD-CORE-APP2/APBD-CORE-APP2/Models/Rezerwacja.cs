using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Rezerwacja
    {
        public int IdRezerwacja { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
        public int IdGosc { get; set; }
        public int NrPokoju { get; set; }
        public bool Zaplacona { get; set; }

        public Gosc IdGoscNavigation { get; set; }
        public Pokoj NrPokojuNavigation { get; set; }
    }
}
