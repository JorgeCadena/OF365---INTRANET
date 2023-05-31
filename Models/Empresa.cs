using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Empresa
{
    public int EmCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Nombre")]
    public string? EmNombre { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Razón Social")]
    public string? EmRazonSocial { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Ruc")]
    public string? EmRuc { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? EmEstado { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();

    public virtual ICollection<Directorio> Directorios { get; set; } = new List<Directorio>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
