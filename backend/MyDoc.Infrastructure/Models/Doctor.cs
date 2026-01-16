using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Infrastructure.Models;

[Table("Doctor")]
public partial class Doctor
{
    [Key]
    public int id { get; set; }

    public int? user_id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? full_name { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? specialty { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? professional_license { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? phone { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? email { get; set; }

    public bool is_active { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    [InverseProperty("doctor")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [InverseProperty("doctor")]
    public virtual ICollection<ClinicDoctor> ClinicDoctors { get; set; } = new List<ClinicDoctor>();
}
