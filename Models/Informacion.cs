using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Informacion
{
    public int InfCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Origen")]
    public string? InfOrigen { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Género")]
    public string? InfGenero { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Identificación")]
    public string? InfIdentificacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Etnia")]
    public string? InfEtnia { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Tipo de sangre")]
    public string? InfSangre { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Provincia de residencia")]
    public string? InfProvincia { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Ciudad de residencia")]
    public string? InfCiudad { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Dirección")]
    public string? InfDireccion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Celular")]
    public string? InfTelefono { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Correo personal")]
    public string? InfMail { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado Civil")]
    public string? InfEstadoCivil { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Lugar de Nacimiento")]
    public string? InfLugarNacimiento { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fecha de Nacimiento")]
    public string? InfFechaNacimiento { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Discapacidad")]
    public string? InfDiscapacidad { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Porcentaje de Discapacidad")]
    public int? InfPorcentajeDiscapacidad { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Nombre de Contacto")]
    public string? InfNombreContacto { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Teléfono de Contacto")]
    public string? InfTelefonoContacto { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Parentesco")]
    public string? InfRelacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Observaciones")]
    public string? InfObservaciones { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Migrante Retornado")]
    public string? InfMigranteRetornado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? InfEstado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Foto")]
    public byte[]? InfFoto { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Nombre de Foto")]
    public string? InfNombreFoto { get; set; }

    public int UsCodigo { get; set; }

    public virtual Usuario UsCodigoNavigation { get; set; } = null!;
}
