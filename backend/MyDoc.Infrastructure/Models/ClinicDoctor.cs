using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Infrastructure.Models;

[Table("ClinicDoctor")]
public partial class ClinicDoctor
{
    [Key]
    public int id { get; set; }

    public int doctor_id { get; set; }

    public int clinic_id { get; set; }

    public bool is_active { get; set; }

    [ForeignKey("clinic_id")]
    [InverseProperty("ClinicDoctors")]
    public virtual Clinic clinic { get; set; } = null!;

    [ForeignKey("doctor_id")]
    [InverseProperty("ClinicDoctors")]
    public virtual Doctor doctor { get; set; } = null!;
}
