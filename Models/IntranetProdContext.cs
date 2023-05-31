using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace INTRANET_CR.Models;

public partial class IntranetProdContext : DbContext
{
    public IntranetProdContext()
    {
    }

    public IntranetProdContext(DbContextOptions<IntranetProdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Asunto> Asuntos { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<ContactoFacturacion> ContactoFacturacions { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Directorio> Directorios { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Educacion> Educacions { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<EventosAsunto> EventosAsuntos { get; set; }

    public virtual DbSet<EventosSolicitude> EventosSolicitudes { get; set; }

    public virtual DbSet<EventosTicket> EventosTickets { get; set; }

    public virtual DbSet<Experiencium> Experiencia { get; set; }

    public virtual DbSet<Familiare> Familiares { get; set; }

    public virtual DbSet<Hito> Hitos { get; set; }

    public virtual DbSet<Informacion> Informacions { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Referencia> Referencias { get; set; }

    public virtual DbSet<Solicitude> Solicitudes { get; set; }

    public virtual DbSet<SubTarifa> SubTarifas { get; set; }

    public virtual DbSet<Tarifa> Tarifas { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=intranetcr.database.windows.net; Database=INTRANET-PROD; User Id=sacr; password=Xypxa7jeca.; Trusted_Connection=False; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.ArCodigo);

            entity.Property(e => e.ArCodigo).HasColumnName("Ar_Codigo");
            entity.Property(e => e.ArEstado)
                .HasMaxLength(50)
                .HasColumnName("Ar_Estado");
            entity.Property(e => e.ArNombre)
                .HasMaxLength(250)
                .HasColumnName("Ar_Nombre");
        });

        modelBuilder.Entity<Asunto>(entity =>
        {
            entity.HasKey(e => e.AsuCodigo).HasName("Key4");

            entity.Property(e => e.AsuCodigo).HasColumnName("Asu_Codigo");
            entity.Property(e => e.AsuArea)
                .HasMaxLength(100)
                .HasColumnName("Asu_Area");
            entity.Property(e => e.AsuCategoria)
                .HasMaxLength(100)
                .HasColumnName("Asu_Categoria");
            entity.Property(e => e.AsuCliente)
                .HasMaxLength(300)
                .HasColumnName("Asu_Cliente");
            entity.Property(e => e.AsuCobrable)
                .HasMaxLength(50)
                .HasColumnName("Asu_Cobrable");
            entity.Property(e => e.AsuCodigoSecundario)
                .HasMaxLength(50)
                .HasColumnName("Asu_CodigoSecundario");
            entity.Property(e => e.AsuCreador)
                .HasMaxLength(200)
                .HasColumnName("Asu_Creador");
            entity.Property(e => e.AsuDescripcion)
                .HasMaxLength(1000)
                .HasColumnName("Asu_Descripcion");
            entity.Property(e => e.AsuDescuento)
                .HasMaxLength(50)
                .HasColumnName("Asu_Descuento");
            entity.Property(e => e.AsuDetalleCobranza)
                .HasMaxLength(500)
                .HasColumnName("Asu_DetalleCobranza");
            entity.Property(e => e.AsuDireccionSol)
                .HasMaxLength(300)
                .HasColumnName("Asu_DireccionSol");
            entity.Property(e => e.AsuEstado)
                .HasMaxLength(50)
                .HasColumnName("Asu_Estado");
            entity.Property(e => e.AsuFeeInicio)
                .HasMaxLength(100)
                .HasColumnName("Asu_FeeInicio");
            entity.Property(e => e.AsuFeeMonto)
                .HasMaxLength(14)
                .HasColumnName("Asu_FeeMonto");
            entity.Property(e => e.AsuFeePeriodicidad)
                .HasMaxLength(50)
                .HasColumnName("Asu_FeePeriodicidad");
            entity.Property(e => e.AsuFormaLiquidacion)
                .HasMaxLength(100)
                .HasColumnName("Asu_FormaLiquidacion");
            entity.Property(e => e.AsuHorasMaximo).HasColumnName("Asu_HorasMaximo");
            entity.Property(e => e.AsuIdioma)
                .HasMaxLength(50)
                .HasColumnName("Asu_Idioma");
            entity.Property(e => e.AsuImpuestos)
                .HasMaxLength(50)
                .HasColumnName("Asu_Impuestos");
            entity.Property(e => e.AsuMailSol)
                .HasMaxLength(300)
                .HasColumnName("Asu_MailSol");
            entity.Property(e => e.AsuMoneda)
                .HasMaxLength(50)
                .HasColumnName("Asu_Moneda");
            entity.Property(e => e.AsuMontoMaximo)
                .HasColumnType("numeric(14, 2)")
                .HasColumnName("Asu_MontoMaximo");
            entity.Property(e => e.AsuNombreSol)
                .HasMaxLength(300)
                .HasColumnName("Asu_NombreSol");
            entity.Property(e => e.AsuResponsable)
                .HasMaxLength(100)
                .HasColumnName("Asu_Responsable");
            entity.Property(e => e.AsuSucursal)
                .HasMaxLength(100)
                .HasColumnName("Asu_Sucursal");
            entity.Property(e => e.AsuTarifa)
                .HasMaxLength(100)
                .HasColumnName("Asu_Tarifa");
            entity.Property(e => e.AsuTelefonoSol)
                .HasMaxLength(50)
                .HasColumnName("Asu_TelefonoSol");
            entity.Property(e => e.AsuTitulo)
                .HasMaxLength(500)
                .HasColumnName("Asu_Titulo");
            entity.Property(e => e.CliCodigo).HasColumnName("Cli_Codigo");

            entity.HasOne(d => d.CliCodigoNavigation).WithMany(p => p.Asuntos)
                .HasForeignKey(d => d.CliCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Clientes_Asuntos");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.CaCodigo).HasName("PK_Puesto");

            entity.Property(e => e.CaCodigo).HasColumnName("Ca_Codigo");
            entity.Property(e => e.CaEstado)
                .HasMaxLength(50)
                .HasColumnName("Ca_Estado");
            entity.Property(e => e.CaNombre)
                .HasMaxLength(200)
                .HasColumnName("Ca_Nombre");
            entity.Property(e => e.DeCodigo).HasColumnName("De_Codigo");

            entity.HasOne(d => d.DeCodigoNavigation).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.DeCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Departamentos_Cargos");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CaCodigo);

            entity.Property(e => e.CaCodigo).HasColumnName("Ca_Codigo");
            entity.Property(e => e.CaEstado)
                .HasMaxLength(50)
                .HasColumnName("Ca_Estado");
            entity.Property(e => e.CaNombre)
                .HasMaxLength(250)
                .HasColumnName("Ca_Nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CliCodigo).HasName("Key3");

            entity.Property(e => e.CliCodigo).HasColumnName("Cli_Codigo");
            entity.Property(e => e.CliCiudad)
                .HasMaxLength(255)
                .HasColumnName("Cli_Ciudad");
            entity.Property(e => e.CliComercial)
                .HasMaxLength(255)
                .HasColumnName("Cli_Comercial");
            entity.Property(e => e.CliDescuento)
                .HasMaxLength(255)
                .HasColumnName("Cli_Descuento");
            entity.Property(e => e.CliDireccion)
                .HasMaxLength(255)
                .HasColumnName("Cli_Direccion");
            entity.Property(e => e.CliDireccionSol)
                .HasMaxLength(255)
                .HasColumnName("Cli_DireccionSol");
            entity.Property(e => e.CliEncargado)
                .HasMaxLength(255)
                .HasColumnName("Cli_Encargado");
            entity.Property(e => e.CliEstado)
                .HasMaxLength(100)
                .HasColumnName("Cli_Estado");
            entity.Property(e => e.CliFecha)
                .HasMaxLength(100)
                .HasColumnName("Cli_Fecha");
            entity.Property(e => e.CliIdentificacion)
                .HasMaxLength(255)
                .HasColumnName("Cli_Identificacion");
            entity.Property(e => e.CliImpuestos)
                .HasMaxLength(255)
                .HasColumnName("Cli_Impuestos");
            entity.Property(e => e.CliMailSol)
                .HasMaxLength(255)
                .HasColumnName("Cli_MailSol");
            entity.Property(e => e.CliNombre)
                .HasMaxLength(500)
                .HasColumnName("Cli_Nombre");
            entity.Property(e => e.CliPais)
                .HasMaxLength(255)
                .HasColumnName("Cli_Pais");
            entity.Property(e => e.CliPostal)
                .HasMaxLength(255)
                .HasColumnName("Cli_Postal");
            entity.Property(e => e.CliRazonSocial)
                .HasMaxLength(255)
                .HasColumnName("Cli_RazonSocial");
            entity.Property(e => e.CliSolicitante)
                .HasMaxLength(255)
                .HasColumnName("Cli_Solicitante");
            entity.Property(e => e.CliTarifa)
                .HasMaxLength(255)
                .HasColumnName("Cli_Tarifa");
            entity.Property(e => e.CliTelefono)
                .HasMaxLength(255)
                .HasColumnName("Cli_Telefono");
            entity.Property(e => e.CliTelefonoSol)
                .HasMaxLength(255)
                .HasColumnName("Cli_TelefonoSol");
            entity.Property(e => e.CliTipoIdentificacion)
                .HasMaxLength(255)
                .HasColumnName("Cli_TipoIdentificacion");
            entity.Property(e => e.EmCodigo).HasColumnName("Em_Codigo");

            entity.HasOne(d => d.EmCodigoNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.EmCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Empresas_Clientes");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.CoCodigo);

            entity.Property(e => e.CoCodigo).HasColumnName("Co_Codigo");
            entity.Property(e => e.CoApellido)
                .HasMaxLength(200)
                .HasColumnName("Co_Apellido");
            entity.Property(e => e.CoCreador)
                .HasMaxLength(100)
                .HasColumnName("Co_Creador");
            entity.Property(e => e.CoDireccion)
                .HasMaxLength(300)
                .HasColumnName("Co_Direccion");
            entity.Property(e => e.CoEmpresa)
                .HasMaxLength(200)
                .HasColumnName("Co_Empresa");
            entity.Property(e => e.CoEstado)
                .HasMaxLength(50)
                .HasColumnName("Co_Estado");
            entity.Property(e => e.CoFecha)
                .HasMaxLength(50)
                .HasColumnName("Co_Fecha");
            entity.Property(e => e.CoNombre)
                .HasMaxLength(200)
                .HasColumnName("Co_Nombre");
            entity.Property(e => e.CoPais)
                .HasMaxLength(100)
                .HasColumnName("Co_Pais");
            entity.Property(e => e.CoTelefono)
                .HasMaxLength(50)
                .HasColumnName("Co_Telefono");
            entity.Property(e => e.EmCodigo).HasColumnName("Em_Codigo");

            entity.HasOne(d => d.EmCodigoNavigation).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.EmCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Empresas_Contactos");
        });

        modelBuilder.Entity<ContactoFacturacion>(entity =>
        {
            entity.HasKey(e => e.CofCodigo).HasName("PK_n");

            entity.ToTable("ContactoFacturacion");

            entity.Property(e => e.CofCodigo).HasColumnName("Cof_Codigo");
            entity.Property(e => e.CliCodigo).HasColumnName("Cli_Codigo");
            entity.Property(e => e.CofDireccion)
                .HasMaxLength(500)
                .HasColumnName("Cof_Direccion");
            entity.Property(e => e.CofEstado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Cof_Estado");
            entity.Property(e => e.CofMail)
                .HasMaxLength(500)
                .HasColumnName("Cof_Mail");
            entity.Property(e => e.CofNombre)
                .HasMaxLength(250)
                .HasColumnName("Cof_Nombre");
            entity.Property(e => e.CofTelefono)
                .HasMaxLength(100)
                .HasColumnName("Cof_Telefono");

            entity.HasOne(d => d.CliCodigoNavigation).WithMany(p => p.ContactoFacturacions)
                .HasForeignKey(d => d.CliCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Cliente_Contacto");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.CoCodigo);

            entity.Property(e => e.CoCodigo).HasColumnName("Co_Codigo");
            entity.Property(e => e.CoBono)
                .HasColumnType("numeric(14, 2)")
                .HasColumnName("Co_Bono");
            entity.Property(e => e.CoEstado)
                .HasMaxLength(50)
                .HasColumnName("Co_Estado");
            entity.Property(e => e.CoExtension)
                .HasMaxLength(100)
                .HasColumnName("Co_Extension");
            entity.Property(e => e.CoFin)
                .HasMaxLength(100)
                .HasColumnName("Co_Fin");
            entity.Property(e => e.CoInicio)
                .HasMaxLength(100)
                .HasColumnName("Co_Inicio");
            entity.Property(e => e.CoLiquidacion)
                .HasColumnType("numeric(14, 2)")
                .HasColumnName("Co_Liquidacion");
            entity.Property(e => e.CoMotivoSalida)
                .HasMaxLength(300)
                .HasColumnName("Co_MotivoSalida");
            entity.Property(e => e.CoObservacion)
                .HasMaxLength(300)
                .HasColumnName("Co_Observacion");
            entity.Property(e => e.CoSueldo)
                .HasColumnType("numeric(14, 2)")
                .HasColumnName("Co_Sueldo");
            entity.Property(e => e.CoTipo)
                .HasMaxLength(100)
                .HasColumnName("Co_Tipo");
            entity.Property(e => e.CoUbicacion)
                .HasMaxLength(100)
                .HasColumnName("Co_Ubicacion");
            entity.Property(e => e.UsCodigo).HasColumnName("Us_Codigo");

            entity.HasOne(d => d.UsCodigoNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.UsCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuarios_Contratos");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CuCodigo);

            entity.Property(e => e.CuCodigo).HasColumnName("Cu_Codigo");
            entity.Property(e => e.CuDescripcion)
                .HasMaxLength(500)
                .HasColumnName("Cu_Descripcion");
            entity.Property(e => e.CuEstado)
                .HasMaxLength(50)
                .HasColumnName("Cu_Estado");
            entity.Property(e => e.CuNombre)
                .HasMaxLength(300)
                .HasColumnName("Cu_Nombre");
            entity.Property(e => e.UsCodigo).HasColumnName("Us_Codigo");

            entity.HasOne(d => d.UsCodigoNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.UsCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuarios_Cursos");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.DeCodigo).HasName("Key7");

            entity.Property(e => e.DeCodigo).HasColumnName("De_Codigo");
            entity.Property(e => e.DeEstado)
                .HasMaxLength(50)
                .HasColumnName("De_Estado");
            entity.Property(e => e.DeMail)
                .HasMaxLength(100)
                .HasColumnName("De_Mail");
            entity.Property(e => e.DeNombre)
                .HasMaxLength(100)
                .HasColumnName("De_Nombre");
            entity.Property(e => e.DeSucursal)
                .HasMaxLength(100)
                .HasColumnName("De_Sucursal");
            entity.Property(e => e.EmCodigo).HasColumnName("Em_Codigo");

            entity.HasOne(d => d.EmCodigoNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.EmCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Empresas_Departamentos");
        });

        modelBuilder.Entity<Directorio>(entity =>
        {
            entity.HasKey(e => e.DirCodigo);

            entity.Property(e => e.DirCodigo).HasColumnName("Dir_Codigo");
            entity.Property(e => e.DirAdicional)
                .HasMaxLength(2000)
                .HasColumnName("Dir_Adicional");
            entity.Property(e => e.DirArea)
                .HasMaxLength(100)
                .HasColumnName("Dir_Area");
            entity.Property(e => e.DirCliente)
                .HasMaxLength(1000)
                .HasColumnName("Dir_Cliente");
            entity.Property(e => e.DirConfidencial)
                .HasMaxLength(50)
                .HasColumnName("Dir_Confidencial");
            entity.Property(e => e.DirCosto)
                .HasMaxLength(200)
                .HasColumnName("Dir_Costo");
            entity.Property(e => e.DirCreado)
                .HasMaxLength(100)
                .HasColumnName("Dir_Creado");
            entity.Property(e => e.DirDescripcion)
                .HasMaxLength(4000)
                .HasColumnName("Dir_Descripcion");
            entity.Property(e => e.DirDetalle)
                .HasMaxLength(2000)
                .HasColumnName("Dir_Detalle");
            entity.Property(e => e.DirEncargados)
                .HasMaxLength(1000)
                .HasColumnName("Dir_Encargados");
            entity.Property(e => e.DirFechaIngreso)
                .HasMaxLength(50)
                .HasColumnName("Dir_FechaIngreso");
            entity.Property(e => e.DirFin)
                .HasMaxLength(100)
                .HasColumnName("Dir_Fin");
            entity.Property(e => e.DirIndustria)
                .HasMaxLength(500)
                .HasColumnName("Dir_Industria");
            entity.Property(e => e.DirInicio)
                .HasMaxLength(100)
                .HasColumnName("Dir_Inicio");
            entity.Property(e => e.DirInvolucrados)
                .HasMaxLength(1000)
                .HasColumnName("Dir_Involucrados");
            entity.Property(e => e.DirMiembros)
                .HasMaxLength(1000)
                .HasColumnName("Dir_Miembros");
            entity.Property(e => e.DirModificado)
                .HasMaxLength(100)
                .HasColumnName("Dir_Modificado");
            entity.Property(e => e.DirNumeroCaso)
                .HasMaxLength(200)
                .HasColumnName("Dir_NumeroCaso");
            entity.Property(e => e.DirOtros)
                .HasMaxLength(1000)
                .HasColumnName("Dir_Otros");
            entity.Property(e => e.DirRevisado)
                .HasMaxLength(100)
                .HasColumnName("Dir_Revisado");
            entity.Property(e => e.EmCodigo).HasColumnName("Em_Codigo");

            entity.HasOne(d => d.EmCodigoNavigation).WithMany(p => p.Directorios)
                .HasForeignKey(d => d.EmCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Empresas_Directorios");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.DocCodigo).HasName("Key18");

            entity.Property(e => e.DocCodigo).HasColumnName("Doc_Codigo");
            entity.Property(e => e.DocDescripcion)
                .HasMaxLength(100)
                .HasColumnName("Doc_Descripcion");
            entity.Property(e => e.DocEstado)
                .HasMaxLength(50)
                .HasColumnName("Doc_Estado");
            entity.Property(e => e.DocFecha)
                .HasColumnType("datetime")
                .HasColumnName("Doc_Fecha");
            entity.Property(e => e.DocPeriodo)
                .HasMaxLength(100)
                .HasColumnName("Doc_Periodo");
            entity.Property(e => e.DocTipo)
                .HasMaxLength(100)
                .HasColumnName("Doc_Tipo");
            entity.Property(e => e.UsCodigo).HasColumnName("Us_Codigo");

            entity.HasOne(d => d.UsCodigoNavigation).WithMany(p => p.Documentos)
                .HasForeignKey(d => d.UsCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuarios_Documentos");
        });

        modelBuilder.Entity<Educacion>(entity =>
        {
            entity.HasKey(e => e.EdCodigo).HasName("Key12");

            entity.ToTable("Educacion");

            entity.Property(e => e.EdCodigo).HasColumnName("Ed_Codigo");
            entity.Property(e => e.EdCiudad)
                .HasMaxLength(100)
                .HasColumnName("Ed_Ciudad");
            entity.Property(e => e.EdDescripcion)
                .HasMaxLength(300)
                .HasColumnName("Ed_Descripcion");
            entity.Property(e => e.EdEstado)
                .HasMaxLength(50)
                .HasColumnName("Ed_Estado");
            entity.Property(e => e.EdFin)
                .HasColumnType("date")
                .HasColumnName("Ed_Fin");
            entity.Property(e => e.EdFinalizado)
                .HasMaxLength(50)
                .HasColumnName("Ed_Finalizado");
            entity.Property(e => e.EdInicio)
                .HasColumnType("date")
                .HasColumnName("Ed_Inicio");
            entity.Property(e => e.EdNivel)
                .HasMaxLength(100)
                .HasColumnName("Ed_Nivel");
            entity.Property(e => e.EdPlantel)
                .HasMaxLength(300)
                .HasColumnName("Ed_Plantel");
            entity.Property(e => e.EdTipo)
                .HasMaxLength(50)
                .HasColumnName("Ed_Tipo");
            entity.Property(e => e.EdTitulo)
                .HasMaxLength(250)
                .HasColumnName("Ed_Titulo");
            entity.Property(e => e.UsCodigo).HasColumnName("Us_Codigo");

            entity.HasOne(d => d.UsCodigoNavigation).WithMany(p => p.Educacions)
                .HasForeignKey(d => d.UsCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuarios_Educacion");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.EmCodigo).HasName("Key5");

            entity.Property(e => e.EmCodigo).HasColumnName("Em_Codigo");
            entity.Property(e => e.EmEstado)
                .HasMaxLength(50)
                .HasColumnName("Em_Estado");
            entity.Property(e => e.EmNombre)
                .HasMaxLength(500)
                .HasColumnName("Em_Nombre");
            entity.Property(e => e.EmRazonSocial)
                .HasMaxLength(500)
                .HasColumnName("Em_RazonSocial");
            entity.Property(e => e.EmRuc)
                .HasMaxLength(20)
                .HasColumnName("Em_Ruc");
        });

        modelBuilder.Entity<EventosAsunto>(entity =>
        {
            entity.HasKey(e => e.EvaCodigo);

            entity.ToTable("Eventos_Asuntos");

            entity.Property(e => e.EvaCodigo).HasColumnName("Eva_Codigo");
            entity.Property(e => e.AsuCodigo).HasColumnName("Asu_Codigo");
            entity.Property(e => e.EvaDescripcion)
                .HasMaxLength(200)
                .HasColumnName("Eva_Descripcion");
            entity.Property(e => e.EvaFecha)
                .HasMaxLength(100)
                .HasColumnName("Eva_Fecha");
            entity.Property(e => e.EvaObservacion)
                .HasMaxLength(1000)
                .HasColumnName("Eva_Observacion");
            entity.Property(e => e.EvaResponsable)
                .HasMaxLength(200)
                .HasColumnName("Eva_Responsable");

            entity.HasOne(d => d.AsuCodigoNavigation).WithMany(p => p.EventosAsuntos)
                .HasForeignKey(d => d.AsuCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Asuntos_Eventos");
        });

        modelBuilder.Entity<EventosSolicitude>(entity =>
        {
            entity.HasKey(e => e.EvsCodigo);

            entity.ToTable("Eventos_Solicitudes");

            entity.Property(e => e.EvsCodigo).HasColumnName("Evs_Codigo");
            entity.Property(e => e.EvsDescripcion)
                .HasMaxLength(200)
                .HasColumnName("Evs_Descripcion");
            entity.Property(e => e.EvsFecha)
                .HasMaxLength(100)
                .HasColumnName("Evs_Fecha");
            entity.Property(e => e.EvsObservacion)
                .HasMaxLength(1000)
                .HasColumnName("Evs_Observacion");
            entity.Property(e => e.EvsResponsable)
                .HasMaxLength(200)
                .HasColumnName("Evs_Responsable");
            entity.Property(e => e.SoCodigo).HasColumnName("So_Codigo");

            entity.HasOne(d => d.SoCodigoNavigation).WithMany(p => p.EventosSolicitudes)
                .HasForeignKey(d => d.SoCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Solicitudes_Eventos");
        });

        modelBuilder.Entity<EventosTicket>(entity =>
        {
            entity.HasKey(e => e.EvtCodigo);

            entity.ToTable("Eventos_Tickets");

            entity.Property(e => e.EvtCodigo).HasColumnName("Evt_Codigo");
            entity.Property(e => e.EvtDescripcion)
                .HasMaxLength(200)
                .HasColumnName("Evt_Descripcion");
            entity.Property(e => e.EvtEmpresa)
                .HasMaxLength(100)
                .HasColumnName("Evt_Empresa");
            entity.Property(e => e.EvtFecha)
                .HasMaxLength(100)
                .HasColumnName("Evt_Fecha");
            entity.Property(e => e.EvtObservacion)
                .HasMaxLength(1000)
                .HasColumnName("Evt_Observacion");
            entity.Property(e => e.EvtResponsable)
                .HasMaxLength(200)
                .HasColumnName("Evt_Responsable");
            entity.Property(e => e.EvtUsCod).HasColumnName("Evt_UsCod");
            entity.Property(e => e.EvtUsuario)
                .HasMaxLength(100)
                .HasColumnName("Evt_Usuario");
            entity.Property(e => e.Id).HasMaxLength(450);
            entity.Property(e => e.TicCodigo).HasColumnName("Tic_Codigo");

            entity.HasOne(d => d.TicCodigoNavigation).WithMany(p => p.EventosTickets)
                .HasForeignKey(d => d.TicCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tickets_Eventos");
        });

        modelBuilder.Entity<Experiencium>(entity =>
        {
            entity.HasKey(e => e.ExCodigo).HasName("Key13");

            entity.Property(e => e.ExCodigo).HasColumnName("Ex_Codigo");
            entity.Property(e => e.ExCargofinal)
                .HasMaxLength(150)
                .HasColumnName("Ex_Cargofinal");
            entity.Property(e => e.ExCargoinicial)
                .HasMaxLength(150)
                .HasColumnName("Ex_Cargoinicial");
            entity.Property(e => e.ExDescripcion)
                .HasMaxLength(300)
                .HasColumnName("Ex_Descripcion");
            entity.Property(e => e.ExDireccion)
                .HasMaxLength(300)
                .HasColumnName("Ex_Direccion");
            entity.Property(e => e.ExEmpresa)
                .HasMaxLength(200)
                .HasColumnName("Ex_Empresa");
            entity.Property(e => e.ExEstado)
                .HasMaxLength(50)
                .HasColumnName("Ex_Estado");
            entity.Property(e => e.ExMotivorenuncia)
                .HasMaxLength(300)
                .HasColumnName("Ex_Motivorenuncia");
            entity.Property(e => e.ExSueldofinal)
                .HasColumnType("numeric(14, 2)")
                .HasColumnName("Ex_Sueldofinal");
            entity.Property(e => e.ExSueldoinicial)
                .HasColumnType("numeric(14, 2)")
                .HasColumnName("Ex_Sueldoinicial");
            entity.Property(e => e.ExTelefono)
                .HasMaxLength(20)
                .HasColumnName("Ex_Telefono");
            entity.Property(e => e.ExTiempo)
                .HasMaxLength(50)
                .HasColumnName("Ex_Tiempo");
            entity.Property(e => e.UsCodigo).HasColumnName("Us_Codigo");

            entity.HasOne(d => d.UsCodigoNavigation).WithMany(p => p.Experiencia)
                .HasForeignKey(d => d.UsCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuarios_Experiencia");
        });

        modelBuilder.Entity<Familiare>(entity =>
        {
            entity.HasKey(e => e.FaCodigo).HasName("Key55");

            entity.Property(e => e.FaCodigo).HasColumnName("Fa_Codigo");
            entity.Property(e => e.FaIdentificacion)
                .HasMaxLength(15)
                .HasColumnName("Fa_Identificacion");
            entity.Property(e => e.FaNacimiento)
                .HasMaxLength(50)
                .HasColumnName("Fa_Nacimiento");
            entity.Property(e => e.FaNombres)
                .HasMaxLength(300)
                .HasColumnName("Fa_Nombres");
            entity.Property(e => e.FaRelacion)
                .HasMaxLength(150)
                .HasColumnName("Fa_Relacion");
            entity.Property(e => e.UsCodigo).HasColumnName("Us_Codigo");

            entity.HasOne(d => d.UsCodigoNavigation).WithMany(p => p.Familiares)
                .HasForeignKey(d => d.UsCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuarios_Familiares");
        });

        modelBuilder.Entity<Hito>(entity =>
        {
            entity.HasKey(e => e.HiCodigo).HasName("Key6");

            entity.Property(e => e.HiCodigo).HasColumnName("Hi_Codigo");
            entity.Property(e => e.AsuCodigo).HasColumnName("Asu_Codigo");
            entity.Property(e => e.HiDescripcion)
                .HasMaxLength(2000)
                .HasColumnName("Hi_Descripcion");
            entity.Property(e => e.HiFecha)
                .HasMaxLength(100)
                .HasColumnName("Hi_Fecha");
            entity.Property(e => e.HiFechaRecordatorio)
                .HasMaxLength(100)
                .HasColumnName("Hi_FechaRecordatorio");
            entity.Property(e => e.HiObservacion)
                .HasMaxLength(2000)
                .HasColumnName("Hi_Observacion");
            entity.Property(e => e.HiValor)
                .HasColumnType("numeric(14, 2)")
                .HasColumnName("Hi_Valor");

            entity.HasOne(d => d.AsuCodigoNavigation).WithMany(p => p.Hitos)
                .HasForeignKey(d => d.AsuCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Asuntos_Hitos");
        });

        modelBuilder.Entity<Informacion>(entity =>
        {
            entity.HasKey(e => e.InfCodigo).HasName("Key9");

            entity.ToTable("Informacion");

            entity.Property(e => e.InfCodigo).HasColumnName("Inf_Codigo");
            entity.Property(e => e.InfCiudad)
                .HasMaxLength(100)
                .HasColumnName("Inf_Ciudad");
            entity.Property(e => e.InfDireccion)
                .HasMaxLength(300)
                .HasColumnName("Inf_Direccion");
            entity.Property(e => e.InfDiscapacidad)
                .HasMaxLength(200)
                .HasColumnName("Inf_Discapacidad");
            entity.Property(e => e.InfEstado)
                .HasMaxLength(50)
                .HasColumnName("Inf_Estado");
            entity.Property(e => e.InfEstadoCivil)
                .HasMaxLength(50)
                .HasColumnName("Inf_EstadoCivil");
            entity.Property(e => e.InfEtnia)
                .HasMaxLength(100)
                .HasColumnName("Inf_Etnia");
            entity.Property(e => e.InfFechaNacimiento)
                .HasMaxLength(100)
                .HasColumnName("Inf_FechaNacimiento");
            entity.Property(e => e.InfFoto)
                .HasColumnType("image")
                .HasColumnName("Inf_Foto");
            entity.Property(e => e.InfGenero)
                .HasMaxLength(100)
                .HasColumnName("Inf_Genero");
            entity.Property(e => e.InfIdentificacion)
                .HasMaxLength(50)
                .HasColumnName("Inf_Identificacion");
            entity.Property(e => e.InfLugarNacimiento)
                .HasMaxLength(100)
                .HasColumnName("Inf_LugarNacimiento");
            entity.Property(e => e.InfMail)
                .HasMaxLength(100)
                .HasColumnName("Inf_Mail");
            entity.Property(e => e.InfMigranteRetornado)
                .HasMaxLength(20)
                .HasColumnName("Inf_MigranteRetornado");
            entity.Property(e => e.InfNombreContacto)
                .HasMaxLength(200)
                .HasColumnName("Inf_NombreContacto");
            entity.Property(e => e.InfNombreFoto)
                .HasMaxLength(200)
                .HasColumnName("Inf_NombreFoto");
            entity.Property(e => e.InfObservaciones)
                .HasMaxLength(300)
                .HasColumnName("Inf_Observaciones");
            entity.Property(e => e.InfOrigen)
                .HasMaxLength(50)
                .HasColumnName("Inf_Origen");
            entity.Property(e => e.InfPorcentajeDiscapacidad).HasColumnName("Inf_PorcentajeDiscapacidad");
            entity.Property(e => e.InfProvincia)
                .HasMaxLength(100)
                .HasColumnName("Inf_Provincia");
            entity.Property(e => e.InfRelacion)
                .HasMaxLength(50)
                .HasColumnName("Inf_Relacion");
            entity.Property(e => e.InfSangre)
                .HasMaxLength(20)
                .HasColumnName("Inf_Sangre");
            entity.Property(e => e.InfTelefono)
                .HasMaxLength(50)
                .HasColumnName("Inf_Telefono");
            entity.Property(e => e.InfTelefonoContacto)
                .HasMaxLength(50)
                .HasColumnName("Inf_TelefonoContacto");
            entity.Property(e => e.UsCodigo).HasColumnName("Us_Codigo");

            entity.HasOne(d => d.UsCodigoNavigation).WithMany(p => p.Informacions)
                .HasForeignKey(d => d.UsCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuarios_Informacion");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.PaCodigo).HasName("Key8");

            entity.Property(e => e.PaCodigo)
                .ValueGeneratedNever()
                .HasColumnName("Pa_Codigo");
            entity.Property(e => e.PaNombre)
                .HasMaxLength(100)
                .HasColumnName("Pa_Nombre");
            entity.Property(e => e.PaPre)
                .HasMaxLength(4)
                .HasColumnName("Pa_Pre");
        });

        modelBuilder.Entity<Referencia>(entity =>
        {
            entity.HasKey(e => e.ReCodigo).HasName("Key14");

            entity.Property(e => e.ReCodigo).HasColumnName("Re_Codigo");
            entity.Property(e => e.ReCargo)
                .HasMaxLength(150)
                .HasColumnName("Re_Cargo");
            entity.Property(e => e.ReDireccion)
                .HasMaxLength(300)
                .HasColumnName("Re_Direccion");
            entity.Property(e => e.ReEmpresa)
                .HasMaxLength(250)
                .HasColumnName("Re_Empresa");
            entity.Property(e => e.ReMail)
                .HasMaxLength(200)
                .HasColumnName("Re_Mail");
            entity.Property(e => e.ReNombre)
                .HasMaxLength(300)
                .HasColumnName("Re_Nombre");
            entity.Property(e => e.ReRelacion)
                .HasMaxLength(200)
                .HasColumnName("Re_Relacion");
            entity.Property(e => e.ReTelefono)
                .HasMaxLength(30)
                .HasColumnName("Re_Telefono");
            entity.Property(e => e.ReTipo)
                .HasMaxLength(200)
                .HasColumnName("Re_Tipo");
            entity.Property(e => e.UsCodigo).HasColumnName("Us_Codigo");

            entity.HasOne(d => d.UsCodigoNavigation).WithMany(p => p.Referencia)
                .HasForeignKey(d => d.UsCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuarios_Referencias");
        });

        modelBuilder.Entity<Solicitude>(entity =>
        {
            entity.HasKey(e => e.SoCodigo).HasName("Key17");

            entity.Property(e => e.SoCodigo).HasColumnName("So_Codigo");
            entity.Property(e => e.SoAusenciaDesde)
                .HasMaxLength(50)
                .HasColumnName("So_AusenciaDesde");
            entity.Property(e => e.SoAusenciaHasta)
                .HasMaxLength(50)
                .HasColumnName("So_AusenciaHasta");
            entity.Property(e => e.SoAusenciaRetorno)
                .HasMaxLength(50)
                .HasColumnName("So_AusenciaRetorno");
            entity.Property(e => e.SoDetalle)
                .HasMaxLength(500)
                .HasColumnName("So_Detalle");
            entity.Property(e => e.SoEstado)
                .HasMaxLength(50)
                .HasColumnName("So_Estado");
            entity.Property(e => e.SoFecha)
                .HasColumnType("datetime")
                .HasColumnName("So_Fecha");
            entity.Property(e => e.SoMotivo)
                .HasMaxLength(300)
                .HasColumnName("So_Motivo");
            entity.Property(e => e.SoOtros)
                .HasMaxLength(150)
                .HasColumnName("So_Otros");
            entity.Property(e => e.SoPermisoDesde)
                .HasMaxLength(50)
                .HasColumnName("So_PermisoDesde");
            entity.Property(e => e.SoPermisoHasta)
                .HasMaxLength(50)
                .HasColumnName("So_PermisoHasta");
            entity.Property(e => e.SoPersonalArea)
                .HasMaxLength(200)
                .HasColumnName("So_PersonalArea");
            entity.Property(e => e.SoPersonalCargo)
                .HasMaxLength(100)
                .HasColumnName("So_PersonalCargo");
            entity.Property(e => e.SoPersonalContrato)
                .HasMaxLength(200)
                .HasColumnName("So_PersonalContrato");
            entity.Property(e => e.SoPersonalCupos).HasColumnName("So_PersonalCupos");
            entity.Property(e => e.SoPersonalInicio)
                .HasMaxLength(100)
                .HasColumnName("So_PersonalInicio");
            entity.Property(e => e.SoPersonalJefe)
                .HasMaxLength(300)
                .HasColumnName("So_PersonalJefe");
            entity.Property(e => e.SoPersonalJornada)
                .HasMaxLength(200)
                .HasColumnName("So_PersonalJornada");
            entity.Property(e => e.SoPersonalMotivo)
                .HasMaxLength(2000)
                .HasColumnName("So_PersonalMotivo");
            entity.Property(e => e.SoPersonalObservacion)
                .HasMaxLength(2000)
                .HasColumnName("So_PersonalObservacion");
            entity.Property(e => e.SoPersonalReemplaza)
                .HasMaxLength(300)
                .HasColumnName("So_PersonalReemplaza");
            entity.Property(e => e.SoPersonalSucursal)
                .HasMaxLength(100)
                .HasColumnName("So_PersonalSucursal");
            entity.Property(e => e.SoPersonalSueldo)
                .HasMaxLength(50)
                .HasColumnName("So_PersonalSueldo");
            entity.Property(e => e.SoPersonalTiempo)
                .HasMaxLength(200)
                .HasColumnName("So_PersonalTiempo");
            entity.Property(e => e.SoPrestamoCantidad)
                .HasColumnType("numeric(14, 2)")
                .HasColumnName("So_PrestamoCantidad");
            entity.Property(e => e.SoPrestamoCuotas).HasColumnName("So_PrestamoCuotas");
            entity.Property(e => e.SoPrestamoValor)
                .HasColumnType("numeric(14, 2)")
                .HasColumnName("So_PrestamoValor");
            entity.Property(e => e.SoTipo)
                .HasMaxLength(150)
                .HasColumnName("So_Tipo");
            entity.Property(e => e.UsCodigo).HasColumnName("Us_Codigo");

            entity.HasOne(d => d.UsCodigoNavigation).WithMany(p => p.Solicitudes)
                .HasForeignKey(d => d.UsCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuarios_Solicitudes");
        });

        modelBuilder.Entity<SubTarifa>(entity =>
        {
            entity.HasKey(e => e.SutCodigo);

            entity.ToTable("SubTarifa");

            entity.Property(e => e.SutCodigo).HasColumnName("Sut_Codigo");
            entity.Property(e => e.SutCategoria)
                .HasMaxLength(250)
                .HasColumnName("Sut_Categoria");
            entity.Property(e => e.SutEstado)
                .HasMaxLength(50)
                .HasColumnName("Sut_Estado");
            entity.Property(e => e.SutMoneda)
                .HasMaxLength(100)
                .HasColumnName("Sut_Moneda");
            entity.Property(e => e.SutTarifa)
                .HasColumnType("numeric(14, 2)")
                .HasColumnName("Sut_Tarifa");
            entity.Property(e => e.TaCodigo).HasColumnName("Ta_Codigo");

            entity.HasOne(d => d.TaCodigoNavigation).WithMany(p => p.SubTarifas)
                .HasForeignKey(d => d.TaCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tarifa_SubTarifa");
        });

        modelBuilder.Entity<Tarifa>(entity =>
        {
            entity.HasKey(e => e.TaCodigo);

            entity.ToTable("Tarifa");

            entity.Property(e => e.TaCodigo).HasColumnName("Ta_Codigo");
            entity.Property(e => e.TaEstado)
                .HasMaxLength(50)
                .HasColumnName("Ta_Estado");
            entity.Property(e => e.TaNombre)
                .HasMaxLength(500)
                .HasColumnName("Ta_Nombre");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicCodigo).HasName("PK_HelpDesk");

            entity.Property(e => e.TicCodigo).HasColumnName("Tic_Codigo");
            entity.Property(e => e.TicCalificacion).HasColumnName("Tic_Calificacion");
            entity.Property(e => e.TicDescripcion)
                .HasMaxLength(2000)
                .HasColumnName("Tic_Descripcion");
            entity.Property(e => e.TicEstado)
                .HasMaxLength(50)
                .HasColumnName("Tic_Estado");
            entity.Property(e => e.TicFin)
                .HasMaxLength(50)
                .HasColumnName("Tic_Fin");
            entity.Property(e => e.TicInicio)
                .HasMaxLength(50)
                .HasColumnName("Tic_Inicio");
            entity.Property(e => e.TicPrioridad)
                .HasMaxLength(50)
                .HasColumnName("Tic_Prioridad");
            entity.Property(e => e.TicTecnico)
                .HasMaxLength(200)
                .HasColumnName("Tic_Tecnico");
            entity.Property(e => e.TicTiempo)
                .HasMaxLength(50)
                .HasColumnName("Tic_Tiempo");
            entity.Property(e => e.TicTipo)
                .HasMaxLength(50)
                .HasColumnName("Tic_Tipo");
            entity.Property(e => e.TicTitulo)
                .HasMaxLength(500)
                .HasColumnName("Tic_Titulo");
            entity.Property(e => e.TicUsuario)
                .HasMaxLength(200)
                .HasColumnName("Tic_Usuario");
            entity.Property(e => e.UsCodigo).HasColumnName("Us_Codigo");

            entity.HasOne(d => d.UsCodigoNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UsCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuarios_Tickets");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsCodigo);

            entity.ToTable("Usuario");

            entity.Property(e => e.UsCodigo).HasColumnName("Us_Codigo");
            entity.Property(e => e.EmCodigo).HasColumnName("Em_Codigo");
            entity.Property(e => e.UsActivo)
                .HasMaxLength(50)
                .HasColumnName("Us_Activo");
            entity.Property(e => e.UsAdicional)
                .HasMaxLength(200)
                .HasColumnName("Us_Adicional");
            entity.Property(e => e.UsApellido1)
                .HasMaxLength(100)
                .HasColumnName("Us_Apellido1");
            entity.Property(e => e.UsApellido2)
                .HasMaxLength(100)
                .HasColumnName("Us_Apellido2");
            entity.Property(e => e.UsCambio)
                .HasMaxLength(50)
                .HasColumnName("Us_Cambio");
            entity.Property(e => e.UsCorreo)
                .HasMaxLength(200)
                .HasColumnName("Us_Correo");
            entity.Property(e => e.UsEstado)
                .HasMaxLength(50)
                .HasColumnName("Us_Estado");
            entity.Property(e => e.UsGerencia)
                .HasMaxLength(300)
                .HasColumnName("Us_Gerencia");
            entity.Property(e => e.UsId)
                .HasMaxLength(450)
                .HasColumnName("Us_Id");
            entity.Property(e => e.UsJefe)
                .HasMaxLength(300)
                .HasColumnName("Us_Jefe");
            entity.Property(e => e.UsNombre1)
                .HasMaxLength(100)
                .HasColumnName("Us_Nombre1");
            entity.Property(e => e.UsNombre2)
                .HasMaxLength(100)
                .HasColumnName("Us_Nombre2");
            entity.Property(e => e.UsNombre3)
                .HasMaxLength(100)
                .HasColumnName("Us_Nombre3");
            entity.Property(e => e.UsRol)
                .HasMaxLength(200)
                .HasColumnName("Us_Rol");
            entity.Property(e => e.UsTerminos)
                .HasMaxLength(50)
                .HasColumnName("Us_Terminos");

            entity.HasOne(d => d.EmCodigoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EmCodigo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Empresas_Usuarios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
