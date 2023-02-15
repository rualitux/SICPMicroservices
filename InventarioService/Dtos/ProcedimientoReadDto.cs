namespace InventarioService.Dtos
{
    public class ProcedimientoReadDto
    {
        public int Id { get; set; }
        public string? NombreReferencial { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? ProcedimientoTipoString { get; set; }
        public int? ProcedimientoTipoId { get; set; }      
        public string? CausalAltaString { get; set; }
        public int? CausalAltaId { get; set; }
        public string? CausalBajaString { get; set; }
        public int? CausalBajaId { get; set; }
    }
}
