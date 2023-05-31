using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class EventosAsunto
{
    public int EvaCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Descripción")]
    public string? EvaDescripcion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Responsable")]
    public string? EvaResponsable { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Observación")]
    public string? EvaObservacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fecha")]
    public string? EvaFecha { get; set; }

    public int AsuCodigo { get; set; }

    public virtual Asunto AsuCodigoNavigation { get; set; } = null!;
}
