using System.ComponentModel.DataAnnotations;

namespace Turns.Models
{
    public class Speciality
    {
        public Speciality()
        {
            this.DoctorSpecialities = new List<DoctorSpecialities>();
        }

        [Key]
        public int SpecialityId { get; set; }

        public string Description { get; set; } = null!;

        public List<DoctorSpecialities> DoctorSpecialities { get; set; } 

    }
}