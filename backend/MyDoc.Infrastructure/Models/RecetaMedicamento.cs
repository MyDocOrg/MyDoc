using System;
using System.Collections.Generic;

namespace MyDoc.Models;

public partial class RecetaMedicamento
{
    public int Id { get; set; }

    public int MedicamentoId { get; set; }

    public string Dosis { get; set; } = null!;

    public string? Frecuencia { get; set; }

    public string? Duracion { get; set; }

    public virtual Receta IdNavigation { get; set; } = null!;

    public virtual Medicamento Medicamento { get; set; } = null!;
}
