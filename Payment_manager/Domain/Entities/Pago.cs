using Payment_manager.Domain.Enumerables;

namespace Payment_manager.Domain.Entities
{
    public class Pago
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int VentaId { get; set; }
        public Venta Venta { get; set; }

        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public TipoAbono TipoAbono { get; set; }
        public EstadoPago Estado { get; set; }
    }
}
