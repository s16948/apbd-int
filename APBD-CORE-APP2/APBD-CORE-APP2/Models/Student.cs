using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APBD_CORE_APP2.Models
{
    public partial class Student
    {
        public int IdStudent { get; set; }
        [Display(Name ="Imie")]
        [Required(ErrorMessage ="Imie wymagane")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Nazwisko wymagane")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string IndexNumber { get; set; }
        public int IdStudies { get; set; }
        public Studies Studies { get; set; }
    }
}
