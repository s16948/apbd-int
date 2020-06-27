using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Osoby
    {
        public int OsobaId { get; set; }
        public string Nazwisko { get; set; }
        public string Imie { get; set; }

        public Dydaktycy Dydaktycy { get; set; }
        public Studenci Studenci { get; set; }
    }
}
