using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Directorio
{
    public int DirCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Cliente")]
    public string? DirCliente { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Area")]
    public string? DirArea { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Industria")]
    public string? DirIndustria { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Detalle")]
    public string? DirDetalle { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Costo")]
    public string? DirCosto { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Involucrados")]
    public string? DirInvolucrados { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Encargados")]
    public string? DirEncargados { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Miembros")]
    public string? DirMiembros { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Otros")]
    public string? DirOtros { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Inicio")]
    public string? DirInicio { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fin")]
    public string? DirFin { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Adicional")]
    public string? DirAdicional { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Creado")]
    public string? DirCreado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Modificado")]
    public string? DirModificado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Revisado")]
    public string? DirRevisado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Confidencial")]
    public string? DirConfidencial { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Descripcion")]
    public string? DirDescripcion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fecha de Ingreso")]
    public string? DirFechaIngreso { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Número de Caso")]
    public string? DirNumeroCaso { get; set; }

    public int EmCodigo { get; set; }

    public virtual Empresa EmCodigoNavigation { get; set; } = null!;
}
