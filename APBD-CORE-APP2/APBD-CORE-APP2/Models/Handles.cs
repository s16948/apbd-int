using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class Handles
    {
        public int EmployeesEmployeeId { get; set; }
        public int SessionsSessionId { get; set; }

        public Employees EmployeesEmployee { get; set; }
        public Sessions SessionsSession { get; set; }
    }
}
