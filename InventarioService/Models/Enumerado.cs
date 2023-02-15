namespace InventarioService.Models
{
    public class Enumerado
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public string Valor { get; set; }
        public string? Descripcion { get; set; }
        public ICollection<BienPatrimonial> BienesPatrimoniales { get; set; } = new List<BienPatrimonial>();
        public ICollection<Procedimiento> ProcedimientoTipos { get; set; } = new List<Procedimiento>();
        public ICollection<Procedimiento> CausalAltas { get; set; } = new List<Procedimiento>();
        public ICollection<Procedimiento> CausalBajas { get; set; } = new List<Procedimiento>();




    }
}
