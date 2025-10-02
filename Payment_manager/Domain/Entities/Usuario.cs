using Payment_manager.Domain.Enumerables;

namespace Payment_manager.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public RolUsuario Rol { get; set; }
        public bool Activo { get; set; } = true;

        public ICollection<Venta> Ventas { get; set; }
        public ICollection<Retiro> Retiros { get; set; }
        public ICollection<Comision> Comisiones { get; set; }

    }
}
