using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Handles = new HashSet<Handles>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Commision { get; set; }

        public ICollection<Handles> Handles { get; set; }
    }
}
