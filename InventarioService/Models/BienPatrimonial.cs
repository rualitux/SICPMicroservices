namespace InventarioService.Models
{
    public class BienPatrimonial
    {
        public int Id { get; set; }
        public string? Denominacion { get; set; }
        public string? CodigoSBN { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Serie { get; set; }
        public string? Color { get; set; }
        public string? AtributoExtra { get; set; }
        public string? Observacion { get; set; }
        public int EnumeradoId { get; set; }
        public string? Categoria { get; set; }
        public Enumerado Enumerado { get; set; }
        //NavP Inventario
        public ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
        public ICollection<ProcedimientoBien> ProcedimientoBiens { get; set; } = new List<ProcedimientoBien>();


    }
}
