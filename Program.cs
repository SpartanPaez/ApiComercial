using ApiComercial;
using ApiComercial.Depedencies;
using ApiComercial.Infraestructure.Repositories;
using AutoMapper;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar la aplicación para escuchar en 0.0.0.0
builder.WebHost.UseUrls("http://0.0.0.0:5000");

var MyAllowSpecificOrigins = "AllowSpecificOrigins";

// Add services to the container.
builder.Services.AddFluentValidation(options =>
{
    // Validate child properties and root collection elements
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;

    // Automatic registration of validators in assembly
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
})
.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AgregarAutoMapper();
builder.Services.AgregarServicio();
builder.Services.AgregarRepository();
builder.Services.AgregarDocumentacionSwagger();
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()  // Permitir cualquier origen
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Aquí puedes agregar configuraciones específicas para el entorno de desarrollo
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Comercial");
});

app.MapGet("/", () => Results.Redirect("swagger", true))
    .ExcludeFromDescription();

app.UseCors(); // Asegúrate de colocar esto antes de UseAuthorization

// app.UseHttpsRedirection(); // Descomenta esto si usas HTTPS

app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();
app.Run();
