using System;
using System.Collections.Generic;

namespace MyDoc.Models;

public partial class Receta
{
    public int Id { get; set; }

    public int HistorialMedicoId { get; set; }

    public DateTime Fecha { get; set; }

    public string? IndicacionesGenerales { get; set; }

    public virtual HistorialMedico HistorialMedico { get; set; } = null!;

    public virtual ICollection<MedicacionHorario> MedicacionHorarios { get; set; } = new List<MedicacionHorario>();
}
