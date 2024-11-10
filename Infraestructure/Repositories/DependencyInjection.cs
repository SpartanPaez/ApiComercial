using ApiComercial.Infraestructure.Data;
using ApiComercial.Infraestructure.interfaces;
using ApiComercial.Infraestructure.Interfaces;
using ApiComercial.interfaces;
using ApiComercial.Interfaces;
using ApiComercial.Services;
using Microsoft.EntityFrameworkCore;


namespace ApiComercial.Infraestructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AgregarRepository(this IServiceCollection services)
        {
            var config = services.BuildServiceProvider().GetService<IConfiguration>();

            services.AddDbContext<MysqlContext>(o =>
                o.UseMySQL("server=localhost;port=3306;database=ventas;user=root;password=Spartan.Chupapi.117"));
                //o.UseMySQL("server=216.219.95.215;port=3306;database=ventas;user=chupapi;password=Munano.porn0.117"));


            services.AddTransient<IclientesRepository, EFClientesRepository>();
            services.AddTransient<IreferencialesRepository, EFReferencialesRepository>();
            services.AddTransient<IproductoRepository, EFProductoRepository>();
            services.AddTransient<IVehiculoRepository, EFVehiculosRepository>();
            services.AddScoped<IMarcaModeloRepository, MarcaModeloRepository>();
            services.AddScoped<IMarcaModeloService, MarcaModeloService>();

            return services;
        }
    }
}