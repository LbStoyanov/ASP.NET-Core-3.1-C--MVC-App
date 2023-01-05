using System.ComponentModel.DataAnnotations;

namespace Turns.Models
{
    public class Patient
    {
        [Key]
        public int PatientId {get; set;}

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last Name")]
        public string  LastName { get; set; } = null!;

        [Required]
        public string Direction { get; set; } = null!;

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

    }
}