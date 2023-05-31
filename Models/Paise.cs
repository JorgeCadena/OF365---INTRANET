using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Paise
{
    public int PaCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Pre")]
    public string? PaPre { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Nombre")]
    public string? PaNombre { get; set; }
}
