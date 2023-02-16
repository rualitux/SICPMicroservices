using AutoMapper;
using InventarioService.Dtos;
using InventarioService.Interfaces;
using InventarioService.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventarioService.Controllers
{
    [Route("api/i/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private readonly IBienPatrimonialRepository _repository;
        private readonly IMapper _mapper;

        public InventariosController(IBienPatrimonialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<InventarioReadDto>> GetInventarios()
        {
            Console.WriteLine("Sacando inventarios");
            var inventarioList = _repository.GetAllInventarios();
            return Ok(_mapper.Map<IEnumerable<InventarioReadDto>>(inventarioList));
        }


        [HttpGet("{id}", Name = "GetInventarioById")]
        public ActionResult<InventarioReadDto> GetInventarioById(int id)
        {
            var inventarioItem = _repository.GetInventarioById(id);
            if (inventarioItem != null)
            {
                return Ok(_mapper.Map<InventarioReadDto>(inventarioItem));
            }
            return NotFound();

        }
        [HttpGet("a/{areaId}", Name = "GetInventariosByArea")]
        public ActionResult<IEnumerable<BienPatrimonialReadDto>> GetInventariosByArea(int areaId)
        {
            Console.WriteLine($"--> entró a GetInventariosByArea: {areaId}");
            if (!_repository.AreaExists(areaId))
            {
                return NotFound();
            }
            var inventarioList = _repository.GetInventariosForArea(areaId);
            return Ok(_mapper.Map<IEnumerable<InventarioReadDto>>(inventarioList));


        }

        [HttpPost("{bienPatrimonialId}/{areaId}/{anexoTipoId}/{estadoCondicionId}/{estadoBienId}", Name = "CreateInventario")]
        public async Task<ActionResult<InventarioReadDto>> CreateInventario(
            int bienPatrimonialId, int areaId, int anexoTipoId,
            int estadoCondicionId, int estadoBienId, InventarioCreateDto inventarioCreateDto)
        {
            Console.WriteLine($"Creando para bien: {bienPatrimonialId} y area: {areaId}");
            var inventario = _mapper.Map<Inventario>(inventarioCreateDto);
            _repository.CreateInventario(bienPatrimonialId, areaId, anexoTipoId, estadoCondicionId
                , estadoBienId, inventario);
            _repository.Save();
            Console.WriteLine($"Hasta aquí guardó inventario jiji");
            var inventarioReadDto = _mapper.Map<InventarioReadDto>(inventario);
            //return CreatedAtRoute(nameof(GetBienById), new { Id = bienReadDto.Id }, bienReadDto);
            //return Ok("Checar en el GET nomássssssss");
            return CreatedAtAction("CreateInventario", inventarioReadDto);
        }
    }
}
