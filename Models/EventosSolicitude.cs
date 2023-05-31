using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class EventosSolicitude
{
    public int EvsCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Descripción")]
    public string? EvsDescripcion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Responsable")]
    public string? EvsResponsable { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Observación")]
    public string? EvsObservacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fecha")]
    public string? EvsFecha { get; set; }

    public int SoCodigo { get; set; }

    public virtual Solicitude SoCodigoNavigation { get; set; } = null!;
}
