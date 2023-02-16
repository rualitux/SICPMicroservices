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

        public bool AreaExists(int areaId)
        {
         return _context.Areas.Any(p => p.Id == areaId);

        }

        public bool BienExists(int bienPatrimonialId)
        {
            return _context.BienesPatrimoniales.Any(p => p.Id == bienPatrimonialId);
        }

        public void CreateArea(int sedeId, int dependenciaId, int estadoAreaId, Area area)
        {
            if (area == null)
            {
                throw new ArgumentNullException(nameof(area));
            }
            var sedeString = _context.Enumerados.Where(p => p.Id == sedeId)
                .Select(x => x.Valor).Single();
            var dependenciaString = _context.Enumerados.Where(p => p.Id == dependenciaId)
                .Select(x => x.Valor).Single();
            var estadoAreaString = _context.Enumerados.Where(p => p.Id == estadoAreaId)
              .Select(x => x.Valor).Single();
            area.SedeId = sedeId;
            area.DependenciaId = dependenciaId;
            area.EstadoAreaId = estadoAreaId;
            area.SedeString = sedeString;
            area.DependenciaString = dependenciaString;
            area.EstadoAreaString = estadoAreaString;                      

            _context.Areas.Add(area);
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
        public void CreateBien(int enumeradoId, BienPatrimonial bien)
        {
            if (bien == null)
            {
                throw new ArgumentNullException(nameof(bien));
            }
            var categoria = _context.Enumerados.Where(p => p.Id == enumeradoId)
                .Select(x => x.Valor).Single();           
            bien.Categoria = categoria;           
            bien.EnumeradoId = enumeradoId;          
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

        public void CreateInventario(int bienPatrimonialId, int areaId, int anexoTipoId,
            int estadoCondicionId, int estadoBienId, Inventario inventario)
        {
            if (inventario == null)
            {
                throw new ArgumentNullException(nameof(inventario));
            }
            var bienPatrimonialString = _context.BienesPatrimoniales.Where(p => p.Id == bienPatrimonialId)
                .Select(x => x.Denominacion).Single();
            var areaString = _context.Areas.Where(p => p.Id == areaId)
                .Select(x => x.Nombre).Single();
            var anexoTipoString = _context.Enumerados.Where(p => p.Id == anexoTipoId)
                .Select(x => x.Valor).Single();
            var estadoCondicionString = _context.Enumerados.Where(p => p.Id == estadoCondicionId)
              .Select(x => x.Valor).Single();
            var estadoBienString = _context.Enumerados.Where(p => p.Id == estadoBienId)
           .Select(x => x.Valor).Single();
            inventario.BienPatrimonialId = bienPatrimonialId;
            inventario.BienPatrimonialString = bienPatrimonialString;
            inventario.AreaId = areaId;
            inventario.AreaString = areaString;
            inventario.AnexoTipoId = anexoTipoId;
            inventario.AnexoTipoString = anexoTipoString;
            inventario.EstadoCondicionId = estadoCondicionId;
            inventario.EstadoCondicionString = estadoCondicionString;
            inventario.EstadoBienId = estadoBienId;
            inventario.EstadoBienString = estadoBienString;
            _context.Inventarios.Add(inventario);
        }

        public void CreateProcedimiento(Procedimiento procedimiento)
        {

            if (procedimiento == null)
            {
                throw new ArgumentNullException(nameof(procedimiento));
            }
            _context.Procedimientos.Add(procedimiento);

        }

        public void CreateProcedimientoBien(int bienPatrimonialId, int procedimientoId, ProcedimientoBien procedimientoBien)
        {
            if (procedimientoBien == null)
            {
                throw new ArgumentNullException(nameof(procedimientoBien));
            }
            var bienPatrimonialString = _context.BienesPatrimoniales.Where(p => p.Id == bienPatrimonialId)
                .Select(x => x.Denominacion).Single();
            var categoriaString = _context.BienesPatrimoniales.Where(p => p.Id == bienPatrimonialId)
               .Select(x => x.Categoria).Single();
            var procedimientoString = _context.Procedimientos.Where(p => p.Id == procedimientoId)
                .Select(x => x.NombreReferencial).Single();           
            var tipoProcedimientoString = _context.Procedimientos.Where(p => p.Id == procedimientoId)
              .Select(x => x.ProcedimientoTipoString).Single();
            var causalString = _context.Procedimientos.Where(p => p.Id == procedimientoId)
           .Select(x => x.CausalString).Single();
            procedimientoBien.BienPatrimonialId = bienPatrimonialId;
            procedimientoBien.BienPatrimonialString = bienPatrimonialString;
            procedimientoBien.CategoriaString = categoriaString;
            procedimientoBien.ProcedimientoId = procedimientoId;
            procedimientoBien.ProcedimientoString = procedimientoString;
            procedimientoBien.ProcedimientoTipoString = tipoProcedimientoString;
            procedimientoBien.CausalString = causalString;
            _context.ProcedimientoBiens.Add(procedimientoBien);

        }

        public bool EnumeradoExists(int enumeradoId)
        {
            return _context.Enumerados.Any(p => p.Id == enumeradoId);
        }

        public bool EnumeradoExternoExiste(int externalEnumeradoId)
        {
            return _context.Enumerados.Any(p => p.ExternalId == externalEnumeradoId);

        }

        public IEnumerable<Area> GetAllAreas()
        {
            return _context.Areas.ToList();
        }

        public IEnumerable<BienPatrimonial> GetAllBienes()
        {
            return _context.BienesPatrimoniales.ToList();
        }

        public IEnumerable<Enumerado> GetAllEnumerados()
        {
            return _context.Enumerados.ToList();
        }

        public IEnumerable<Inventario> GetAllInventarios()
        {
            return _context.Inventarios.ToList();
        }

        public IEnumerable<ProcedimientoBien> GetAllProcedimientoBienes()
        {
            return _context.ProcedimientoBiens.ToList();

        }

        public IEnumerable<Procedimiento> GetAllProcedimientos()
        {
            return _context.Procedimientos.ToList();
        }

        public Area GetAreaById(int areaId)
        {
            return _context.Areas.FirstOrDefault(p => p.Id == areaId);

        }

        public BienPatrimonial GetBienById(int id)
        {
            return _context.BienesPatrimoniales.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ProcedimientoBien> GetBienesByProcedimiento(int procedimientoId)
        {
            var retornito = _context.ProcedimientoBiens
               .Where(c => c.ProcedimientoId == procedimientoId)
               .OrderBy(c => c.Procedimiento.ProcedimientoTipoString);
            return retornito;
        }

        public IEnumerable<BienPatrimonial> GetBienesForEnumerados(int enumeradoId)
        {
            var retornito = _context.BienesPatrimoniales
                .Where(c => c.EnumeradoId == enumeradoId)
                .OrderBy(c => c.Enumerado.Valor);
            return retornito;
        }



        public Inventario GetInventarioById(int inventarioId)
        {
         return _context.Inventarios.FirstOrDefault(p => p.Id == inventarioId);

        }

        public IEnumerable<Inventario> GetInventariosForArea(int areaId)
        {
            var retornito = _context.Inventarios
                           .Where(c => c.AreaId == areaId)
                           .OrderBy(c => c.Area.Nombre);
            return retornito;

        }

        public ProcedimientoBien GetProcedimientoBienById(int procedimientoBienId)
        {
            return _context.ProcedimientoBiens.FirstOrDefault(p => p.Id == procedimientoBienId);
        }

        public Procedimiento GetProcedimientoById(int procedimientoId)
        {
            return _context.Procedimientos.FirstOrDefault(p => p.Id == procedimientoId);
        }

        public IEnumerable<ProcedimientoBien> GetProcedimientosByBien(int bienPatrimonialId)
        {
            var retornito = _context.ProcedimientoBiens
              .Where(c => c.BienPatrimonialId == bienPatrimonialId)
              .OrderBy(c => c.BienPatrimonial.Categoria);
            return retornito;
        }

        public bool InventarioExists(int inventarioId)
        {
            return _context.Inventarios.Any(p => p.Id == inventarioId);

        }

        public bool ProcedimientoBienesExists(int procedimientoBienId)
        {
            return _context.ProcedimientoBiens.Any(p => p.Id == procedimientoBienId);
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
