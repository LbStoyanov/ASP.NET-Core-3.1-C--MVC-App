namespace Turns.Models
{
    public class DoctorSpeciality
    {
        public int DoctorId { get; set; }
        public int SpecialityId { get; set; }

        public Doctor Doctor { get; set; } = null!;
        public Speciality Speciality { get; set; } = null!;
    }
}