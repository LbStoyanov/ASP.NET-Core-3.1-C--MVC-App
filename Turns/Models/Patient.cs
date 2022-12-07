using System.ComponentModel.DataAnnotations;

namespace Turns.Models
{
    public class Patient
    {
        [Key]
        public int PatientId {get; set;}

        public string FirstName { get; set; } = null!;

        public string  LastName { get; set; } = null!;

        public string Direction { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}