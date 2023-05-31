using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Contacto
{
    public int CoCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Nombre")]
    public string? CoNombre { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Apellido")]
    public string? CoApellido { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Empresa")]
    public string? CoEmpresa { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Telefono")]
    public string? CoTelefono { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Direccion")]
    public string? CoDireccion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Pais")]
    public string? CoPais { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Creador")]
    public string? CoCreador { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fecha")]
    public string? CoFecha { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? CoEstado { get; set; }

    public int EmCodigo { get; set; }

    public virtual Empresa EmCodigoNavigation { get; set; } = null!;
}
