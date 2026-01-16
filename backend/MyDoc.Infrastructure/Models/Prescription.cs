using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Infrastructure.Models;

[Table("Prescription")]
public partial class Prescription
{
    [Key]
    public int id { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? general_instructions { get; set; }

    public int medical_history_id { get; set; }

    public DateTime? created_at { get; set; }

    [InverseProperty("prescription")]
    public virtual ICollection<MedicationSchedule> MedicationSchedules { get; set; } = new List<MedicationSchedule>();

    [InverseProperty("prescription")]
    public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();

    [ForeignKey("medical_history_id")]
    [InverseProperty("Prescriptions")]
    public virtual MedicalHistory medical_history { get; set; } = null!;
}
