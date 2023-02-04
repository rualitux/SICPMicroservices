﻿namespace MovimientoService.Models
{
    public class Movimiento
    {
        public int Id { get; set; }
        public string? FechaMonvimiento { get; set; }
        public string? AreaDestino { get; set; }
        public string? AreaOrigen { get; set; }  
        public string? TipoMoviento { get; set; }    
        public string? JustiMovimiento { get; set; }
    }
}
