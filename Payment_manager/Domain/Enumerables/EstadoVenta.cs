namespace Payment_manager.Domain.Enumerables
{
    public enum RolUsuario
    {
        Administrador = 0,
        Cobrador = 1
    }

    public enum EstadoVenta
    {
        Pendiente = 0,
        Pagada = 1,
        Cancelada = 2,
        Parcial= 3

    }

    public enum TipoAbono
    {
        Total = 0,
        Parcial = 1
    }

    public enum EstadoPago
    {
        Completado = 0,
        Vencido = 1,
        Pendiente= 2
    }

    public enum TipoRetiro
    {
        Reinversion = 0,
        PagoCobrador = 1
    }

    public enum TipoComision
    {
        Salario = 0,
        Comision = 1
    }

    public enum TipoMovimiento
    {
        Salida = 0,
        Entrada = 1
    }
    public enum MetodoPago
    {
        Efectivo = 0,
        Transferencia = 1,
        Tarjeta = 2,
        Deposito = 3
    }
}
