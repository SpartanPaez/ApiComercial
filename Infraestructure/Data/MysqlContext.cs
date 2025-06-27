using Microsoft.EntityFrameworkCore;
using ApiComercial.Entities;
using ApiComercial.Entitie.Documentaciones;
using ApiComercial.Entities.Cuotas;

namespace ApiComercial.Infraestructure.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class MysqlContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                //optionsBuilder.UseMySQL(_mysqlconnection);
            }
        }
        /// <summary>
        /// Representa la tabla de clientes
        /// </summary>
        public DbSet<Cliente> Clientes { get; set; }
        /// <summary>
        /// Representa la tabla de ciudaes
        /// </summary>
        public DbSet<Ciudad> Ciudades { get; set; }
        /// <summary>
        /// Representa la tabla de departamentos del pais
        /// </summary>
        public DbSet<Departamento> Departamentos { get; set; }
        /// <summary>
        /// Representa la tabla de paises
        /// </summary>
        public DbSet<Pais> Paises { get; set; }
        /// <summary>
        /// Representa la tabla de usuarios
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }
        /// <summary>
        /// Representa la tabla de productos
        /// </summary>
        public DbSet<Producto> Productos { get; set; }
        /// <summary>
        /// Representa la tabla de depositos
        /// </summary>
        public DbSet<Deposito> Depositos { get; set; }
        /// <summary>
        /// Representa la tabla de proveedores
        /// </summary>
        public DbSet<Proveedor> proveedores { get; set; }
        /// <summary>
        /// Representa la tabla de catagorias de vehiculos
        /// </summary>
        public DbSet<Categoria> categorias { get; set; }
        /// <summary>
        /// Representa la tabla de marcas de vehiculos
        /// </summary>
        public DbSet<MarcaAuto> Marcas { get; set; }  // Cambiado de MarcasAutos a Marcas
        /// <summary>
        /// Representa la tabla de modelos de vehiculos
        /// </summary>
        public DbSet<ModeloAuto> Modelos { get; set; }  // Cambiado de ModelosAutos a Modelos
        /// <summary>
        /// Representa la tabla de vehiculos
        /// </summary>
        public DbSet<Vehiculo> Vehiculos { get; set; }
        /// <summary>
        /// Representa la tabla de barrios
        /// </summary>
        public DbSet<Barrio> Barrios { get; set; }
        /// <summary>
        /// Dbset para estados de los autos
        /// </summary>
        public DbSet<Estados> Estados { get; set; }
        /// <summary>
        /// Representa la tabla de ventas
        /// </summary>
        public DbSet<Venta> Ventas { get; set; }
        /// <summary>
        /// Representa a la tabla detalle_ventas
        /// Contiene la informacion detallada de cada detalle de la venta
        /// </summary>
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        /// <summary>
        /// Representa la tabla de cuotas de ventas
        /// </summary>
        public DbSet<Cuota> Cuota { get; set; }
        public DbSet<EstadoDocumento> EstadosDocumentos { get; set; }
        public DbSet<DocumentacionOrigen> ArchivosDocumentosOrigen { get; set; }
        public DbSet<ArchivoDocumentoOrigen> ArchivosDocumentacionOrigen { get; set; }
        public DbSet<Escribania> Escribanias { get; set; }
        public DbSet<DocumentacionPostVenta> DocumentacionPostVenta { get; set; }
        public DbSet<ArchivoPostVenta> ArchivosPostVenta { get; set; }
        public DbSet<MediosPago> MediosPago { get; set; }
        public DbSet<Pago> Pagos { get; set; }

        /// <summary>
        /// Callback que se invoca cuando EF Core está configurando el modelo de datos antes de crear la base de datos. 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.ToTable("detalle_venta");
                entity.HasKey(v => v.DetalleVentaId);
                entity.Property(v => v.DetalleVentaId).HasColumnName("DetalleVentaId");
                entity.Property(v => v.VentaId).HasColumnName("VentaId");
                entity.Property(v => v.IdChasis).HasColumnName("id_chasis");
                entity.Property(v => v.Cantidad).HasColumnName("Cantidad");
                entity.Property(v => v.PrecioUnitario).HasColumnName("PrecioUnitario");
                entity.Property(v => v.Total).HasColumnName("Total");
            });

            modelBuilder.Entity<Cuota>(entity =>
            {
                entity.ToTable("cuotas");
                entity.HasKey(v => v.CuotaId);
                entity.Property(v => v.CuotaId).HasColumnName("CuotaId");
                entity.Property(v => v.VentaId).HasColumnName("VentaId");
                entity.Property(v => v.MontoCuota).HasColumnName("MontoCuota");
                entity.Property(v => v.FechaVencimiento).HasColumnName("FechaVencimiento");
                entity.Property(v => v.EstadoCodigo).HasColumnName("EstadoCodigo");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                    entity.ToTable("ventas");
                    entity.HasKey(v => v.VentaId);
                    entity.Property(v => v.VentaId).HasColumnName("VentaId");
                    entity.Property(v => v.ClienteId).HasColumnName("ClienteId");
                    entity.Property(v => v.FechaVenta).HasColumnName("FechaVenta");
                    entity.Property(v => v.PrecioTotal).HasColumnName("PrecioTotal");
                    entity.Property(v => v.InteresAnual).HasColumnName("InteresAnual");
                    entity.Property(v => v.CantidadCuotas).HasColumnName("CantidadCuotas");
                    entity.Property(v => v.PrecioTotalCuotas).HasColumnName("PrecioTotalCuotas");
            });

            modelBuilder.Entity<MediosPago>(entity =>
            {
                entity.ToTable("mediospago");
                entity.HasKey(e => e.MedioPagoId);
                entity.Property(e => e.MedioPagoId).HasColumnName("MedioPagoId").IsRequired();
                entity.Property(e => e.Codigo).HasColumnName("Codigo").HasMaxLength(10).IsRequired();
                entity.Property(e => e.Nombre).HasColumnName("Nombre").HasMaxLength(100);
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("pagos");
                entity.HasKey(e => e.PagoId);
                entity.Property(e => e.PagoId).HasColumnName("PagoId").IsRequired();
                entity.Property(e => e.CuotaId).HasColumnName("CuotaId").IsRequired();
                entity.Property(e => e.MedioPagoId).HasColumnName("MedioPagoId");
                entity.Property(e => e.FechaPago).HasColumnName("FechaPago").IsRequired();
                entity.Property(e => e.Monto).HasColumnName("Monto").IsRequired();
                entity.Property(e => e.Referencia).HasColumnName("Referencia").HasMaxLength(100);
            });

            modelBuilder.Entity<Barrio>(entity =>
            {
                entity.ToTable("barrios");
                entity.HasKey(e => e.IdBarrio);
                entity.Property(e => e.IdBarrio).HasColumnName("id_barrio").IsRequired();
                entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad").IsRequired();
                entity.Property(e => e.Descripcion).HasColumnName("descripcion").HasMaxLength(100).IsRequired();
                entity.Ignore(e => e.ciudadDescripcion);

            });

            // Configuración de la tabla MarcaAuto
            modelBuilder.Entity<MarcaAuto>(entity =>
            {
                entity.ToTable("marcas_autos");
                entity.HasKey(e => e.IdMarca);
                entity.Property(e => e.IdMarca).HasColumnName("id_marca").IsRequired();
                entity.Property(e => e.DescripcionMarca).HasColumnName("descripcion_marca").HasMaxLength(100).IsRequired();

            });

            // Configuración de la tabla ModeloAuto
            modelBuilder.Entity<ModeloAuto>(entity =>
            {
                entity.ToTable("modelos_autos");
                entity.HasKey(e => e.IdModelo);
                entity.Property(e => e.IdModelo).HasColumnName("id_modelo").IsRequired();
                entity.Property(e => e.IdMarca).HasColumnName("id_marca").IsRequired();
                entity.Property(e => e.DescripcionModelo).HasColumnName("descripcion_modelo").HasMaxLength(100).IsRequired();
                entity.Ignore(e => e.NombreMarca);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("autos", "ventas");
                entity.HasKey(e => e.IdChasis);
                entity.Property(e => e.IdChasis)
                      .HasColumnName("id_chasis")
                      .IsRequired();
                entity.Property(e => e.IdMarca)
                      .HasColumnName("id_marca");
                entity.Property(e => e.IdModelo)
                      .HasColumnName("id_modelo");
                entity.Property(e => e.TipoCar)
                      .HasColumnName("tipo_car");
                entity.Property(e => e.AnoFabricacion)
                      .HasColumnName("ano_fabricacion");
                entity.Property(e => e.Color)
                      .HasColumnName("color");
                entity.Property(e => e.Usado)
                     .HasColumnName("usado");
                entity.Property(e => e.Chapa)
                     .HasColumnName("chapa");
                entity.Property(e => e.Estado)
                     .HasColumnName("estado");
                entity.Ignore(e => e.Marca);
                entity.Ignore(e => e.Modelo);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes", "ventas");
                entity.HasKey(e => new { e.ClienteId });
                entity.Property(e => e.ClienteId).HasColumnName("ClienteId");
                entity.Property(e => e.ClienteCedula).HasColumnName("ClienteCedula");
                entity.Property(e => e.ClienteNombre).HasColumnName("ClienteNombre");
                entity.Property(e => e.ClienteDireccion).HasColumnName("ClienteDireccion");
                entity.Property(e => e.ClientePais).HasColumnName("ClientePais");
                entity.Property(e => e.ClienteDepartamento).HasColumnName("ClienteDepartamento");
                entity.Property(e => e.ClienteCiudad).HasColumnName("ClienteCiudad");
                entity.Property(e => e.ClienteBarrio).HasColumnName("ClienteBarrio");
                entity.Property(e => e.ClienteCelular).HasColumnName("ClienteCelular");
                entity.Property(e => e.ClienteCorreo).HasColumnName("ClienteCorreo");
                entity.Property(e => e.ClienteEstadoCivil).HasColumnName("ClienteEstadoCivil");
                entity.Property(e => e.ClienteEstado).HasColumnName("ClienteEstado");
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIOS", "ventas");
                entity.HasKey(e => new { e.UsuarioId });
                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioId");
                entity.Property(e => e.ClienteId).HasColumnName("ClienteId");
                entity.Property(e => e.UsuarioEstado).HasColumnName("UsuarioEstado");
                entity.Property(e => e.UsuarioNic).HasColumnName("UsuarioNic");
                entity.Property(e => e.UsuarioPass).HasColumnName("UsuarioPass");
                entity.Property(e => e.UsuarioFecha).HasColumnName("UsuarioFecha");
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("CATEGOIRAS", "ventas");
                entity.HasKey(e => new { e.CategoriaId });
                entity.Property(e => e.CategoriaId).HasColumnName("CategoriaId");
                entity.Property(e => e.CategoriaDesc).HasColumnName("CategoriaDesc");
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("departamentos");
                entity.HasKey(e => new { e.DepartamentoId });
                entity.Property(e => e.DepartamentoId).HasColumnName("id_departamento");
                entity.Property(e => e.DepartamentoDesc).HasColumnName("descripcion");
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("ciudades");
                entity.HasKey(e => new { e.CiudadId });
                entity.Property(e => e.CiudadId).HasColumnName("id_ciudad");
                entity.Property(e => e.DepartamentoId).HasColumnName("id_departamento");
                entity.Property(e => e.CiudadDesc).HasColumnName("descripcion");
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pais>(entity =>
            {
                entity.ToTable("PAIS", "ventas");
                entity.HasKey(e => new { e.PaisId });
                entity.Property(e => e.PaisId).HasColumnName("PaisId");
                entity.Property(e => e.PaisDescripcion).HasColumnName("PaisDescripcion");
                entity.Property(e => e.PaisNacionalidad).HasColumnName("PaisNacionalidad");
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("PRODUCTOS", "ventas");
                entity.HasKey(e => new { e.ProductoId });
                entity.Property(e => e.ProductoId).HasColumnName("ProductoId");
                entity.Property(e => e.ProductoLote).HasColumnName("ProductoLote");
                entity.Property(e => e.ProductoCodigoBarra).HasColumnName("ProductoCodigoBarra");
                entity.Property(e => e.ProductoNombre).HasColumnName("ProductoNombre");
                entity.Property(e => e.ProductoDescripcion).HasColumnName("ProductoDescripcion");
                entity.Property(e => e.ProductoCosto).HasColumnName("ProductoCosto");
                entity.Property(e => e.ProductoPrecio).HasColumnName("ProductoPrecio");
                entity.Property(e => e.ProductoExistencia).HasColumnName("ProductoExistencia");
                entity.Property(e => e.DepositoId).HasColumnName("DepositoId");
                entity.Property(e => e.ProductoFechaVencimiento).HasColumnName("ProductoFechaVencimiento");
                entity.Property(e => e.ProductoFechaAlta).HasColumnName("ProductoFechaAlta");
                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioId");
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Deposito>(entity =>
            {
                entity.ToTable("DEPOSITOS", "ventas");
                entity.HasKey(e => new { e.DepositoID });
                entity.Property(e => e.DepositoID).HasColumnName("DepositoId");
                entity.Property(e => e.DepositoNombre).HasColumnName("DepositoNombre");
                entity.Property(e => e.DepositoDireccion).HasColumnName("DepositoDireccion");
                entity.Property(e => e.DepositoTelefono).HasColumnName("DepositoTelefono");
                entity.Property(e => e.CiudadId).HasColumnName("CiudadId");
                entity.Property(e => e.DepositoObservaciones).HasColumnName("DepositoObservaciones");
                entity.Property(e => e.DepositoEstado).HasColumnName("DepositoEstado");
                entity.Property(e => e.DepositoUsuarioAlta).HasColumnName("DepositoUsuarioAlta");
                entity.Property(e => e.DepositoFechaAlta).HasColumnName("DepositoFechaAlta");
                entity.Property(e => e.DepositoUsuarioModif).HasColumnName("DepositoUsuarioModif");
                entity.Property(e => e.DepositoFechaModif).HasColumnName("DepositoFechaModif");


            });
            //quiero un context para una tabla de proveedores
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("PROVEEDORES", "ventas");
                entity.HasKey(e => new { e.ProveedorId });
                entity.Property(e => e.ProveedorId).HasColumnName("ProveedorId");
                entity.Property(e => e.ProveedorRuc).HasColumnName("ProveedorRuc");
                entity.Property(e => e.ProveedorNombre).HasColumnName("ProveedorNombre");
                entity.Property(e => e.ProveedorDireccion).HasColumnName("ProveedorDireccion");
                entity.Property(e => e.IdPais).HasColumnName("IdPais");
                entity.Property(e => e.IdCiudad).HasColumnName("IdCiudad");
                entity.Property(e => e.ProveedorTelefono).HasColumnName("ProveedorTelefono");
                entity.Property(e => e.ProveedorCorreo).HasColumnName("ProveedorCorreo");
                entity.Property(e => e.ProveedorEstado).HasColumnName("ProveedorEstado");
                entity.Property(e => e.ProveedorFechaAlta).HasColumnName("ProveedorFechaAlta");
                entity.Property(e => e.ProveedorUsuarioAlta).HasColumnName("ProveedorUsarAlta");
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("CATEGORIAS", "ventas");
                entity.HasKey(e => new { e.CategoriaId });
                entity.Property(e => e.CategoriaId).HasColumnName("CATEGORIA_ID");
                entity.Property(e => e.CategoriaDesc).HasColumnName("CATEGORIA_DESC");
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Estados>(entity =>
            {
                entity.ToTable("estados");
                entity.HasKey(e => new { e.Id });
                entity.Property(e => e.Id).HasColumnName("id_estado");
                entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EstadoDocumento>(entity =>
            {
                entity.ToTable("estados_documentacion");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Codigo).HasColumnName("CODIGO");
                entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
                entity.Property(e => e.Orden).HasColumnName("ORDEN");
                entity.Property(e => e.EsFinal).HasColumnName("ES_FINAL");
            });

            modelBuilder.Entity<DocumentacionOrigen>(entity =>
            {
                entity.ToTable("documentacion_origen");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdChasis).HasColumnName("id_chasis");
                entity.Property(e => e.FechaRecepcion).HasColumnName("fecha_recepcion");
                entity.Property(e => e.Observacion).HasColumnName("observacion");
                entity.Property(e => e.RegistradoPor).HasColumnName("registrado_por");
            });

            modelBuilder.Entity<ArchivoDocumentoOrigen>(entity =>
            {
                entity.ToTable("archivo_documento_origen");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DocumentacionOrigenId).HasColumnName("documentacion_origen_id");
                entity.Property(e => e.NombreArchivo).HasColumnName("nombre_archivo");
                entity.Property(e => e.RutaArchivo).HasColumnName("ruta_archivo");
                entity.Property(e => e.FechaSubida).HasColumnName("fecha_subida");
            });

            modelBuilder.Entity<Escribania>(entity =>
            {
                entity.ToTable("escribanias");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre).HasColumnName("nombre").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Titular).HasColumnName("titular").HasMaxLength(100);
                entity.Property(e => e.Ruc).HasColumnName("ruc").HasMaxLength(15);
                entity.Property(e => e.Telefono).HasColumnName("telefono").HasMaxLength(20);
                entity.Property(e => e.Direccion).HasColumnName("direccion").HasMaxLength(150);
                entity.Property(e => e.Correo).HasColumnName("correo").HasMaxLength(100);
                entity.Property(e => e.Estado).HasColumnName("estado").HasDefaultValue(true);
                entity.Property(e => e.FechaRegistro).HasColumnName("fecha_registro").HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<DocumentacionPostVenta>(entity =>
            {
                entity.ToTable("documentacion_postventa");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdChasis).HasColumnName("id_chasis").HasMaxLength(50).IsRequired();
                entity.Property(e => e.IdEscribania).HasColumnName("id_escribania").IsRequired();
                entity.Property(e => e.Estado).HasColumnName("estado").HasMaxLength(30).IsRequired();
                entity.Property(e => e.Observacion).HasColumnName("observacion").HasMaxLength(500);
                entity.Property(e => e.FechaActualizacion).HasColumnName("fecha_actualizacion");
                entity.Property(e => e.UsuarioActualizacion).HasColumnName("usuario_actualizacion").HasMaxLength(100);
            });

            modelBuilder.Entity<ArchivoPostVenta>(entity =>
           {
               entity.ToTable("archivo_postventa");
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Id).HasColumnName("id");
               entity.Property(e => e.IdDocumentacion).HasColumnName("id_documentacion").IsRequired();
               entity.Property(e => e.NombreArchivo).HasColumnName("nombre_archivo").HasMaxLength(255).IsRequired();
               entity.Property(e => e.RutaArchivo).HasColumnName("ruta_archivo").HasMaxLength(1000).IsRequired();
               entity.Property(e => e.Tipo).HasColumnName("tipo").HasMaxLength(50).IsRequired();
               entity.Property(e => e.FechaCarga).HasColumnName("fecha_carga");
               entity.Property(e => e.UsuarioCarga).HasColumnName("usuario_carga").HasMaxLength(100);
           });
        }
    }
}