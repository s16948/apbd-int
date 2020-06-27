using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw2.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetStudents(Student student)
        {
          //  var st = new Student();
           // st.idStudent = id;
           // st.FirstName = "Jan";
           // st.LastName = "Kowalski";
            //st.LastName = orderBy;

            return Ok(student);
        }
    }
}
