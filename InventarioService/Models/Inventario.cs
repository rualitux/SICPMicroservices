using System.ComponentModel.DataAnnotations;

namespace InventarioService.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        public int? Cantidad { get; set; }
        public string? BienPatrimonialString { get; set; }
        public int BienPatrimonialId { get; set; }
        public BienPatrimonial BienPatrimonial { get; set; }
        public string? AnexoTipoString { get; set; }
        public int AnexoTipoId { get; set; }
        public Enumerado AnexoTipo { get; set; }
        public string? EstadoCondicionString { get; set; }
        public int EstadoCondicionId { get; set; }
        public Enumerado EstadoCondicion { get; set; }
        public string? EstadoBienString { get; set; }
        public int EstadoBienId { get; set; }
        public Enumerado EstadoBien { get; set; }
        public string? AreaString { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
      

    }
}
