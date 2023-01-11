using AutoMapper;
using InventarioService.Dtos;
using InventarioService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventarioService.Controllers
{
    [Route("api/i/[controller]")]
    [ApiController]
    public class EnumeradosController: ControllerBase
    {
        private readonly IBienPatrimonialRepository _repository;
        private readonly IMapper _mapper;

        public EnumeradosController(IBienPatrimonialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<EnumeradoReadDto>> GetEnumerados()
        {
            Console.WriteLine("Sacando Enumerados/Categorías de InventarioService");
            var enumeradoItems = _repository.GetAllEnumerados();
            return Ok(_mapper.Map<IEnumerable<EnumeradoReadDto>>(enumeradoItems));
        }
        [HttpPost]
        public ActionResult testInboundConnection()
        {
            Console.WriteLine("--> InboundPost #");
            return Ok("Inbound test from EnumeradosC");
        }
    }
}
