using System;
using System.Collections.Generic;

namespace MyDoc.Models;

public partial class HistorialMedico
{
    public int Id { get; set; }

    public int CitaId { get; set; }

    public int ConsultaId { get; set; }

    public DateTime FechaRegistro { get; set; }

    public string? Diagnostico { get; set; }

    public string? Observaciones { get; set; }

    public virtual Cita Cita { get; set; } = null!;

    public virtual Consulta Consulta { get; set; } = null!;

    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
