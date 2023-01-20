using ApiComercial.interfaces;
using ApiComercial.Services;

namespace ApiComercial
{
    public static class DependencyInjection
    {
        public static IServiceCollection Agregar(this IServiceCollection services)
        {
            services.AddTransient<IclientesServices, ClienteService>();
            return services;
        }
    }
}