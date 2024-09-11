using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolAdmission.Models
{
    public class Guardian
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        [StringLength(11)]

        public string PhoneNumber { get; set; }
        [StringLength(11)]

        public string? PhoneNumber2 { get; set; }
        public string? Email { get; set; }
        [StringLength(14)]

        public string? NationalityId { get; set; }

        public virtual ICollection<GuardianStudent>? GuardianStudents { get; set; }


    }
}