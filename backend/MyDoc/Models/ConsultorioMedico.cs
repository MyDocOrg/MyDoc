using System;
using System.Collections.Generic;

namespace MyDoc.Models;

public partial class ConsultorioMedico
{
    public int Id { get; set; }

    public int ConsultorioId { get; set; }

    public int MedicoId { get; set; }

    public virtual Consultorio Consultorio { get; set; } = null!;

    public virtual Medico Medico { get; set; } = null!;
}
