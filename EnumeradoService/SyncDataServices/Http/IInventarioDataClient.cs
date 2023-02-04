using EnumeradoService.Dtos;

namespace EnumeradoService.SyncDataServices.Http
{
    public interface IInventarioDataClient
    {
        Task SendEnumeradoToInventario(EnumeradoReadDto enumerado );
    }
}
