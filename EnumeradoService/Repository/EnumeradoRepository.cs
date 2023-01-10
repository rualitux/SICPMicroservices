using EnumeradoService.Data;
using EnumeradoService.Interfaces;
using EnumeradoService.Models;

namespace EnumeradoService.Repository
{
    public class EnumeradoRepository : IEnumeradoRepository
    {
        private readonly AppDbContext _context;

        public EnumeradoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateEnumerado(Enumerado enumerado)
        {
            if (enumerado == null)
            {
                throw new ArgumentNullException(nameof(enumerado));
            }
            _context.Enumerados.Add(enumerado);
        }

        public IEnumerable<Enumerado> GetAllEnumerado()
        {   
            return _context.Enumerados.ToList();
        }

        public Enumerado GetEnumeradobyId(int id)
        {
            return _context.Enumerados.FirstOrDefault(p => p.Id == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
