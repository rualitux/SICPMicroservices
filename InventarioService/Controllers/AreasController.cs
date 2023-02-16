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
    public class AreasController: ControllerBase
    {
        private readonly IBienPatrimonialRepository _repository;
        private readonly IMapper _mapper;

        public AreasController(IBienPatrimonialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AreaReadDto>> GetAreas()
        {
            Console.WriteLine("Sacando areas");
            var areaItem = _repository.GetAllAreas();
            return Ok(_mapper.Map<IEnumerable<AreaReadDto>>(areaItem));
        }


        [HttpGet("{id}", Name = "GetAreaById")]
        public ActionResult<AreaReadDto> GetAreaById(int id)
        {
            var areaItem = _repository.GetAreaById(id);
            if (areaItem != null)
            {
                return Ok(_mapper.Map<AreaReadDto>(areaItem));
            }
            return NotFound();

        }
        [HttpPost("{sedeId}/{dependenciaId}/{estadoAreaId}", Name = "CreateArea")]
        public async Task<ActionResult<AreaReadDto>> CreateArea(int sedeId, int dependenciaId, int estadoAreaId, AreaCreateDto areaCreateDto)
        {
            Console.WriteLine($"Creando para sede: {sedeId} y dependencia: {dependenciaId}");         
            var area = _mapper.Map<Area>(areaCreateDto);
            _repository.CreateArea(sedeId, dependenciaId, estadoAreaId, area);
            _repository.Save();
            Console.WriteLine($"Hasta aquí guardó area jiji");
            var areaReadDto = _mapper.Map<AreaReadDto>(area);
            //return CreatedAtRoute(nameof(GetBienById), new { Id = bienReadDto.Id }, bienReadDto);
            //return Ok("Checar en el GET nomássssssss");
            return CreatedAtAction("CreateArea", areaReadDto);
        }
    }
}
