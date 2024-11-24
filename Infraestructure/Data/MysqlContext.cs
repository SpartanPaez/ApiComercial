using Microsoft.EntityFrameworkCore;
using ApiComercial.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApiComercial.Entities;

namespace ApiComercial.Infraestructure.Data
{
    public class MysqlContext : DbContext
    {
        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                //optionsBuilder.UseMySQL(_mysqlconnection);
            }
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<Proveedor> proveedores { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<MarcaAuto> Marcas { get; set; }  // Cambiado de MarcasAutos a Marcas
        public DbSet<ModeloAuto> Modelos { get; set; }  // Cambiado de ModelosAutos a Modelos
        public DbSet<Vehiculo> Vehiculos { get; set; }
        /// <summary>
        /// Dbset para estados de los autos
        /// </summary>
        public DbSet<Estados> Estados { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

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

            base.OnModelCreating(modelBuilder);
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
                // No mapear 'Marca' ni 'Modelo' aquí porque no son columnas de la base de datos
                entity.Property(e => e.Usado)
                     .HasColumnName("usado");

                entity.Property(e => e.Chapa)
                     .HasColumnName("chapa");

                entity.Property(e => e.Estado)
                     .HasColumnName("estado");


                entity.Ignore(e => e.Marca);
                entity.Ignore(e => e.Modelo);
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes", "ventas");
                entity.HasKey(e => new { e.ClienteId });
                entity.Property(e => e.ClienteId);
                entity.Property(e => e.ClienteId).HasColumnName("ClienteId");
                entity.Property(e => e.ClienteCedula).HasColumnName("ClienteCedula");
                entity.Property(e => e.ClienteNombre).HasColumnName("ClienteNombre");
                entity.Property(e => e.ClienteDireccion).HasColumnName("ClienteDireccion");
                entity.Property(e => e.ClientePais).HasColumnName("ClientePais");
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
            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("CIUDADES", "ventas");
                entity.HasKey(e => new { e.CiudadId });
                entity.Property(e => e.CiudadId).HasColumnName("CiudadId");
                entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoId");
                entity.Property(e => e.CiudadDesc).HasColumnName("CiudadDesc");

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
                entity.ToTable("DEPARTAMENTOS", "ventas");
                entity.HasKey(e => new { e.DepartamentoId });
                entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoId");
                entity.Property(e => e.PaisId).HasColumnName("PaisId");
                entity.Property(e => e.DepartamentoDesc).HasColumnName("DepartamentoDesc");
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
        }
    }
}