using System;
using System.Collections.Generic;

namespace MyDoc.Models;

public partial class Notificacion
{
    public int Id { get; set; }

    public int MedicacionHorarioId { get; set; }

    public DateTime FechaEnvio { get; set; }

    public bool? Enviada { get; set; }

    public virtual MedicacionHorario MedicacionHorario { get; set; } = null!;
}
