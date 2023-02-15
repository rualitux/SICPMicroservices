using AutoMapper;
using InventarioService.Dtos;
using InventarioService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventarioService.Controllers
{
    [ApiController]
    //[Route("api/i/enumerados/{enumeradoId}/[controller]")]
    [Route("api/i/[controller]")]
    public class ProcedimientosController: ControllerBase
    {
        private readonly IBienPatrimonialRepository _repository;
        private readonly IMapper _mapper;

        public ProcedimientosController(IBienPatrimonialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProcedimientoReadDto>> GetProcedimientos()
        {
            Console.WriteLine("Sacando procedimientos");
            var procedimientoItem = _repository.GetAllProcedimientos();
            return Ok(_mapper.Map<IEnumerable<ProcedimientoReadDto>>(procedimientoItem));
        }


        [HttpGet("{id}", Name = "GetProcedimientoById")]
        public ActionResult<ProcedimientoReadDto> GetProcedimientoById(int id)
        {
            var procedimientoItem = _repository.GetProcedimientoById(id);
            if (procedimientoItem != null)
            {
                return Ok(_mapper.Map<ProcedimientoReadDto>(procedimientoItem));
            }
            return NotFound();

        }


    }
}
