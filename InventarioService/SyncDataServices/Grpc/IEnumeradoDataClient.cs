using InventarioService.Models;

namespace InventarioService.SyncDataServices.Grpc
{
    public interface IEnumeradoDataClient
    {
        IEnumerable<Enumerado> ReturnAlLEnumerados();
    }
}
