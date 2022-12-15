using System.ComponentModel.DataAnnotations;

namespace Turns.Models
{
    public class Speciality
    {
        [Key]
        public int SpecialityId { get; set; }

        public string Description { get; set; } = null!;

        public List<DoctorSpeciality> DoctorSpecialities {get; set;} = null!;
    }
}