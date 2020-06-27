using System;
using System.Collections.Generic;

namespace APBD_CORE_APP2.Models
{
    public partial class StudentSubject
    {
        public int IdStudentSubject { get; set; }
        public int IdStudent { get; set; }
        public int IdSubject { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
