using ApiComercial.Infraestructure.Data;
using ApiComercial.Infraestructure.interfaces;
using ApiComercial.interfaces;
using ApiComercial.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiComercial.Infraestructure.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AgregarRepository(this IServiceCollection services)
        {
            var config = services.BuildServiceProvider().GetService<IConfiguration>();
            
            services.AddDbContext<MysqlContext>(o => 
                o.UseMySQL("server=localhost;port=3301;database=ventas;user=root;password=a.12345678"));
            
            services.AddTransient<IclientesRepository, EFClientesRepository>();
            services.AddTransient<IreferencialesRepository, EFReferencialesRepository>();
            services.AddTransient<IproductoRepository, EFProductoRepository>();
            return services;
        }
    }
}