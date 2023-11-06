using System.ComponentModel.DataAnnotations;

namespace Shifts.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }

        [Required(ErrorMessage = "You must enter a valid username")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a valid password")]
        public string Password { get; set; } = null!;
    }
}