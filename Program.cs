using ApiComercial;
using ApiComercial.Depedencies;
using ApiComercial.Infraestructure.Repositories;
using AutoMapper;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Escuchar en todas las interfaces en el puerto 5000
builder.WebHost.UseUrls("http://0.0.0.0:5000");

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// FluentValidation + MVC
builder.Services.AddFluentValidation(options =>
{
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
}).AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AgregarDocumentacionSwagger();

// AutoMapper / Servicios / Repositorios / Swagger Custom
builder.Services.AgregarAutoMapper();
builder.Services.AgregarServicio();
builder.Services.AgregarRepository();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

var app = builder.Build();

app.UseDefaultFiles(); // opcional, busca index.html por defecto
app.UseStaticFiles();  // sirve archivos de wwwroot/

// Custom exception handler para mapear DuplicateResourceException a 409
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        var ex = exFeature?.Error;
        if (ex is ApiComercial.Exceptions.DuplicateResourceException)
        {
            context.Response.StatusCode = StatusCodes.Status409Conflict;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new { message = ex.Message });
            return;
        }

        // fallback: 500
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new { message = ex?.Message ?? "Internal Server Error" });
    });
});

app.UseOpenApi(); // Expone el JSON: /swagger/apicomercial/swagger.json
app.UseSwaggerUi();


app.UseCors();

// Redirección HTTPS (funciona también con Cloudflare Tunnel)
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// Redirección de la raíz al Swagger
app.MapMethods("/", new[] { "GET", "HEAD" }, context =>
{
    context.Response.Redirect("/swagger");
    return Task.CompletedTask;
});

app.Run();
