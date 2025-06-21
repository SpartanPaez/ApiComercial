
using System.Reflection.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NSwag;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;


namespace ApiComercial.Depedencies;

public static class SwaggerDependencyInjection
{
    public static void AgregarDocumentacionSwagger(this IServiceCollection services)
    {
        var config = services.GetConfiguration();
        services.AddOpenApiDocument(options =>
        {
            options.PostProcess = document =>
            {
                document.Info = new OpenApiInfo
                {
                    Title = "Api Comercial",
                    Version = "v1",
                    Description = "API para la gestión de documentos comerciales",
                    Contact = new OpenApiContact
                    {
                        Name = "Soporte API",
                        Email = "",
                    }
                };
                document.Servers.Clear();
            };

        });
    }
    public static IConfiguration GetConfiguration(this IServiceCollection services)
    {
        using var scope = services.BuildServiceProvider().CreateScope();
        var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
        return configuration;
    }



}

