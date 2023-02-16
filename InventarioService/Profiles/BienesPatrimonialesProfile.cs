﻿using AutoMapper;
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
            CreateMap<EnumeradoPublishedDto, Enumerado>()
                .ForMember(destino => destino.ExternalId, 
                opt => opt.MapFrom(fuente => fuente.Id));
            CreateMap<Procedimiento, ProcedimientoReadDto>();
            CreateMap<ProcedimientoCreateDto, Procedimiento>();
            CreateMap<Area, AreaReadDto>();
            CreateMap<AreaCreateDto, Area>();
            CreateMap<Inventario, InventarioReadDto>();
            CreateMap<InventarioCreateDto, Inventario>();
            CreateMap<ProcedimientoBien, ProcedimientoBienReadDto>();
            CreateMap<ProcedimientoBienCreateDto, ProcedimientoBien>();
        }
    }
}
