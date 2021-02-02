using AutoMapper;
using PP.Servicio.Dtos.EmpleadoDto;
using PP.Servicio.Dtos.ProductoDto;
using WebApi.Models;

namespace PP.AutoMapperModelo
{
    public class PerfilCreationDto : Profile
    {
        public PerfilCreationDto()
        {
            CreateMap<ProductoCreationDto, ProductoDto>().ReverseMap();

            CreateMap<EmpleadoCreationDto, EmpleadoDto>().ReverseMap();
        }
    }
}
