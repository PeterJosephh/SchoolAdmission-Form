namespace SchoolAdmission.Models
{
    public class StudentDataModelView
    {
        public Student student { get; set; }
        public List<Application> applications { get; set; }
        public List<Guardian> Guardians { get; set; }
    }
}
