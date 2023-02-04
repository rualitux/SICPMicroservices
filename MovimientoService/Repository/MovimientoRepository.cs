using MovimientoService.Data;
using MovimientoService.Intefaces;
using MovimientoService.Models;

namespace MovimientoService.Repository
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly AppDbContext _context;

        public MovimientoRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CreateMov(Movimiento mov)
        {
            throw new NotImplementedException();
        }

        public Movimiento GetMovimientoByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movimiento> GetAllMovimientos()
        {
            return _context.Movimientos.ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
