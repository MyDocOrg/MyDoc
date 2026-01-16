using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Infrastructure.Models;

[Table("PrescriptionMedicine")]
public partial class PrescriptionMedicine
{
    [Key]
    public int id { get; set; }

    public int prescription_id { get; set; }

    public int medicine_id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? dosage { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? frequency { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? duration { get; set; }

    [ForeignKey("medicine_id")]
    [InverseProperty("PrescriptionMedicines")]
    public virtual Medicine medicine { get; set; } = null!;

    [ForeignKey("prescription_id")]
    [InverseProperty("PrescriptionMedicines")]
    public virtual Prescription prescription { get; set; } = null!;
}
