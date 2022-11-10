using Microsoft.EntityFrameworkCore;

namespace Turns.Models
{
    public class TurnsContext : DbContext
    {
        public TurnsContext(DbContextOptions<TurnsContext> options)
        :base(options)
        {
            
        }

        public DbSet<Speciality> Specialities{ get; set;}
    }
}