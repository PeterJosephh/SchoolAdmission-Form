using System.ComponentModel.DataAnnotations;

namespace SchoolAdmission.Models
{

    public class FormModelView
    {
        //---------------Student-----------

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$")]
        public string? Student_FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$")]

        public string? Student_SecoundName { get; set; }

        [Required]
        public DateTime Student_DateOfBirth { get; set; }
        [Required]
        [RegularExpression(@"^[MF]$")]

        public char Student_Gender { get; set; }
        [Required]
        [StringLength(14)]

        public string? Student_NationalityId { get; set; }
        [Required]

        public string? Student_CityOfBirth { get; set; }

        [Required]
        public string ?Student_Address { get; set; }

        [RegularExpression(@"^\d{11}$")]
        [StringLength(11)]

        public string ?Student_PhoneNumber { get; set; }
        //--------Application------------
        [Required]

        public string ?RquestedYear { get; set; }

        //----------Guardian1-----------

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$")]

        public string ?Guardian1_FirstName { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$")]

        public string ?Guardian1_SecoundName { get; set; }

        [Required]
        [RegularExpression(@"^[MF]$")]
        public char Guardian1_Gender { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$")]

        public string? Guardian1_Pro { get; set; }

        [Required]
        [StringLength(14)]
        public string? Guardian1_NationalityId { get; set; }
        [Required]

        public DateTime Guardian1_DateOfBirth { get; set; }
        [Required]

        [RegularExpression(@"^\d{11}$")]
        [StringLength(11)]

        public string? Guardian1_PhoneNumber { get; set; }
        [RegularExpression(@"^\d{11}$")]
        [StringLength(11)]


        public string ?Guardian1_PhoneNumber2 { get; set; }
        [Required]

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string ?Guardian1_Email { get; set; }

        [Required]

        public string ?Guardian1_Relation { get; set; }


        //----------Guardian2-----------

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$")]

        public string? Guardian2_FirstName { get; set; }


        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$")]

        public string? Guardian2_SecoundName { get; set; }

        [Required]
        [RegularExpression(@"^[MF]$")]
        public char Guardian2_Gender { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z\s]+$")]

        public string? Guardian2_Pro { get; set; }

        [Required]
        [StringLength(14)]
        public string? Guardian2_NationalityId { get; set; }
        [Required]

        public DateTime Guardian2_DateOfBirth { get; set; }
        [Required]

        [RegularExpression(@"^\d{11}$")]
        [StringLength(11)]

        public string? Guardian2_PhoneNumber { get; set; }
        [RegularExpression(@"^\d{11}$")]
        [StringLength(11)]


        public string? Guardian2_PhoneNumber2 { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]

        [Required]
        public string? Guardian2_Email { get; set; }

        [Required]
        public string? Guardian2_Relation { get; set; }




    }
}
