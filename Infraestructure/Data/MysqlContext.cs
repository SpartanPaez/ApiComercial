using Microsoft.EntityFrameworkCore;
using ApiComercial.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApiComercial.Entities;

namespace ApiComercial.Infraestructure.Data
{
    public class MysqlContext : DbContext
    {
        /*private string? _mysqlconnection;
        public MysqlContext(string mysqlconnection)
        {
            _mysqlconnection = mysqlconnection;
        }
        */
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTES","ventas");
                entity.HasKey(e => new {e.ClienteCedula});
                entity.Property(e => e.ClienteCedula);
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
        }
    }
}