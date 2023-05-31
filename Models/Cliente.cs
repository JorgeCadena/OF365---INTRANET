using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Cliente
{
    public int CliCodigo { get; set; }


    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Nombre Comercial")]
    public string? CliNombre { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Razón Social")]
    public string? CliRazonSocial { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Tipo de Identificación")]
    public string? CliTipoIdentificacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Identificación")]
    public string? CliIdentificacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Abogado Encargado")]
    public string? CliEncargado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Encargado Comercial")]
    public string? CliComercial { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("¿Aplica impuestos?")]
    public string? CliImpuestos { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Dirección")]
    public string? CliDireccion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Código postal")]
    public string? CliPostal { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("País")]
    public string? CliPais { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Ciudad")]
    public string? CliCiudad { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Teléfono")]
    public string? CliTelefono { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Contacto")]
    public string? CliSolicitante { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Teléfono de contacto")]
    public string? CliTelefonoSol { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Correo")]
    public string? CliMailSol { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Dirección")]
    public string? CliDireccionSol { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Forma de tarificación")]
    public string? CliTarifa { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Descuento")]
    public string? CliDescuento { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? CliEstado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fecha de creación")]
    public string? CliFecha { get; set; }

    [DisplayName("Empresa")]
    public int EmCodigo { get; set; }

    public virtual ICollection<Asunto> Asuntos { get; set; } = new List<Asunto>();

    public virtual ICollection<ContactoFacturacion> ContactoFacturacions { get; set; } = new List<ContactoFacturacion>();

    public virtual Empresa EmCodigoNavigation { get; set; } = null!;
}
