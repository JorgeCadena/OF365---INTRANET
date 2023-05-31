using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Educacion
{
    public int EdCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Tipo")]
    public string? EdTipo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Nivel")]
    public string? EdNivel { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Plantel")]
    public string? EdPlantel { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Ciudad")]
    public string? EdCiudad { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Inicio")]
    public DateTime? EdInicio { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fin")]
    public DateTime? EdFin { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Título")]
    public string? EdTitulo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Finalizado")]
    public string? EdFinalizado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Descripción")]
    public string? EdDescripcion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? EdEstado { get; set; }

    public int UsCodigo { get; set; }

    public virtual Usuario UsCodigoNavigation { get; set; } = null!;
}
