using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiComercial.Depedencies
{
    public static class SwaggerDependencyInjection
    {
        public static IServiceCollection AgregarDocumentacionSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title       = "Spartan API",
                    Version     = "v1",
                    Description = $"Documentación para el uso de la API de sistema de gestión automotor",
                    Contact = new OpenApiContact
                    {
                        Email = "Spartanpaez@icloud.com",
                        Name  = "SpartanDev"
                    }
                });


                var xmlFile = Path.ChangeExtension(typeof(Program).Assembly.Location, ".xml");
                c.IncludeXmlComments(xmlFile);
                //c.OperationFilter<RemoveVersionParameterFilter>();
                //c.DocumentFilter<ReplaceVersionWithExactValueInPathFilter>();
            });
        }
    }

    public class RemoveVersionParameterFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var versionParameter = operation.Parameters.Single(p => p.Name == "version");
            operation.Parameters.Remove(versionParameter);
        }
    }

    public class ReplaceVersionWithExactValueInPathFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = new OpenApiPaths();
            foreach (var path in swaggerDoc.Paths)
            {
                paths.Add(path.Key.Replace("v{version}", swaggerDoc.Info.Version), path.Value);
            }

            swaggerDoc.Paths = paths;
        }
    }
}
