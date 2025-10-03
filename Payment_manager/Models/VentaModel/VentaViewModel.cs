using Payment_manager.Domain.Enumerables;

namespace Payment_manager.Models.VentaModel
{
    public class VentaViewModel
    {
        public int ClienteId { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;

        public List<DetalleVentaViewModel> Detalles { get; set; } = new();
        public decimal Total => Detalles.Sum(d => d.Cantidad * d.PrecioUnitario);
        public bool EsContado { get; set; }=false;
        public bool EsCredito { get; set; }
        public bool EsSemiContado => !EsContado && !EsCredito;
        public decimal MontoAbonado { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public decimal SaldoPendiente => Total - MontoAbonado;

    }
    public class DetalleVentaViewModel
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }


}
