using AutoMapper;
using MovimientoService.Dtos;
using MovimientoService.Models;

namespace MovimientoService.Profiles
{
    public class MovimientosProfile: Profile
    {
        public MovimientosProfile()
        {
            CreateMap<Movimiento, MovimientoReadDto>();
            CreateMap<MovientoCreateDto, Movimiento>();
        }
    }
}
