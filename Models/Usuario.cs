using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace INTRANET_CR.Models;

public partial class Usuario
{
    public int UsCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(100)]
    [DisplayName("Primer nombre")]
    public string? UsNombre1 { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(100)]
    [DisplayName("Segundo nombre")]
    public string? UsNombre2 { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(100)]
    [DisplayName("Otro nombre")]
    public string? UsNombre3 { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(100)]
    [DisplayName("Primer apellido")]
    public string? UsApellido1 { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(100)]
    [DisplayName("Segundo apellido")]
    public string? UsApellido2 { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]   
    [DisplayName("Estado")]
    public string? UsEstado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Configuración ")]
    public string? UsActivo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(300)]
    [DisplayName("Jefe directo")]
    public string? UsJefe { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(300)]
    [DisplayName("Gerencia")]
    public string? UsGerencia { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [StringLength(50)]
    [DisplayName("Cambio de contraseña")]
    public string? UsCambio { get; set; }

    [Required(ErrorMessage = "Es obligatorio aceptar términos y condiciones.")]
    [DisplayName("Acepta términos?")]
    public string? UsTerminos { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Key")]
    public string? UsId { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Rol")]
    public string? UsRol { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Adicional")]
    public string? UsAdicional { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Correo empresarial")]
    public string? UsCorreo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Empresa")]
    public int EmCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Usuario")]
    public string? Id { get; set; } = null!;

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();

    public virtual ICollection<Educacion> Educacions { get; set; } = new List<Educacion>();

    public virtual Empresa EmCodigoNavigation { get; set; } = null!;

    public virtual ICollection<Experiencium> Experiencia { get; set; } = new List<Experiencium>();

    public virtual ICollection<Familiare> Familiares { get; set; } = new List<Familiare>();

    public virtual ICollection<Informacion> Informacions { get; set; } = new List<Informacion>();

    public virtual ICollection<Referencia> Referencia { get; set; } = new List<Referencia>();

    public virtual ICollection<Solicitude> Solicitudes { get; set; } = new List<Solicitude>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    internal Task<string> ToListAsync()
    {
        throw new NotImplementedException();
    }
}
