using System.ComponentModel.DataAnnotations;

namespace Turns.Models
{
    public class Patient
    {
        [Key]
        public int PatientId {get; set;}

        public string FirstName { get; set; }

        public string  LastName { get; set; }

        public string Direction { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}