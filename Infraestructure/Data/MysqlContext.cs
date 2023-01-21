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
        public DbSet<Cliente> CLIENTES { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => new {e.ClienteCedula});
                entity.Property(e => e.ClienteCedula);
            });
        }
    }
}