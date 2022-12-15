using Microsoft.EntityFrameworkCore;

namespace Turns.Models
{
    public class TurnsContext : DbContext
    {
        public TurnsContext(DbContextOptions<TurnsContext> options) 
            :base(options)
        {
            
        }

        public DbSet<Speciality> Specialities{ get; set;} = null!;

        public DbSet<Patient> Patients {get; set;} = null!;

        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<DoctorSpeciality> DoctorSpecialities { get; set; } = null!;

        


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

            modelBuilder.Entity<Doctor>(entity => {
                entity.ToTable("Doctors");

                entity.HasKey(d => d.DoctorId);

                entity.Property(d => d.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(d => d.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(d => d.Address)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entity.Property(d => d.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entity.Property(d => d.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(d => d.WorkingHoursFrom)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(d => d.WorkingHoursTo)
                .IsRequired()
                .IsUnicode(false);
            });
            
            modelBuilder.Entity<DoctorSpeciality>().HasKey(x => new {x.DoctorId,x.SpecialityId});

            modelBuilder.Entity<DoctorSpeciality>().HasOne(x => x.Doctor)
            .WithMany(p => p.DoctorSpecialities)
            .HasForeignKey(p => p.DoctorId);

             modelBuilder.Entity<DoctorSpeciality>().HasOne(x => x.Speciality)
            .WithMany(p => p.DoctorSpecialities)
            .HasForeignKey(p => p.SpecialityId);
        }

        


        


        
    }
}