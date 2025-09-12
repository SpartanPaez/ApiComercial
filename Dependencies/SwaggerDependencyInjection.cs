
using NSwag;


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

                // Agregar definición de seguridad JWT (NSwag)
                document.Components.SecuritySchemes["JWT"] = new NSwag.OpenApiSecurityScheme
                {
                    Type = NSwag.OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = NSwag.OpenApiSecurityApiKeyLocation.Header,
                    Description = "Ingrese: Bearer {su token JWT}"
                };
                document.Security = new List<NSwag.OpenApiSecurityRequirement>
                {
                    new NSwag.OpenApiSecurityRequirement
                    {
                        { "JWT", new string[] { } }
                    }
                };
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

