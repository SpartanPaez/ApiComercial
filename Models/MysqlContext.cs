using Microsoft.EntityFrameworkCore;

namespace ApiComercial.Models
{
    public class MysqlContext : DbContext
    {
        private string? _mysqlconnection;
        public MysqlContext(string mysqlconnection)
        {
            _mysqlconnection = mysqlconnection;
        }
        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
            }
        }
        public DbSet<ResponseClientes> Clientes { get; set; } = null!;
    }
}