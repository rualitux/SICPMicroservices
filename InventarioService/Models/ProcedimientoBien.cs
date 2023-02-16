namespace InventarioService.Models
{
    public class ProcedimientoBien
    {
        public int Id { get; set; }
        public string? BienPatrimonialString { get; set; }
        public string? CategoriaString { get; set; }
        public int BienPatrimonialId { get; set; }
        public BienPatrimonial BienPatrimonial { get; set; }
        public string? ProcedimientoString { get; set; }
        public string? CausalString { get; set; }
        public string? ProcedimientoTipoString { get; set; }
        public int ProcedimientoId { get; set; }
        public Procedimiento? Procedimiento { get; set; }
    }
}
