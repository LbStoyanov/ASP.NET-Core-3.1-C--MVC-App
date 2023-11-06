using System.ComponentModel.DataAnnotations;

namespace Turns.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "You must enter an username")]
        public string Username { get; set; } = null!;
        
        [Required(ErrorMessage = "You must enter a password")]
        public string Password {get; set;} = null!;

         [Required(ErrorMessage = "You must enter the same password from teh previuous box")]
        public string RepeatPassword {get; set;} = null!;
    }
}