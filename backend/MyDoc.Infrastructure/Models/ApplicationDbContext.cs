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

    public virtual DbSet<PrescriptionMedicine> PrescriptionMedicine { get; set; }
}
