using EnumeradoService.Models;

namespace EnumeradoService.Interfaces
{
    public interface IEnumeradoRepository
    {
        bool Save();
        IEnumerable<Enumerado> GetAllEnumerado();
        Enumerado GetEnumeradobyId(int id);
        void CreateEnumerado(Enumerado enumerado);
    }
}
