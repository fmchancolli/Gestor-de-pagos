using Payment_manager.Domain.Enumerables;

namespace Payment_manager.Domain.Entities
{
    public class CajaChica
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TipoMovimiento Tipo { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
    }
}
