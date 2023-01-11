using AutoMapper;
using InventarioService.Dtos;
using InventarioService.Models;

namespace InventarioService.Profiles
{
    public class BienesPatrimonialesProfile : Profile
    {
        public BienesPatrimonialesProfile()
        {
            CreateMap<Enumerado, EnumeradoReadDto>();
            CreateMap<BienPatrimonial, BienPatrimonialReadDto > ();
            CreateMap<BienPatrimonialCreateDto, BienPatrimonial>();

        }
    }
}
