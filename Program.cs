using ApiComercial;
using ApiComercial.Depedencies;
using ApiComercial.Infraestructure.Repositories;
using AutoMapper;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        builder.AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{


}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Comercial");
});

app.MapGet("/", ()
=> Results.Redirect("swagger", true))
.ExcludeFromDescription();
app.UseCors();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
