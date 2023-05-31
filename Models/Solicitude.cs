using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace INTRANET_CR.Models;

public partial class Solicitude
{
    public int SoCodigo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Tipo")]
    public string? SoTipo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Otros")]
    public string? SoOtros { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Motivo")]
    public string? SoMotivo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Detalle")]
    public string? SoDetalle { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Préstamo Cantidad")]
    public decimal? SoPrestamoCantidad { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Préstamo Cuotas")]
    public int? SoPrestamoCuotas { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Préstamo Valor")]
    public decimal? SoPrestamoValor { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Permiso desde")]
    public string? SoPermisoDesde { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Permiso hasta")]
    public string? SoPermisoHasta { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Ausencia desde")]
    public string? SoAusenciaDesde { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Ausencia hasta")]
    public string? SoAusenciaHasta { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Ausencia Retorno")]
    public string? SoAusenciaRetorno { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Personal a Cargo")]
    public string? SoPersonalCargo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Personal Cupos")]
    public int? SoPersonalCupos { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Personal Sueldo")]
    public string? SoPersonalSueldo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Personal Contrato")]
    public string? SoPersonalContrato { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Personal de Área")]
    public string? SoPersonalArea { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Personal de Sucursal")]
    public string? SoPersonalSucursal { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Personal Motivo")]
    public string? SoPersonalMotivo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Personal Reemplaza")]
    public string? SoPersonalReemplaza { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Personal Tiempo")]
    public string? SoPersonalTiempo { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Personal Jornada")]
    public string? SoPersonalJornada { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Personal Inicio")]
    public string? SoPersonalInicio { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Personal Observación")]
    public string? SoPersonalObservacion { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Personal Jefe")]
    public string? SoPersonalJefe { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Estado")]
    public string? SoEstado { get; set; }

    [Required(ErrorMessage = "El campo es obligatorio.")]
    [DisplayName("Fecha")]
    public DateTime? SoFecha { get; set; }

    public int UsCodigo { get; set; }

    public virtual ICollection<EventosSolicitude> EventosSolicitudes { get; set; } = new List<EventosSolicitude>();

    public virtual Usuario UsCodigoNavigation { get; set; } = null!;
}
