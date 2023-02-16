using AutoMapper;
using InventarioService.Dtos;
using InventarioService.Interfaces;
using InventarioService.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventarioService.Controllers
{
    [Route("api/i/[controller]")]
    [ApiController]
    public class ProcedimientoBiensController : ControllerBase
    {
        private readonly IBienPatrimonialRepository _repository;
        private readonly IMapper _mapper;

        public ProcedimientoBiensController(IBienPatrimonialRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProcedimientoBienReadDto>> GetProcedimientoBienes()
        {
            Console.WriteLine("Sacando proc. bienes");
            var procedimientoBienesList = _repository.GetAllProcedimientoBienes();
            return Ok(_mapper.Map<IEnumerable<ProcedimientoBienReadDto>>(procedimientoBienesList));
        }


        [HttpGet("{id}", Name = "GetProcedimientoBienById")]
        public ActionResult<InventarioReadDto> GetProcedimientoBienById(int id)
        {
            var procedimientoBienItem = _repository.GetProcedimientoBienById(id);
            if (procedimientoBienItem != null)
            {
                return Ok(_mapper.Map<ProcedimientoBienReadDto>(procedimientoBienItem));
            }
            return NotFound();

        }
        [HttpGet("p/{procedimientoId}", Name = "GetBienesByProcedimiento")]
        public ActionResult<IEnumerable<BienPatrimonialReadDto>> GetBienesByProcedimiento(int procedimientoId)
        {
            Console.WriteLine($"--> entró a GetBienesByProcedimiento: {procedimientoId}");
            if (!_repository.ProcedimientoExists(procedimientoId))
            {
                return NotFound();
            }
            var procedimientoBienesList = _repository.GetBienesByProcedimiento(procedimientoId);
            return Ok(_mapper.Map<IEnumerable<ProcedimientoBienReadDto>>(procedimientoBienesList));
        }
        [HttpGet("b/{bienPatrimonialId}", Name = "GetProcedimientosByBien")]
        public ActionResult<IEnumerable<BienPatrimonialReadDto>> GetProcedimientosByBien(int bienPatrimonialId)
        {
            Console.WriteLine($"--> entró a GetProcedimientosByBien: {bienPatrimonialId}");
            if (!_repository.BienExists(bienPatrimonialId))
            {
                return NotFound();
            }
            var procedimientoBienesList = _repository.GetProcedimientosByBien(bienPatrimonialId);
            return Ok(_mapper.Map<IEnumerable<ProcedimientoBienReadDto>>(procedimientoBienesList));
        }

        [HttpPost("{bienPatrimonialId}/{procedimientoId}", Name = "CreateProcedimientoBien")]
        public async Task<ActionResult<ProcedimientoBienReadDto>> CreateProcedimientoBien(
            int bienPatrimonialId, int procedimientoId, 
            ProcedimientoBienCreateDto procedimientoBienCreateDto)
        {
            Console.WriteLine($"Estableciendo relación entre bien: {bienPatrimonialId} y Procedimiento: {procedimientoId}");
            var procedimientoBienModel = _mapper.Map<ProcedimientoBien>(procedimientoBienCreateDto);
            _repository.CreateProcedimientoBien(bienPatrimonialId,procedimientoId, procedimientoBienModel);
            _repository.Save();
            Console.WriteLine($"Hasta aquí relaciono bien con proc jiji");
            var procedimientoBienReadDto = _mapper.Map<ProcedimientoBienReadDto>(procedimientoBienModel);
            //return CreatedAtRoute(nameof(GetBienById), new { Id = bienReadDto.Id }, bienReadDto);
            //return Ok("Checar en el GET nomássssssss");
            return CreatedAtAction("CreateProcedimientoBien", procedimientoBienReadDto);
        }
    }
}
