using System;
using System.Collections.Generic;

namespace MyDoc.Models;

public partial class Consultorio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual ICollection<ConsultorioMedico> ConsultorioMedicos { get; set; } = new List<ConsultorioMedico>();
}
