namespace Shifts.Models
{
    public class DoctorSpecialties
    {
        public int DoctorId { get; set; }

        public int SpecialtyId { get; set; }

        public Doctor Doctor { get; set; } = null!;
        public Specialty Specialty { get; set; } = null!;
    }
}