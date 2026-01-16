using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Infrastructure.Models;

[Table("MedicationSchedule")]
public partial class MedicationSchedule
{
    [Key]
    public int id { get; set; }

    public int prescription_id { get; set; }

    public int medicine_id { get; set; }

    public DateOnly? scheduled_date { get; set; }

    public TimeOnly? scheduled_time { get; set; }

    public bool? taken { get; set; }

    [InverseProperty("medication_schedule")]
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    [ForeignKey("medicine_id")]
    [InverseProperty("MedicationSchedules")]
    public virtual Medicine medicine { get; set; } = null!;

    [ForeignKey("prescription_id")]
    [InverseProperty("MedicationSchedules")]
    public virtual Prescription prescription { get; set; } = null!;
}
