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
            CreateMap<Cliente, ResponseClientes>().ReverseMap();
            CreateMap<Cliente, RequestDatoCliente>().ReverseMap();
            CreateMap<Ciudad, RequestCiudad>().ReverseMap();
            CreateMap<Ciudad, CiudadResponse>().ReverseMap();
            CreateMap<Departamento, RequestDepartamento>().ReverseMap();
            CreateMap<Departamento, DepartamentoResponse>().ReverseMap();
            CreateMap<Pais, RequestPais>().ReverseMap();
            CreateMap<Pais, PaisResponse>().ReverseMap();
            CreateMap<Usuario, UsuarioResponse>().ReverseMap();
            CreateMap<Usuario, RequestUsuario>().ReverseMap();
            CreateMap<Producto, ResponseProducto>().ReverseMap();
            CreateMap<Producto, RequestProducto>().ReverseMap();
            CreateMap<Deposito, RequestDeposito>().ReverseMap();
            CreateMap<Deposito, DepositoResponse>().ReverseMap();
            CreateMap<Proveedor, RequestProveedor>().ReverseMap();
            CreateMap<Proveedor, ResponseProveedor>().ReverseMap();
            CreateMap<Categoria, ResponseCategoria>().ReverseMap();
            CreateMap<Categoria, RequestCategoria>().ReverseMap();
        }
    }
}