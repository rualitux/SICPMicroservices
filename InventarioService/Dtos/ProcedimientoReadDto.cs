namespace InventarioService.Dtos
{
    public class ProcedimientoReadDto
    {
        public int Id { get; set; }
        public string? NombreReferencial { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? NumeroGuia { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? ProcedimientoTipoString { get; set; }
        public string? CausalString { get; set; }        
    }
}
