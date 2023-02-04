using AutoMapper;
using EnumeradoService.AsyncDataServices;
using EnumeradoService.Dtos;
using EnumeradoService.Interfaces;
using EnumeradoService.Models;
using EnumeradoService.SyncDataServices.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnumeradoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumeradosController : ControllerBase
    {
        private readonly IEnumeradoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IInventarioDataClient _inventarioDataClient;
        private readonly IMessageBusClient _messageBusClient;

        public EnumeradosController(
            IEnumeradoRepository repository, 
            IMapper mapper,
            IInventarioDataClient inventarioDataClient,
            IMessageBusClient messageBusClient)
        {
            _repository = repository;
            _mapper = mapper;
            _inventarioDataClient = inventarioDataClient;
            _messageBusClient = messageBusClient;
        }
        [HttpGet]
        public ActionResult<IEnumerable<EnumeradoReadDto>> GetEnumerados()
        {
            Console.WriteLine("Sacando Enumeraditos");
            var EnumeradoItem = _repository.GetAllEnumerado();
            return Ok(_mapper.Map<IEnumerable<EnumeradoReadDto>>(EnumeradoItem));
        }
        [HttpGet("{id}", Name = "GetEnumeradoById")]
        public ActionResult<EnumeradoReadDto> GetEnumeradoById(int id)
        {
            var enumeradoItem = _repository.GetEnumeradobyId(id);
            if (enumeradoItem != null)
            {
                return Ok(_mapper.Map<EnumeradoReadDto>(enumeradoItem));
            }
            return NotFound();
          
        }
        [HttpPost]
        public async Task<ActionResult<EnumeradoReadDto>> CreateEnumerado(EnumeradoCreateDto enumeradoCreateDto)
        {
            var enumeradoModel = _mapper.Map<Enumerado>(enumeradoCreateDto);
            _repository.CreateEnumerado(enumeradoModel);
            _repository.Save();

            var enumeradoReadDto = _mapper.Map<EnumeradoReadDto>(enumeradoModel);
            //Sincrono
            try
            {
                await _inventarioDataClient.SendEnumeradoToInventario(enumeradoReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo mandar sync: {ex.Message}");
            }
            //Asincrono (RabbitMQ)
            try
            {
                var enumeradoPublishedDto = _mapper.Map<EnumeradoPublishedDto>(enumeradoReadDto);
                enumeradoPublishedDto.Event = "enumerado_Published";
                _messageBusClient.PublicarEnumerado(enumeradoPublishedDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo mandar Async: {ex.Message}");

            }
            return CreatedAtRoute(nameof(GetEnumeradoById), new { Id = enumeradoReadDto.Id }, enumeradoReadDto);
        }

    }
    
}
