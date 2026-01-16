using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Infrastructure.Models;

[Table("Appointment")]
public partial class Appointment
{
    [Key]
    public int id { get; set; }

    public int doctor_id { get; set; }

    public int clinic_id { get; set; }

    public int patient_id { get; set; }

    public int status_id { get; set; }

    public DateTime? appointment_date { get; set; }

    public DateTime? created_at { get; set; }

    [InverseProperty("appointment")]
    public virtual ICollection<Consultation> Consultations { get; set; } = new List<Consultation>();

    [ForeignKey("clinic_id")]
    [InverseProperty("Appointments")]
    public virtual Clinic clinic { get; set; } = null!;

    [ForeignKey("doctor_id")]
    [InverseProperty("Appointments")]
    public virtual Doctor doctor { get; set; } = null!;

    [ForeignKey("patient_id")]
    [InverseProperty("Appointments")]
    public virtual Patient patient { get; set; } = null!;

    [ForeignKey("status_id")]
    [InverseProperty("Appointments")]
    public virtual AppointmentStatus status { get; set; } = null!;
}
