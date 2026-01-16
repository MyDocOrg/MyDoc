using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Infrastructure.Models;

[Table("Medicine")]
public partial class Medicine
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? name { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? description { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? presentation { get; set; }

    public bool is_active { get; set; }

    [InverseProperty("medicine")]
    public virtual ICollection<MedicationSchedule> MedicationSchedules { get; set; } = new List<MedicationSchedule>();

    [InverseProperty("medicine")]
    public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();
}
