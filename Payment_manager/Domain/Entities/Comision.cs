using Payment_manager.Domain.Enumerables;

namespace Payment_manager.Domain.Entities
{
    public class Comision
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Monto { get; set; }
        public TipoComision Tipo { get; set; }
    }
}
