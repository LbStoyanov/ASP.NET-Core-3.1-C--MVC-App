using System.ComponentModel.DataAnnotations;

namespace Turns.Models
{
    public class Doctor
    {
     
        public Doctor()
        {
            this.DoctorSpecialities = new List<DoctorSpecialities>();
        }

        [Key]
        public int DoctorId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]

        [Display(Name = "Working hours from")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime WorkingHoursFrom { get; set; }

        [Display(Name = "Working hours to")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}" , ApplyFormatInEditMode = true)]
        public DateTime WorkingHoursTo { get; set; }

        public List<DoctorSpecialities> DoctorSpecialities { get; set; } 
    }
}