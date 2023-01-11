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

        //Bienes patrimoniales
        IEnumerable<BienPatrimonial> GetBienesForEnumerados (int enumeradoId);
        IEnumerable<BienPatrimonial> GetAllBienes();
        BienPatrimonial GetBienById(int id);
        void CreateBien(int enumeradoId,BienPatrimonial bien);
    }
}
