using AutoMapper;
using InventarioService.Dtos;
using InventarioService.Interfaces;
using InventarioService.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventarioService.Controllers
{
    [ApiController]
    //[Route("api/i/enumerados/{enumeradoId}/[controller]")]
    [Route("api/i/[controller]")]
    public class BienesController : ControllerBase
    {
        private readonly IBienPatrimonialRepository _repository;
        private readonly IMapper _mapper;

        public BienesController(IBienPatrimonialRepository repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<BienPatrimonialReadDto>> GetAllBienesPatrimoniales()
        {
            var bienItem = _repository.GetAllBienes();            
             return Ok(_mapper.Map<IEnumerable<BienPatrimonialReadDto>>(bienItem));                        
        }
        //[HttpGet("{id}", Name = "GetBienById")]
        [HttpGet("{id}", Name = "GetBienById")]
        public ActionResult<BienPatrimonialReadDto> GetBienById(int id)
        {
            Console.WriteLine("Entró al getBienById");
            var bienItem = _repository.GetBienById(id);
            if (bienItem != null)
            {
                Console.WriteLine($"id ={id} ");
                return Ok(_mapper.Map<BienPatrimonialReadDto>(bienItem));
            }
            return NotFound();

        }

        [HttpGet("c/{enumeradoId}", Name = "GetBienesByCategoria")]
        public ActionResult<IEnumerable<BienPatrimonialReadDto>> GetBienesByCategoria(int enumeradoId)
        {
            Console.WriteLine($"--> entró a GetBienesByCategoria: {enumeradoId}");
            if (!_repository.EnumeradoExists(enumeradoId))
            {
                return NotFound();
            }
            var bienes = _repository.GetBienesForEnumerados(enumeradoId);
            return Ok(_mapper.Map<IEnumerable<BienPatrimonialReadDto>>(bienes));


        }
       

        [HttpPost("{enumeradoId}", Name = "CrearBienPorEnumerado")]
        public ActionResult<BienPatrimonialReadDto> CrearBienPorEnumerado(int enumeradoId, BienPatrimonialCreateDto bienCreateDto)
        {
            Console.WriteLine($"Creando para categoría: {enumeradoId}");
            if (!_repository.EnumeradoExists(enumeradoId))
            {
                Console.WriteLine("No existe enumerado categoría");
                return NotFound();
            }           
            var bien = _mapper.Map<BienPatrimonial>(bienCreateDto);
            _repository.CreateBien(enumeradoId, bien);
            _repository.Save();
            Console.WriteLine("Hasta aquí guardó jiji");
            var bienReadDto = _mapper.Map<BienPatrimonialReadDto>(bien);
            //return CreatedAtRoute(nameof(GetBienById), new { Id = bienReadDto.Id }, bienReadDto);
            //return Ok("Checar en el GET nomássssssss");
            return CreatedAtAction("CrearBienPorEnumerado", bienReadDto);
        }

    }
}
