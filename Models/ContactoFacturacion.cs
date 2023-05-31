using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class ContactoFacturacion
{
    public int CofCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Nombre")]
    public string? CofNombre { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Telefono")]
    public string? CofTelefono { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Correo")]
    public string? CofMail { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Direccion")]
    public string? CofDireccion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? CofEstado { get; set; }

    public int CliCodigo { get; set; }

    public virtual Cliente CliCodigoNavigation { get; set; } = null!;
}
