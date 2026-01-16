using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Infrastructure.Models;

[Table("AppointmentStatus")]
public partial class AppointmentStatus
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? name { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? description { get; set; }

    public bool is_active { get; set; }

    [InverseProperty("status")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
