namespace InventarioService.Dtos
{
    public class AreaReadDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? SedeString { get; set; }
        public string? DependenciaString { get; set; }
        public string? EstadoAreaString { get; set; }
    }
}
