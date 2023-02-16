using InventarioService.Dtos;
using InventarioService.Models;

namespace InventarioService.Interfaces
{
    public interface IBienPatrimonialRepository
    {
        bool Save();
        //Enumerados
        IEnumerable<Enumerado> GetAllEnumerados();
        void CreateEnumerado(Enumerado enumerado);
        bool EnumeradoExists(int enumeradoId);
        bool EnumeradoExternoExiste(int externalEnumeradoId);

        //Bienes patrimoniales
        IEnumerable<BienPatrimonial> GetBienesForEnumerados (int enumeradoId);
        IEnumerable<BienPatrimonial> GetAllBienes();
        BienPatrimonial GetBienById(int id);
        void CreateBien(int enumeradoId, BienPatrimonial bien);
        bool BienExists(int bienPatrimonialId);


        //Procedimientos
        IEnumerable<Procedimiento> GetAllProcedimientos();
        void CreateProcedimiento(Procedimiento procedimiento);
        bool ProcedimientoExists(int procedimientoId);
        Procedimiento GetProcedimientoById(int procedimientoId);

        //Areas
        //IEnumerable<BienPatrimonial> GetBienesForAreas(int areaId);

        IEnumerable<Area> GetAllAreas();
        void CreateArea(int sedeId, int dependenciaId, int estadoAreaId, Area area);
        bool AreaExists(int areaId);
        Area GetAreaById(int areaId);

        //Inventarios
        IEnumerable<Inventario> GetInventariosForArea(int areaId);

        IEnumerable<Inventario> GetAllInventarios();
        void CreateInventario(int bienPatrimonialId, int areaId, int anexoTipoId, int estadoCondicionId, int estadoBienId, Inventario inventario);
        bool InventarioExists(int inventarioId);
        Inventario GetInventarioById(int inventarioId);

        //ProcedimientoBien
        IEnumerable<ProcedimientoBien> GetBienesByProcedimiento(int procedimientoId);
        IEnumerable<ProcedimientoBien> GetProcedimientosByBien(int bienPatrimonialId);


        IEnumerable<ProcedimientoBien> GetAllProcedimientoBienes();
        void CreateProcedimientoBien(int bienPatrimonialId, int procedimientoId, ProcedimientoBien procedimientoBien);
        bool ProcedimientoBienesExists(int procedimientoBienId);
        ProcedimientoBien GetProcedimientoBienById(int procedimientoBienId);
    }
}
