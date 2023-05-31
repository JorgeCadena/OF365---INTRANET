using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Ticket
{
    public int TicCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Título")]
    public string? TicTitulo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Descripción")]
    public string? TicDescripcion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Tipo")]
    public string? TicTipo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Prioridad")]
    public string? TicPrioridad { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Técnico")]
    public string? TicTecnico { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Usuario")]
    public string? TicUsuario { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Calificación")]
    public int? TicCalificacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Inicio")]
    public string? TicInicio { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Tiempo")]
    public string? TicTiempo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? TicEstado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fin")]
    public string? TicFin { get; set; }

    public int UsCodigo { get; set; }

    public virtual ICollection<EventosTicket> EventosTickets { get; set; } = new List<EventosTicket>();

    public virtual Usuario UsCodigoNavigation { get; set; } = null!;
}
