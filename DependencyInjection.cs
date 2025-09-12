using ApiComercial.Infraestructure.Repositories;
using ApiComercial.interfaces;
using ApiComercial.Interfaces;
using ApiComercial.Repositories.Interfaces;
using ApiComercial.Services;
using ApiComercial.Services.Catalogo;
using ApiComercial.Services.Interfaces;
using ApiComercial.Services.Interfaces.Catalogo;

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
            services.AddTransient<IDocumentoService, DocumentoService>();
            services.AddScoped<ICatalogoAutoService, CatalogoAutoService>();

            // Agregar el servicio y repositorio para Marcas y Modelos
            services.AddTransient<IMarcaModeloService, MarcaModeloService>();
            services.AddTransient<IMarcaModeloRepository, MarcaModeloRepository>();
            services.AddTransient<IVentaService, VentasService>();
            services.AddTransient<IVentasRepository, VentasRepository>();

            // Auth Service y Repository
            services.AddScoped<ApiComercial.interfaces.IAuthService, ApiComercial.Services.AuthService>();
            services.AddScoped<ApiComercial.interfaces.IAuthRepository, ApiComercial.Infraestructure.Data.AuthRepository>();

            return services;
        }
    }
}