using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Infrastructure.Models;

[Table("Notification")]
public partial class Notification
{
    [Key]
    public int id { get; set; }

    public int medication_schedule_id { get; set; }

    public DateTime? sent_at { get; set; }

    public bool is_sent { get; set; }

    [ForeignKey("medication_schedule_id")]
    [InverseProperty("Notifications")]
    public virtual MedicationSchedule medication_schedule { get; set; } = null!;
}
