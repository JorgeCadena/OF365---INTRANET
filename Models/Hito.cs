using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Hito
{
    public int HiCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fecha")]
    public string? HiFecha { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Descripcion")]
    public string? HiDescripcion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Valor")]
    public decimal? HiValor { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Observacion")]
    public string? HiObservacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fecha de Recordatorio")]
    public DateTime? HiFechaRecordatorio { get; set; }

    public int AsuCodigo { get; set; }

    public virtual Asunto AsuCodigoNavigation { get; set; } = null!;
}
