using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Infrastructure.Models;

[Table("MedicalHistory")]
public partial class MedicalHistory
{
    [Key]
    public int id { get; set; }

    public int consultation_id { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? notes { get; set; }

    public DateTime? created_at { get; set; }

    [InverseProperty("medical_history")]
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    [ForeignKey("consultation_id")]
    [InverseProperty("MedicalHistories")]
    public virtual Consultation consultation { get; set; } = null!;
}
