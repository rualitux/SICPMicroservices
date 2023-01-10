using AutoMapper;
using EnumeradoService.Dtos;
using EnumeradoService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnumeradoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumeradosController : ControllerBase
    {
        private readonly IEnumeradoRepository _repository;
        private readonly IMapper _mapper;

        public EnumeradosController(IEnumeradoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<EnumeradoReadDto>> GetEnumerados()
        {
            Console.WriteLine("Sacando Enumeraditos");
            var EnumeradoItem = _repository.GetAllEnumerado();
            return Ok(_mapper.Map<IEnumerable<EnumeradoReadDto>>(EnumeradoItem));
        }
    }
}
