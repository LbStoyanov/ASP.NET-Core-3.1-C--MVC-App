using System.ComponentModel.DataAnnotations;

namespace Shifts.Models
{
    public class Speciality
    {
        public Speciality()
        {
            this.DoctorSpecialities = new List<DoctorSpecialities>();
        }

        [Key]
        public int SpecialityId { get; set; }

        //[StringLength(200)]
        [Display(Prompt = "Enter a speciality")]
        public string Description { get; set; } = null!;

        public List<DoctorSpecialities> DoctorSpecialities { get; set; }

    }
}