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
        public DbSet<Departamento> Departamentos{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTES", "ventas");
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
                entity.HasKey(e => new {e.CategoriaId});
                entity.Property(e => e.CategoriaId).HasColumnName("CategoriaId");
                entity.Property(e => e.CategoriaDesc).HasColumnName("CategoriaDesc");
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("DEPARTAMENTOS","ventas");
                entity.HasKey(e => new {e.DepartamentoId});
                entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoId");
                entity.Property(e => e.PaisId).HasColumnName("PaisId");
                entity.Property(e => e.DepartamentoDesc).HasColumnName("DepartamentoDesc");
            });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pais>(entity =>
            {
                entity.ToTable("PAIS","ventas");
                entity.HasKey(e => new {e.PaisId});
                entity.Property(e => e.PaisId).HasColumnName("PaisId");
                entity.Property(e => e.PaisDescripcion).HasColumnName("PaisDescripcion");
                entity.Property(e => e.PaisNacionalidad).HasColumnName("PaisNacionalidad");
            });
        }
    }
}