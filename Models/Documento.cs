using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Documento
{
    public int DocCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Tipo")]
    public string? DocTipo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Descripción")]
    public string? DocDescripcion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Período")]
    public DateTime? DocPeriodo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? DocEstado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fecha")]
    public DateTime? DocFecha { get; set; }

    public int UsCodigo { get; set; }

    public virtual Usuario UsCodigoNavigation { get; set; } = null!;
}
