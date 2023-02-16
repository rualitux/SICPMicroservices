namespace InventarioService.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? SedeString { get; set; }
        public int? SedeId { get; set; }
        public Enumerado Sede { get; set; }
        public string? DependenciaString { get; set; }
        public int? DependenciaId { get; set; }
        public Enumerado Dependencia { get; set; }
        public string? EstadoAreaString { get; set; }
        public int? EstadoAreaId { get; set; }
        public Enumerado EstadoArea { get; set; }
    }
}
