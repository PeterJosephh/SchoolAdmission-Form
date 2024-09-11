using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace SchoolAdmission.Models
{
    public class Student
    {


        [Key]
        public  int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth {  get; set; }
        public char? Gender { get; set; }
        [StringLength(14)]
        public string? NationalityId { get; set; }
        public string CityOfBirth { get; set; }
        public string Address { get; set; }
        [StringLength(11)]

        public string? PhoneNumber { get; set; }
        //------------------------------------
        public virtual ICollection<GuardianStudent>? GuardianStudents  { get; set; }
        public virtual ICollection<Application>? Applications { get; set; }


    }
}
