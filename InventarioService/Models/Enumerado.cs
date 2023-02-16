namespace InventarioService.Models
{
    public class Enumerado
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public string Valor { get; set; }
        public string? Descripcion { get; set; }
        //NavP BienesPatrimoniales (Categorías)
        public ICollection<BienPatrimonial> BienesPatrimoniales { get; set; } = new List<BienPatrimonial>();
        //NavP Procedimientos
        public ICollection<Procedimiento> ProcedimientoTipos { get; set; } = new List<Procedimiento>();
        public ICollection<Procedimiento> Causals { get; set; } = new List<Procedimiento>();
        //NavP Areas
        public ICollection<Area> Sedes { get; set; } = new List<Area>();
        public ICollection<Area> Dependencias { get; set; } = new List<Area>();
        public ICollection<Area> EstadoAreas { get; set; } = new List<Area>();
        //NavP Inventarios
        public ICollection<Inventario> AnexoTipos { get; set; } = new List<Inventario>();
        public ICollection<Inventario> EstadoCondicions { get; set; } = new List<Inventario>();

        public ICollection<Inventario> EstadoBiens { get; set; } = new List<Inventario>();








    }
}
