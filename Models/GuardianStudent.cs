using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdmission.Models
{
    public class GuardianStudent
    {
        public int Id { get; set; }
        public string? Relationship { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Guardian")]
        public int GuardianId { get; set; }


        public Student Student { get; set; }
        public Guardian Guardian { get; set; }


    }
}
