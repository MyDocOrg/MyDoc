using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Infrastructure.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointment { get; set; }

    public virtual DbSet<AppointmentStatus> AppointmentStatus { get; set; }

    public virtual DbSet<Clinic> Clinic { get; set; }

    public virtual DbSet<ClinicDoctor> ClinicDoctor { get; set; }

    public virtual DbSet<Consultation> Consultation { get; set; }

    public virtual DbSet<Doctor> Doctor { get; set; }

    public virtual DbSet<MedicalHistory> MedicalHistory { get; set; }

    public virtual DbSet<MedicationSchedule> MedicationSchedule { get; set; }

    public virtual DbSet<Medicine> Medicine { get; set; }

    public virtual DbSet<Notification> Notification { get; set; }

    public virtual DbSet<Patient> Patient { get; set; }

    public virtual DbSet<Prescription> Prescription { get; set; }

    public virtual DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        // Este mensaje solo aparecerá si alguien no configura correctamente
        throw new InvalidOperationException(
            "Database connection not configured. Add connection string to appsettings.json");
    }
}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Appointm__3213E83FC3724F7D");

            entity.HasOne(d => d.clinic).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Clinic");

            entity.HasOne(d => d.doctor).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Doctor");

            entity.HasOne(d => d.patient).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Patient");

            entity.HasOne(d => d.status).WithMany(p => p.Appointments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointment_Status");
        });

        modelBuilder.Entity<AppointmentStatus>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Appointm__3213E83F78C7EE85");

            entity.Property(e => e.is_active).HasDefaultValue(true);
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Clinic__3213E83F8F88FA81");

            entity.Property(e => e.is_active).HasDefaultValue(true);
        });

        modelBuilder.Entity<ClinicDoctor>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__ClinicDo__3213E83FAE692F7A");

            entity.Property(e => e.is_active).HasDefaultValue(true);

            entity.HasOne(d => d.clinic).WithMany(p => p.ClinicDoctors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClinicDoctor_Clinic");

            entity.HasOne(d => d.doctor).WithMany(p => p.ClinicDoctors)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClinicDoctor_Doctor");
        });

        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Consulta__3213E83F0D1CBA77");

            entity.HasOne(d => d.appointment).WithMany(p => p.Consultations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consultation_Appointment");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Doctor__3213E83FDC2AE96F");

            entity.Property(e => e.is_active).HasDefaultValue(true);
        });

        modelBuilder.Entity<MedicalHistory>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__MedicalH__3213E83F02D1F431");

            entity.HasOne(d => d.consultation).WithMany(p => p.MedicalHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MedicalHistory_Consultation");
        });

        modelBuilder.Entity<MedicationSchedule>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Medicati__3213E83F65A95C27");

            entity.HasOne(d => d.medicine).WithMany(p => p.MedicationSchedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MS_Medicine");

            entity.HasOne(d => d.prescription).WithMany(p => p.MedicationSchedules)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MS_Prescription");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Medicine__3213E83FCDF67AB9");

            entity.Property(e => e.is_active).HasDefaultValue(true);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Notifica__3213E83FDBFE0E34");

            entity.Property(e => e.is_sent).HasDefaultValue(true);

            entity.HasOne(d => d.medication_schedule).WithMany(p => p.Notifications)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notification_MedicationSchedule");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Patient__3213E83F4152B424");

            entity.Property(e => e.gender).IsFixedLength();
            entity.Property(e => e.is_active).HasDefaultValue(true);
            
            // Query filter para soft delete - solo devuelve registros activos
            entity.HasQueryFilter(p => p.is_active);
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Prescrip__3213E83F1E2CBB5B");

            entity.HasOne(d => d.medical_history).WithMany(p => p.Prescriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prescription_MedicalHistory");
        });

        modelBuilder.Entity<PrescriptionMedicine>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Prescrip__3213E83FFD564BC0");

            entity.HasOne(d => d.medicine).WithMany(p => p.PrescriptionMedicines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PM_Medicine");

            entity.HasOne(d => d.prescription).WithMany(p => p.PrescriptionMedicines)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PM_Prescription");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
