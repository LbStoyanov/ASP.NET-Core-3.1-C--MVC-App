namespace Shifts.Models
{
    public class DoctorSpecialities
    {
        public int DoctorId { get; set; }

        public int SpecialityId { get; set; }

        public Doctor Doctor { get; set; } = null!;
        public Speciality Speciality { get; set; } = null!;
    }
}