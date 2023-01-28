using System.ComponentModel.DataAnnotations;

namespace Turns.Models
{
    public class Turn
    {
        [Key]
        public int TurnId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        [Display(Name = "Date Time Start")] //TODO:Turn start at
        public DateTime DateTimeStart { get; set; }
         [Display(Name = "Date Time End")]
        public DateTime DateTimeEnd { get; set; }
        public Patient Patient { get; set; } = null!;
        public Doctor Doctor { get; set; } = null!;
    }
}