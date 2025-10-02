using Payment_manager.Domain.Enumerables;

namespace Payment_manager.Domain.Entities
{
    public class Retiro
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
        public TipoRetiro Tipo { get; set; }
    }
}
