using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Infrastructure.Models;

[Table("Clinic")]
public partial class Clinic
{
    [Key]
    public int id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? name { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? address { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? phone { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? email { get; set; }

    public bool is_active { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    [InverseProperty("clinic")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [InverseProperty("clinic")]
    public virtual ICollection<ClinicDoctor> ClinicDoctors { get; set; } = new List<ClinicDoctor>();
}
