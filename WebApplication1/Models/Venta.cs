﻿namespace WebApplication1.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha_hora { get; set; }
        public decimal Total { get; set; }
        public string Cliente { get; set; } // Nuevo campo Cliente

        public List<Detalle_venta>? Detalle { get; set; }
    }

}
