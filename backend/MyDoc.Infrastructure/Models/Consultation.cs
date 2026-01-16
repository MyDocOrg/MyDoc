using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Infrastructure.Models;

[Table("Consultation")]
public partial class Consultation
{
    [Key]
    public int id { get; set; }

    public int appointment_id { get; set; }

    [Unicode(false)]
    public string? reason { get; set; }

    [Unicode(false)]
    public string? diagnosis { get; set; }

    public DateTime? consultation_date { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? weight_kg { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? height_cm { get; set; }

    [InverseProperty("consultation")]
    public virtual ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();

    [ForeignKey("appointment_id")]
    [InverseProperty("Consultations")]
    public virtual Appointment appointment { get; set; } = null!;
}
