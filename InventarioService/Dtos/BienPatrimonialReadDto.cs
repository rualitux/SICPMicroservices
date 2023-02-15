﻿namespace InventarioService.Dtos
{
    public class BienPatrimonialReadDto
    {
        public int Id { get; set; }
        public string? Denominacion { get; set; }
        public string? CodigoSBN { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Color { get; set; }
        public string? AtributoExtra { get; set; }
        public string? Observacion { get; set; }
        public string? Categoria { get; set; }
        public int ProcedimientoId { get; set; }
        public string? ProcedimientoNombre { get; set; }

    }
}
