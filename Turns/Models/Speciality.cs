using System.ComponentModel.DataAnnotations;

namespace Turns.Models
{
    public class Speciality
    {
        [Key]
        public int SpecialtyId { get; set; }

        public string Description { get; set; }
    }
}