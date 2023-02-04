using AutoMapper;
using InventarioService.Dtos;
using InventarioService.Interfaces;
using InventarioService.Models;
using System.Text.Json;

namespace InventarioService.EventProcesamiento
{
    public class EventProcesador : IEventProcesador
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcesador(IServiceScopeFactory scopeFactory,
            IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }
        public void ProcessEvent(string message)
        {
            var tipoEvento = DeterminaEvent(message);
            switch (tipoEvento)
            {
                case TipoEvent.EnumeradoPublished:
                    AddEnumerado(message);
                    break;
                default:
                    break;
          }
        }

        private TipoEvent DeterminaEvent(string notificacionMessage)
        {
            Console.WriteLine("--_> Determinando evento");
            var tipoEvento = JsonSerializer.Deserialize<GenericEventDto>(notificacionMessage);
            switch (tipoEvento.Event)
            {
                case "enumerado_Published":
                    Console.WriteLine("Evento Enumerado Publicado Detectado");
                    return TipoEvent.EnumeradoPublished;
                default:
                    Console.WriteLine("No se detectó tipo de Evento");
                    return TipoEvent.NoDeterminado;
            }
        }

        private void AddEnumerado(string enumeradoPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IBienPatrimonialRepository>();
                var enumeradoPublishedDto = JsonSerializer.Deserialize<EnumeradoPublishedDto>(enumeradoPublishedMessage);
                try
                {
                    var enumeradoModel = _mapper.Map<Enumerado>(enumeradoPublishedDto);
                    if (!repo.EnumeradoExternoExiste(enumeradoModel.ExternalId))
                    {
                        repo.CreateEnumerado(enumeradoModel);
                        repo.Save();
                        Console.WriteLine("--> Enumerado añadito en Inventario");

                    }
                    else
                    {
                        Console.WriteLine("--> Enumerado ya existe");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"No se pudo agregar Enumerado {ex.Message}");
                    
                }
            }
        }

    }

    enum TipoEvent
    { 
        EnumeradoPublished,
        NoDeterminado
    }
}

