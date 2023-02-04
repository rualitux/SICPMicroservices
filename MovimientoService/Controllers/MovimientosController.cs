using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovimientoService.Dtos;
using MovimientoService.Intefaces;

namespace MovimientoService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoRepository _repository;
        private readonly IMapper _mapper;

        public MovimientosController(IMovimientoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<MovimientoReadDto>> GetAllMoviemientos()
        {
            var movIten = _repository.GetAllMovimientos();
            return Ok(_mapper.Map<IEnumerable<MovimientoReadDto>>(movIten));
        }
    }
}
