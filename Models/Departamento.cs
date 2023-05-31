using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Departamento
{
    public int DeCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Nombre")]
    public string? DeNombre { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Correo")]
    public string? DeMail { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Sucursal")]
    public string? DeSucursal { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? DeEstado { get; set; }

    public int EmCodigo { get; set; }

    public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();

    public virtual Empresa EmCodigoNavigation { get; set; } = null!;
}
