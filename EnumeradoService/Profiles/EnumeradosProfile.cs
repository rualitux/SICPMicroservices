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
            CreateMap<EnumeradoReadDto, EnumeradoPublishedDto>();
            CreateMap<Enumerado, GrpcEnumeradoModel>()
                .ForMember(destino => destino.EnumeradoId, opt => opt.MapFrom(fuente => fuente.Id))
                .ForMember(destino => destino.Descripcion, opt => opt.MapFrom(fuente => fuente.Descripcion))
                .ForMember(destino => destino.Valor, opt => opt.MapFrom(fuente => fuente.Valor));
        }
    }
}
