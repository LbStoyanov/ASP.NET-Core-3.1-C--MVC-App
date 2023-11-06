using System.ComponentModel.DataAnnotations;

namespace Shifts.Models
{
    public partial class Patient
    {
        public Patient()
        {
            this.Turns = new List<Shift>();
        }

        [Key]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "You should enter your first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "You should enter your last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "You should enter your direction")]
        public string Direction { get; set; } = null!;

        [Required(ErrorMessage = "You should enter your phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "You should enter your email address")]
        [EmailAddress(ErrorMessage = "This is not a valid email address")]
        public string Email { get; set; } = null!;

        public List<Shift> Turns { get; set; } = null!;

    }
}