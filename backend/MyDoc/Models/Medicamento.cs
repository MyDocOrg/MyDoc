using System;
using System.Collections.Generic;

namespace MyDoc.Models;

public partial class Medicamento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Presentacion { get; set; }

    public virtual ICollection<MedicacionHorario> MedicacionHorarios { get; set; } = new List<MedicacionHorario>();
}
