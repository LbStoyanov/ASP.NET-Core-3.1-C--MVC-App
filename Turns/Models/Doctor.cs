using System.ComponentModel.DataAnnotations;

namespace Turns.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;

        public DateTime WorkingHoursFrom { get; set; }
        public DateTime WorkingHoursTo { get; set; }
    }
}