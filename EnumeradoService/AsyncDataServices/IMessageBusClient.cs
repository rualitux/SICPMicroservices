using EnumeradoService.Dtos;

namespace EnumeradoService.AsyncDataServices
{
    public interface IMessageBusClient
    {
        void PublicarEnumerado(EnumeradoPublishedDto enumeradoPublishedDto);
    }
}
