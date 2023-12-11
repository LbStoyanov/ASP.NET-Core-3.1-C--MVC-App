using Microsoft.EntityFrameworkCore;

namespace Shifts.Models
{
    public class ShiftsContext : DbContext
    {
        public ShiftsContext(DbContextOptions<ShiftsContext> options)
            : base(options)
        {

        }

        public DbSet<Specialty> Specialties { get; set; } = null!;

        public DbSet<Patient> Patients { get; set; } = null!;

        public DbSet<Doctor> Doctors { get; set; } = null!;

        public DbSet<DoctorSpecialties> DoctorSpecialties { get; set; } = null!;
        public DbSet<Shift> Shifts { get; set; } = null!;

        public DbSet<Login> Logins { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.ToTable("Specialties");

                entity.HasKey(e => e.SpecialtyId);

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

            modelBuilder.Entity<Doctor>(entity =>
            {
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

            modelBuilder.Entity<DoctorSpecialties>().HasKey(x => new { x.DoctorId, x.SpecialtyId });

            modelBuilder.Entity<DoctorSpecialties>().HasOne(x => x.Doctor)
            .WithMany(p => p.DoctorSpecialties)
            .HasForeignKey(p => p.DoctorId);

            modelBuilder.Entity<DoctorSpecialties>().HasOne(x => x.Specialty)
            .WithMany(p => p.DoctorSpecialties)
            .HasForeignKey(p => p.SpecialtyId);

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shifts");

                entity.HasKey(d => d.ShiftId);

                entity.Property(d => d.PatientId)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(d => d.DoctorId)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(d => d.DateTimeStart)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(d => d.DateTimeEnd)
                .IsRequired()
                .IsUnicode(false);
            });

            modelBuilder.Entity<Shift>().HasOne(x => x.Patient)
           .WithMany(p => p.Shifts)
           .HasForeignKey(p => p.PatientId);

            modelBuilder.Entity<Shift>().HasOne(x => x.Doctor)
           .WithMany(p => p.Shifts)
           .HasForeignKey(p => p.DoctorId);

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Logins");
                entity.HasKey(l => l.LoginId);
                entity.Property(l => l.Username)
                .IsRequired();

                entity.Property(l => l.Password)
                .IsRequired();
            });

        }

    }
}