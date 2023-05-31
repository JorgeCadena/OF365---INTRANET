using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Experiencium
{
    public int ExCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Empresa")]
    public string? ExEmpresa { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Dirección")]
    public string? ExDireccion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Teléfono")]
    public string? ExTelefono { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Cargo Inicial")]
    public string? ExCargoinicial { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Sueldo Inicial")]
    public decimal? ExSueldoinicial { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Cargo Final")]
    public string? ExCargofinal { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Sueldo Final")]
    public decimal? ExSueldofinal { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Motivo de Renuncia")]
    public string? ExMotivorenuncia { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? ExEstado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Descripción")]
    public string? ExDescripcion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Tiempo")]
    public string? ExTiempo { get; set; }

    public int UsCodigo { get; set; }

    public virtual Usuario UsCodigoNavigation { get; set; } = null!;
}
