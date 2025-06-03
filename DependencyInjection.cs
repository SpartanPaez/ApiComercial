using ApiComercial.Infraestructure.Repositories;
using ApiComercial.interfaces;
using ApiComercial.Interfaces;
using ApiComercial.Repositories.Interfaces;
using ApiComercial.Services;
using ApiComercial.Services.Interfaces;

namespace ApiComercial
{
    public static class DependencyInjection
    {
        public static IServiceCollection AgregarServicio(this IServiceCollection services)
        {
            services.AddTransient<IclientesServices, ClienteService>();
            services.AddTransient<IreferencialesService, ReferencialesService>();
            services.AddTransient<IproductosService, ProductoService>();
            services.AddTransient<IVehiculosService, VehiculosService>();

            // Agregar el servicio y repositorio para Marcas y Modelos
            services.AddTransient<IMarcaModeloService, MarcaModeloService>();
            services.AddTransient<IMarcaModeloRepository, MarcaModeloRepository>();
            services.AddTransient<IVentaService, VentasService>();

            return services;
        }
    }
}