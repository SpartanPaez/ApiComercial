using ApiComercial.interfaces;
using ApiComercial.Services;

namespace ApiComercial
{
    public static class DependencyInjection
    {
        public static IServiceCollection AgregarServicio(this IServiceCollection services)
        {
            services.AddTransient<IclientesServices, ClienteService>();
            services.AddTransient<IreferencialesService, ReferencialesService>();
            return services;
        }
    }
}