using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class EventosTicket
{
    public int EvtCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Descripción")]
    public string? EvtDescripcion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Responsable")]
    public string? EvtResponsable { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Observación")]
    public string? EvtObservacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fecha")]
    public string? EvtFecha { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Usuario")]
    public string? EvtUsuario { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Empresa")]
    public string? EvtEmpresa { get; set; }

    public int? EvtUsCod { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Usuario")]
    public string? Id { get; set; }

    public int TicCodigo { get; set; }

    public virtual Ticket TicCodigoNavigation { get; set; } = null!;
}
