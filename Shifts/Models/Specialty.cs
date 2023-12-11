using System.ComponentModel.DataAnnotations;

namespace Shifts.Models
{
    public class Specialty
    {
        public Specialty()
        {
            this.DoctorSpecialties = new List<DoctorSpecialties>();
        }

        [Key]
        [Required(ErrorMessage = "A specialty is required. If the list is empty, first create a specialty for this doctor!")]
        public int SpecialtyId { get; set; }

        //[StringLength(200,ErrorMessage = "The field should have maximum 200 characters")]
        [Required(ErrorMessage = "A discription is required")]
        [Display(Name = "Description", Prompt = "Enter a description")]
        public string Description { get; set; } = null!;

        public List<DoctorSpecialties> DoctorSpecialties { get; set; }

    }
}