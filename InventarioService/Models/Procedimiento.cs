namespace InventarioService.Models
{
    public class Procedimiento
    {
        public int Id { get; set; }
        public string? NombreReferencial { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? NumeroGuia { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public DateTime? FechaRegistro { get; set; }   
        public string? ProcedimientoTipoString { get; set; }
        public int? ProcedimientoTipoId { get; set; }
        public Enumerado? ProcedimientoTipo { get; set; }
        public string? CausalString { get; set; }
        public int? CausalId { get; set; }
        public Enumerado? Causal { get; set; }        
        public ICollection<ProcedimientoBien> ProcedimientoBiens { get; set; } = new List<ProcedimientoBien>();


    }
}
