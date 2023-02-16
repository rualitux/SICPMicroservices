namespace InventarioService.Dtos
{
    public class InventarioReadDto
    {
        public int Id { get; set; }
        public int? Cantidad { get; set; }
        public string? BienPatrimonialString { get; set; }       
        public string? AnexoTipoString { get; set; }         
        public string? EstadoBienString { get; set; }        
        public string? AreaString { get; set; }     
    }
}
