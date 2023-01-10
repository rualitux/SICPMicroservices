using AutoMapper;
using EnumeradoService.Dtos;
using EnumeradoService.Models;

namespace EnumeradoService.Profiles
{
    public class EnumeradosProfile : Profile
    {
        public EnumeradosProfile()
        {
            CreateMap<Enumerado, EnumeradoReadDto>();
            CreateMap<EnumeradoCreateDto, Enumerado>();
        }
    }
}
