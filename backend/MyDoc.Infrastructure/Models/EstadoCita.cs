using System;
using System.Collections.Generic;

namespace MyDoc.Models;

public partial class EstadoCita
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
