using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PP.Servicio.Dtos.EmpleadoDto;
using PP.Servicio.Dtos.ProductoDto;
using WebApi.Models;

namespace WebApi.AutoMapper
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
