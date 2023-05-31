using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Contrato
{
    public int CoCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Tipo")]
    public string? CoTipo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Inicio")]
    public DateTime? CoInicio { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fin")]
    public DateTime? CoFin { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Sueldo")]
    public decimal? CoSueldo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Bono")]
    public decimal? CoBono { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Motivo de Salida")]
    public string? CoMotivoSalida { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Liquidacion")]
    public decimal? CoLiquidacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Observacion")]
    public string? CoObservacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? CoEstado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Ubicacion")]
    public string? CoUbicacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Extension")]
    public string? CoExtension { get; set; }

    public int UsCodigo { get; set; }

    public virtual Usuario UsCodigoNavigation { get; set; } = null!;
}
