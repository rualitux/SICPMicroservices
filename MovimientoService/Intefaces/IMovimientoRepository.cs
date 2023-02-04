using MovimientoService.Models;

namespace MovimientoService.Intefaces
{
    public interface IMovimientoRepository
    {
        bool Save();
        IEnumerable<Movimiento> GetAllMovimientos();
        Movimiento GetMovimientoByID(int id);
        void CreateMov(Movimiento mov);
    }
}
