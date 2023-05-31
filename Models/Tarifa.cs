using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Tarifa
{
    public int TaCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Nombre")]
    public string? TaNombre { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? TaEstado { get; set; }

    public virtual ICollection<SubTarifa> SubTarifas { get; set; } = new List<SubTarifa>();
}
