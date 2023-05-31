using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Referencia
{
    public int ReCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Empresa")]
    public string? ReEmpresa { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Cargo")]
    public string? ReCargo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Nombre")]
    public string? ReNombre { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Dirección")]
    public string? ReDireccion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Teléfono")]
    public string? ReTelefono { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Correo")]
    public string? ReMail { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Tipo")]
    public string? ReTipo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Relación")]
    public string? ReRelacion { get; set; }

    public int UsCodigo { get; set; }

    public virtual Usuario UsCodigoNavigation { get; set; } = null!;
}
