using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdmission.Models
{
    public class Application
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public required int StudentId { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public String? RequestedYear { get; set; }
        public  Student? Student { get; set; }

    }
}
