using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_CORE_APP2.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD_CORE_APP2.Controllers
{
    public class StudentsController : Controller
    {
        private readonly s16540Context _context;
        
        public StudentsController(s16540Context context)
        {
            _context = context;
        }

        public async Task <IActionResult> Index()
        {


            var students =
                from student in _context.Student
                join studies in _context.Studies on student.IdStudies equals studies.IdStudies
                select new Student{FirstName= student.FirstName,LastName= student.LastName, Studies = new Studies { Name = studies.Name } };

           
           
           
            return View(students.ToList());
        }
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                var lastIndex = _context.Student.Last().IdStudent + 1;
                student.Address = "Niepotrzebny";
                //student.IdStudent = lastIndex;
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .ToAsyncEnumerable().FirstOrDefault(s => s.IdStudent == id);
               
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Student.FindAsync(id);
            _context.Student.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}