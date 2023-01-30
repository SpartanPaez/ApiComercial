using AutoMapper;
using ApiComercial.interfaces;
using ApiComercial.Entities;
using ApiComercial.Models;
using Microsoft.Extensions.DependencyInjection;
namespace ApiComercial.Depedencies
{
    public static class AutoMapperDependencyInjection
    {
        public static IServiceCollection AgregarAutoMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            return services.AddSingleton(mapper);
        }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Core.Entities.DiaHabil, DiaHabil>().ReverseMap();
            //CreateMap<DateTime, string>().ConvertUsing(s => s.Date.ToString("dd/MM/yyyy"));
            CreateMap<Cliente, ResponseClientes>().ReverseMap();
            CreateMap<Cliente, RequestDatoCliente>().ReverseMap();
            CreateMap<Ciudad, RequestCiudad>().ReverseMap();
            CreateMap<Ciudad, CiudadResponse>().ReverseMap();
        }
    }
}