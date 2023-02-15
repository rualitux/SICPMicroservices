using InventarioService.Data;
using InventarioService.Interfaces;
using InventarioService.Models;

namespace InventarioService.Repository
{
    public class BienPatrimonialRepository : IBienPatrimonialRepository
    {
        private readonly AppDbContext _context;

        public BienPatrimonialRepository(AppDbContext context)
        {
            _context = context;
        }

        //public void CreateBien(int enumeradoId, BienPatrimonial bien)
        //{
        //    if (bien == null)
        //    { 
        //        throw new ArgumentNullException(nameof(bien));                
        //    }
        //    var categoria = _context.Enumerados.Where(p => p.Id == enumeradoId)
        //        .Select(x=>x.Valor).Single();
        //    bien.Categoria= categoria;
        //    bien.EnumeradoId = enumeradoId;   

        //    _context.BienesPatrimoniales.Add(bien);
        //}
        public void CreateBien(int enumeradoId, int procedimientoId, BienPatrimonial bien)
        {
            if (bien == null)
            {
                throw new ArgumentNullException(nameof(bien));
            }
            var categoria = _context.Enumerados.Where(p => p.Id == enumeradoId)
                .Select(x => x.Valor).Single();
            var procedimientoString = _context.Procedimientos.Where(p => p.Id == procedimientoId)
                .Select(x => x.NombreReferencial).Single();
            bien.Categoria = categoria;           
            bien.EnumeradoId = enumeradoId;
            bien.ProcedimientoId = procedimientoId;
            bien.ProcedimientoNombre = procedimientoString;

            _context.BienesPatrimoniales.Add(bien);
        }

        public void CreateEnumerado(Enumerado enumerado)
        {
            if (enumerado == null)
            {
                throw new ArgumentNullException(nameof(enumerado));
            }
            _context.Enumerados.Add(enumerado);
        }

        public void CreateProcedimiento(Procedimiento procedimiento)
        {

            if (procedimiento == null)
            {
                throw new ArgumentNullException(nameof(procedimiento));
            }
            _context.Procedimientos.Add(procedimiento);

        }

        public bool EnumeradoExists(int enumeradoId)
        {
            return _context.Enumerados.Any(p => p.Id == enumeradoId);
        }

        public bool EnumeradoExternoExiste(int externalEnumeradoId)
        {
            return _context.Enumerados.Any(p => p.ExternalId == externalEnumeradoId);

        }

        public IEnumerable<BienPatrimonial> GetAllBienes()
        {
            return _context.BienesPatrimoniales.ToList();
        }

        public IEnumerable<Enumerado> GetAllEnumerados()
        {
            return _context.Enumerados.ToList();
        }

        public IEnumerable<Procedimiento> GetAllProcedimientos()
        {
            return _context.Procedimientos.ToList();
        }

        public BienPatrimonial GetBienById(int id)
        {
            return _context.BienesPatrimoniales.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<BienPatrimonial> GetBienesForEnumerados(int enumeradoId)
        {
            var retornito = _context.BienesPatrimoniales
                .Where(c => c.EnumeradoId == enumeradoId)
                .OrderBy(c => c.Enumerado.Valor);
            return retornito;
        }

        public IEnumerable<BienPatrimonial> GetBienesForProcedimientos(int procedimientoId)
        {
            var retornito = _context.BienesPatrimoniales
                .Where(c => c.ProcedimientoId == procedimientoId)
                .OrderBy(c => c.Procedimiento.NombreReferencial);
            return retornito;
        }

        public Procedimiento GetProcedimientoById(int procedimientoId)
        {
            return _context.Procedimientos.FirstOrDefault(p => p.Id == procedimientoId);
        }

        public bool ProcedimientoExists(int procedimientoId)
        {
            return _context.Procedimientos.Any(p => p.Id == procedimientoId);
        }

        public bool Save()
        {

            return _context.SaveChanges() >= 0;
        }
    }
}
