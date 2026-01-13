using System;
using System.Collections.Generic;

namespace MyDoc.Models;

public partial class MedicacionHorario
{
    public int Id { get; set; }

    public int RecetaId { get; set; }

    public int MedicamentoId { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public bool? Tomado { get; set; }

    public virtual Medicamento Medicamento { get; set; } = null!;

    public virtual ICollection<Notificacion> Notificacions { get; set; } = new List<Notificacion>();

    public virtual Receta Receta { get; set; } = null!;
}
