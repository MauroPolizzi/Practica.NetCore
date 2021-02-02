using AutoMapper;
using PP.Dominio.Entidades.Entidades;
using PP.Servicio.Dtos.ProductoDto;

namespace PP.MaperProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<ProductoDto, Producto>().ReverseMap();
                
            CreateMap<Empleado, Empleado>().ReverseMap();
        }
    }
}
