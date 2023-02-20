using AutoMapper;
using EnumeradoService;
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
            //ParaGrpc
            CreateMap<GrpcEnumeradoModel, Enumerado>()
                .ForMember(destino => destino.ExternalId, opt => opt.MapFrom(fuente => fuente.EnumeradoId))
                .ForMember(destino => destino.Descripcion, opt => opt.MapFrom(fuente => fuente.Descripcion))
                .ForMember(destino => destino.Valor, opt => opt.MapFrom(fuente => fuente.Valor))
                //Ignorando el mapeo de esta colección porsiacaso
                .ForMember(destino => destino.BienesPatrimoniales, opt => opt.Ignore());
        }
    }
}
