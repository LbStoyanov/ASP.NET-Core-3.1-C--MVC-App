using System.ComponentModel.DataAnnotations;

namespace Turns.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }

        [Required(ErrorMessage = "You must enter an username")]
        public string Username { get; set; } = null!;
        
        [Required(ErrorMessage = "You must enter a password")]
        public string Password {get; set;} = null!;
    }
}