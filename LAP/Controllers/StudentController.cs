using LAP.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAP.Controllers
{
    public class StudentController : Controller
    {
        DataContext Context = new DataContext();
        public IActionResult GetStudent(int id)
        {
            var std = Context.Students.FirstOrDefault(x => x.Id == id);


            return View(std);
        }
        public IActionResult GetStudents()
        {
            StudentDepartment std_dept = new StudentDepartment();


           std_dept.Students = Context.Students.ToList();
            std_dept.Departments = Context.Departments.ToList();

            return View(std_dept);
        }

        [HttpGet]
        public IActionResult AddStudent() 
        {

            
            return View();
        }
        [HttpPost]
        public IActionResult AddStudentActial(Student student)
        {
            if (ModelState.IsValid)
            {
                Context.Students.Add(student);
                Context.SaveChanges();

                return RedirectToAction("GetStudents");
            }
            else
            {
                return View("AddStudent");
            }
        }
        
        public IActionResult RemoveStudentActiual(int id)
        {
            
                var std = Context.Students.FirstOrDefault(x => x.Id == id);
            if (std!= null)
            {
                Context.Students.Remove(std);
                Context.SaveChanges();

                return RedirectToAction("GetStudents");
            }
            else
            {
                return Content("Not Found");
            }
        }


        public IActionResult UpdateStudent(int id)
        {

            Student student = Context.Students.FirstOrDefault(x => x.Id == id);
            
            return View(student);
        }
        public IActionResult UpdateStudentActial(Student student)
        {
            if (ModelState.IsValid)
            {
                var std = Context.Students.FirstOrDefault(x => x.Id == student.Id);
                
                    std.Id = student.Id;
                    std.Name = student.Name;
                    std.Age = student.Age;
                    std.DepatmentId = student.DepatmentId;
                    Context.Students.Update(std);
                    Context.SaveChanges();
                    return RedirectToAction("GetStudents");
                
            }
            else
            {
                return View("updatestudent");
            }
        }
    }
}
