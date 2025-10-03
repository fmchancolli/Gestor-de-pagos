using Microsoft.AspNetCore.Mvc.RazorPages;
using Payment_manager.Domain.Enumerables;

namespace Payment_manager.Domain.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime FechaVenta { get; set; }
        public EstadoVenta Estado { get; set; }
        public decimal Total { get; set; }
        public decimal SaldoPendiente { get; set; }
        public ICollection<DetalleVenta> Detalles { get; set; }
        public ICollection<Pago> Pagos { get; set; }
    }
}
