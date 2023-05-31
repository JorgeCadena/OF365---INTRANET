using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Asunto
{
    public int AsuCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Título")]
    public string? AsuTitulo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Idioma")]
    public string? AsuIdioma { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Categoria")]
    public string? AsuCategoria { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Área")]
    public string? AsuArea { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Sucursal")]
    public string? AsuSucursal { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Responsable")]
    public string? AsuResponsable { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Descripción")]
    public string? AsuDescripcion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Moneda")]
    public string? AsuMoneda { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Forma de liquidación")]
    public string? AsuFormaLiquidacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Monto")]
    public string? AsuFeeMonto { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Periodicidad")]
    public string? AsuFeePeriodicidad { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Inicio")]
    public string? AsuFeeInicio { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Máximo de Monto")]
    public decimal? AsuMontoMaximo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Máximo de Horas")]
    public int? AsuHorasMaximo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Detalle de Cobranza")]
    public string? AsuDetalleCobranza { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? AsuEstado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Cliente")]
    public string? AsuCliente { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Tarifa")]
    public string? AsuTarifa { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Contacto")]
    public string? AsuNombreSol { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Correo")]
    public string? AsuMailSol { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Dirección")]
    public string? AsuDireccionSol { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Teléfono de Contacto")]
    public string? AsuTelefonoSol { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Cobrable")]
    public string? AsuCobrable { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Descuento")]
    public string? AsuDescuento { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Aplica Impuestos")]
    public string? AsuImpuestos { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Código TM")]
    public string? AsuCodigoSecundario { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Creado por:")]
    public string? AsuCreador { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Cliente")]
    public int CliCodigo { get; set; }

    public virtual Cliente CliCodigoNavigation { get; set; } = null!;

    public virtual ICollection<EventosAsunto> EventosAsuntos { get; set; } = new List<EventosAsunto>();

    public virtual ICollection<Hito> Hitos { get; set; } = new List<Hito>();
}
