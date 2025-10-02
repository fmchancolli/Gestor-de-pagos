namespace Payment_manager.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Stock { get; set; } = 0;
        public decimal? CostoCompra { get; set; }
        public decimal? PrecioContado { get; set; }
        public decimal? PrecioSemiContado { get; set; }
        public decimal? PrecioCredito { get; set; }
        public DateTime FechaIngreso { get; set; }

        public ICollection<DetalleVenta> DetallesVenta { get; set; }
    }
}
