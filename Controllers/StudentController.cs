using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Models;

namespace SchoolAdmission.Controllers
{
    public class StudentController : Controller
    {
        SchoolDBContext db = new SchoolDBContext();
        public IActionResult Index(int id)
        {
            StudentDataModelView student = new StudentDataModelView();

            student.student = db.Students.Find(id);

            return View();
        }
    }
}
