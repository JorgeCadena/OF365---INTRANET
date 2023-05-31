using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class SubTarifa
{
    public int SutCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Categoría")]
    public string? SutCategoria { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Tarifa")]
    public decimal? SutTarifa { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Moneda")]
    public string? SutMoneda { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? SutEstado { get; set; }

    public int TaCodigo { get; set; }

    public virtual Tarifa TaCodigoNavigation { get; set; } = null!;
}
