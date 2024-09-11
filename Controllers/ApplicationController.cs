using Microsoft.AspNetCore.Mvc;
using SchoolAdmission.Models;
using System.Reflection.Metadata.Ecma335;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace SchoolAdmission.Controllers
{
    public class ApplicationController : Controller
    {
        SchoolDBContext db = new SchoolDBContext();

        [HttpGet]
        public IActionResult Form()
        {
            return View();//form
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormRespond(FormModelView form) {

            Student NewStudent = new()
            {
                Name = form.Student_FirstName + " " + form.Student_SecoundName,
                NationalityId = form.Student_NationalityId,
                DateOfBirth = form.Student_DateOfBirth,
                Gender = form.Student_Gender,
                CityOfBirth = form.Student_CityOfBirth,
                Address = form.Student_Address,
                PhoneNumber = form.Student_PhoneNumber,

            };
            Guardian NewGuardian = new()
            {
                Name = form.Guardian1_FirstName + " " + form.Guardian1_SecoundName,
                DateOfBirth = form.Guardian1_DateOfBirth,
                Gender = form.Guardian1_Gender,
                PhoneNumber = form.Guardian1_PhoneNumber,
                PhoneNumber2 = form.Guardian1_PhoneNumber2,
                Email = form.Guardian1_Email,
                NationalityId = form.Guardian1_NationalityId
            };
            Guardian NewGuardian2 = new()
            {
                Name = form.Guardian2_FirstName + " " + form.Guardian2_SecoundName,
                DateOfBirth = form.Guardian2_DateOfBirth,
                Gender = form.Guardian2_Gender,
                PhoneNumber = form.Guardian2_PhoneNumber,
                PhoneNumber2 = form.Guardian2_PhoneNumber2,
                Email = form.Guardian2_Email,
                NationalityId = form.Guardian2_NationalityId
            };


            if (!(ModelState.IsValid))
            {
                return View("Form", form);
            }
            else
            {
                try
                {
                    if (db.Students.Any(s => s.NationalityId == form.Student_NationalityId))
                    {
                        IEnumerable<Application> applications = db.Applications.Where(a => a.StudentId == db.Students.FirstOrDefault(s => s.NationalityId == form.Student_NationalityId).Id);
                        if (applications.Any(a => a.RequestedYear == form.RquestedYear))
                        {
                            ModelState.AddModelError("Student_FirstName", "This Student Requested Same Year Before");
                            return View("Form", form);
                        }
                        else
                        {
                            //Add new Student
                            //if Guardian exist
                            if (db.Guardians.Any(g => g.NationalityId == form.Guardian1_NationalityId))
                            {
                                db.Students.Add(NewStudent);
                                db.SaveChanges();
                                db.GuardianStudents.Add(new GuardianStudent()
                                {
                                    StudentId = db.Students.FirstOrDefault(s => s.NationalityId == form.Student_NationalityId).Id,
                                    GuardianId = db.Guardians.FirstOrDefault(g => g.NationalityId == form.Guardian1_NationalityId).Id,
                                    Relationship = form.Guardian1_Relation
                                });
                                Application NewApplication = new()
                                {

                                    StudentId = db.Students.FirstOrDefault(s => s.NationalityId == form.Student_NationalityId).Id,
                                    RequestedYear = form.RquestedYear,
                                    SubmissionDate = DateTime.Now

                                };
                                db.Applications.Add(NewApplication);
                                db.SaveChanges();


                                return View("formfeedback",true);

                            }
                            //if Guardian doesnt exist
                            else
                            {
                                db.Students.Add(NewStudent);
                                db.Guardians.Add(new Guardian
                                {
                                    Name = form.Guardian1_FirstName + " " + form.Guardian1_SecoundName,
                                    DateOfBirth = form.Guardian1_DateOfBirth,
                                    Gender = form.Guardian1_Gender,
                                    PhoneNumber = form.Guardian1_PhoneNumber,
                                    PhoneNumber2 = form.Guardian1_PhoneNumber2,
                                    Email = form.Guardian1_Email,
                                    NationalityId = form.Guardian1_NationalityId

                                });
                                db.SaveChanges();
                                db.GuardianStudents.Add(new GuardianStudent()
                                {
                                    StudentId = db.Students.Single(s => s.NationalityId == form.Student_NationalityId).Id,
                                    GuardianId = db.Guardians.Single(g => g.NationalityId == form.Guardian1_NationalityId).Id,
                                    Relationship = form.Guardian1_Relation
                                });
                                db.Applications.Add(new Application()
                                {
                                    StudentId = db.Students.FirstOrDefault(s => s.NationalityId == form.Student_NationalityId).Id,
                                    RequestedYear = form.RquestedYear,
                                    SubmissionDate = DateTime.Now

                                });
                                db.SaveChanges();
                                AddGuardian2(NewGuardian, form.Student_NationalityId, form.Guardian2_Relation);
                                return View("formfeedback", true);

                            }

                        }

                    }
                    else
                    {
                        //Add new Student
                        //if Guardian exist
                        if (db.Guardians.Any(g => g.NationalityId == form.Guardian1_NationalityId))
                        {
                            db.Students.Add(NewStudent);
                            db.SaveChanges();
                            db.GuardianStudents.Add(new GuardianStudent()
                            {
                                StudentId = db.Students.FirstOrDefault(s => s.NationalityId == form.Student_NationalityId).Id,
                                GuardianId = db.Guardians.FirstOrDefault(g => g.NationalityId == form.Guardian1_NationalityId).Id,
                                Relationship = form.Guardian1_Relation
                            });
                            Application NewApplication = new()
                            {

                                StudentId = db.Students.FirstOrDefault(s => s.NationalityId == form.Student_NationalityId).Id,
                                RequestedYear = form.RquestedYear,
                                SubmissionDate = DateTime.Now

                            };
                            db.Applications.Add(NewApplication);
                            db.SaveChanges();
                            AddGuardian2(NewGuardian, form.Student_NationalityId, form.Guardian2_Relation);
                            return Redirect("formfeedback/?feedback=true");


                        }
                        //if Guardian doesnt exist
                        else
                        {
                            db.Students.Add(NewStudent);
                            db.Guardians.Add(NewGuardian);
                            db.SaveChanges();
                            Application NewApplication = new()
                            {

                                StudentId = db.Students.FirstOrDefault(s => s.NationalityId == form.Student_NationalityId).Id,
                                RequestedYear = form.RquestedYear,
                                SubmissionDate = DateTime.Now

                            };
                            db.Applications.Add(NewApplication);
                            db.GuardianStudents.Add(new GuardianStudent()
                            {
                                StudentId = db.Students.FirstOrDefault(s => s.NationalityId == form.Student_NationalityId).Id,
                                GuardianId = db.Guardians.Single(g => g.NationalityId == form.Guardian1_NationalityId).Id,
                                Relationship = form.Guardian1_Relation,
                            });
                            db.SaveChanges();
                            AddGuardian2(NewGuardian, form.Student_NationalityId, form.Guardian2_Relation);
                            return View("formfeedback", true);

                        }

                    }
                    
                }
                catch (Exception e)
                {
                    return View("formfeedback", false);


                }
            }
        }

        private void AddGuardian2(Guardian guardian, string StudentNID, string relation)
        {
            if (db.Guardians.Any(g => g.NationalityId == guardian.NationalityId))
            {
                db.GuardianStudents.Add(new GuardianStudent()
                {
                    StudentId = db.Students.FirstOrDefault(s => s.NationalityId == StudentNID).Id,
                    GuardianId = db.Guardians.FirstOrDefault(g => g.NationalityId == guardian.NationalityId).Id,
                    Relationship = relation

                });
                db.SaveChanges();

            }
            else
            {
                db.Guardians.Add(guardian);
                db.SaveChanges();
                db.GuardianStudents.Add(new GuardianStudent()
                {
                    StudentId = db.Students.FirstOrDefault(s => s.NationalityId == StudentNID).Id,
                    GuardianId = db.Guardians.FirstOrDefault(g => g.NationalityId == guardian.NationalityId).Id,
                    Relationship = relation

                });
                db.SaveChanges();


            }


        }

        public IActionResult FormFeedBack(bool feedback){

            return View(feedback);
        }
        public IActionResult ViewALL()
        {
            var query = (from application in db.Applications.ToList()
                         join student in db.Students.ToList() on application.StudentId equals student.Id
                         where application.StudentId == student.Id
                         select new
                         {
                             StudentName = student.Name,
                             AppSup = application.SubmissionDate,
                             StudentID = student.Id,
                             Appreq = application.RequestedYear,


                         });





            return View(query);
        }



    }
}
