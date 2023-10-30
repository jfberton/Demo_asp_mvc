namespace WebApplication1.Models
{
    public class Detalle_venta
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total_linea { get; set; }

        public int VentaId { get; set; }

    }
}
