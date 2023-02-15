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
        void CreateBien(int enumeradoId, int procedimientoId, BienPatrimonial bien);

        //Procedimientos
        IEnumerable<BienPatrimonial> GetBienesForProcedimientos(int procedimientoId);

        IEnumerable<Procedimiento> GetAllProcedimientos();
        void CreateProcedimiento(Procedimiento procedimiento);
        bool ProcedimientoExists(int procedimientoId);
        Procedimiento GetProcedimientoById(int procedimientoId);

    }
}
