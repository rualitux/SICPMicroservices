using System.ComponentModel.DataAnnotations;

namespace InventarioService.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        public int? Cantidad { get; set; }
        public Enumerado AnexoTipo { get; set; }
        public Enumerado EstadoCondicion { get; set; }
        public Enumerado EstadoBien { get; set; }
    }
}
