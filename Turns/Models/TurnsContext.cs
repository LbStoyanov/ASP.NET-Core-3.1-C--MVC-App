using Microsoft.EntityFrameworkCore;

namespace Turns.Models
{
    public class TurnsContext : DbContext
    {
        public TurnsContext(DbContextOptions<TurnsContext> options) 
        {
            
        }

        public DbSet<Speciality> Specialities{ get; set;} = null!;

        public DbSet<Patient> Patients {get; set;} = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speciality>(entity => 
            {
                entity.ToTable("Specialities");

                entity.HasKey(e => e.SpecialityId);

                entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patients");

                entity.HasKey(p => p.PatientId);

                entity.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);


                entity.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(p => p.Direction)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entity.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });
            
        }
    }
}