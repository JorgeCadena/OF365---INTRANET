using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Familiare
{
    public int FaCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Identificación")]
    public string? FaIdentificacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Nombres")]
    public string? FaNombres { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Relación")]
    public string? FaRelacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Nacimiento")]
    public string? FaNacimiento { get; set; }

    public int UsCodigo { get; set; }

    public virtual Usuario UsCodigoNavigation { get; set; } = null!;
}
