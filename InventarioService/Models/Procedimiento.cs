namespace InventarioService.Models
{
    public class Procedimiento
    {
        public int Id { get; set; }
        public string? NombreReferencial { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string? ProcedimientoTipoString { get; set; }
        public int? ProcedimientoTipoId { get; set; }
        public Enumerado? ProcedimientoTipo { get; set; }
        public string? CausalAltaString { get; set; }
        public int? CausalAltaId { get; set; }
        public Enumerado? CausalAlta { get; set; }
        public string? CausalBajaString { get; set; }
        public int? CausalBajaId { get; set; }
        public Enumerado? CausalBaja { get; set; }

    }
}
