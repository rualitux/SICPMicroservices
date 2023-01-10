namespace EnumeradoService.Models
{
    public class EnumeradoJerarquia
    {
        public int? AncestroId { get; set; }


        public Enumerado? Ancestro { get; set; }
        public int? DescendienteId { get; set; }

        public Enumerado? Descendiente { get; set; }
    }
}
