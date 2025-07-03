using ApiComercial.Infraestructure.Data;
using ApiComercial.Infraestructure.interfaces;
using ApiComercial.Infraestructure.Interfaces;
using ApiComercial.Infraestructure.Repositories.Interfaces;
using ApiComercial.Interfaces;
using ApiComercial.Repositories.Interfaces;
using ApiComercial.Services;
using ApiComercial.Services.Interfaces;
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
             //o.UseMySQL("server=127.0.0.1;port=3306;database=ventas;user=root;password=spartan.desarrollo.117"));
            o.UseMySQL("server=134.209.67.141;port=3306;database=ventas;user=chupapi;password=Munano.porn0.117"));
            services.AddTransient<IclientesRepository, EFClientesRepository>();
            services.AddTransient<IreferencialesRepository, EFReferencialesRepository>();
            services.AddTransient<IproductoRepository, EFProductoRepository>();
            services.AddTransient<IVehiculoRepository, EFVehiculosRepository>();
            services.AddScoped<IMarcaModeloRepository, MarcaModeloRepository>();
            services.AddScoped<IMarcaModeloService, MarcaModeloService>();
            services.AddTransient<IVentasRepository, VentasRepository>();
            services.AddTransient<IDocuementosRepository, DocumentosRepository>();
            services.AddScoped<ICatalogoFotoAutoRepository, CatalogoFotoAutoRepository>();

                                                                    
            return services;
        }
    }
}