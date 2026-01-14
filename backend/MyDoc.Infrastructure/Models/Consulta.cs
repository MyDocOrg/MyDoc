using System;
using System.Collections.Generic;

namespace MyDoc.Models;

public partial class Consulta
{
    public int Id { get; set; }

    public int MedicoId { get; set; }

    public int ConsultorioId { get; set; }

    public int PacienteId { get; set; }

    public DateTime Fecha { get; set; }

    public string Motivo { get; set; } = null!;

    public string Diagnostico { get; set; } = null!;

    public virtual Consultorio Consultorio { get; set; } = null!;

    public virtual ICollection<HistorialMedico> HistorialMedicos { get; set; } = new List<HistorialMedico>();

    public virtual Medico Medico { get; set; } = null!;

    public virtual Paciente Paciente { get; set; } = null!;
}
