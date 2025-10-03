using Microsoft.EntityFrameworkCore;
using Payment_manager.Application.Data;
using Payment_manager.Application.DTOs;
using Payment_manager.Domain.Entities;
using Payment_manager.Domain.Enumerables;
using Payment_manager.Domain.Interfaces;
using Payment_manager.Models.VentaModel;

namespace Payment_manager.Application.Services
{
    public class VentaService: IVentaService
    {
        private readonly AppDbContext _context;

        public VentaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> RegistrarVentaAsync(VentaViewModel model)
        {
            try
            {
                if (model.Detalles == null || !model.Detalles.Any())
                    return ServiceResponseResult.SetWarningResponse("La venta debe tener al menos un producto.");

                var clienteExiste = await _context.Clientes.AnyAsync(c => c.Id == model.ClienteId);
                if (!clienteExiste)
                    return ServiceResponseResult.SetWarningResponse("El cliente no existe.");

                var productosValidos = await _context.Productos
                    .Where(p => model.Detalles.Select(d => d.ProductoId).Contains(p.Id))
                    .Select(p => p.Id)
                    .ToListAsync();

                if (productosValidos.Count != model.Detalles.Count)
                    return ServiceResponseResult.SetWarningResponse("Uno o más productos no son válidos.");

                foreach (var detalle in model.Detalles)
                {
                    var producto = await _context.Productos.FindAsync(detalle.ProductoId);
                    if (producto.Stock < detalle.Cantidad)
                        return ServiceResponseResult.SetWarningResponse($"Stock insuficiente para el producto {producto.Nombre}.");
                }

                var productosDuplicados = model.Detalles
                    .GroupBy(d => d.ProductoId)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key)
                    .ToList();

                if (productosDuplicados.Any())
                    return ServiceResponseResult.SetWarningResponse("No puedes repetir productos en la misma venta.");

                if (model.Detalles.Any(d => d.Cantidad <= 0 || d.PrecioUnitario <= 0))
                    return ServiceResponseResult.SetWarningResponse("Las cantidades y precios deben ser mayores a cero.");


                var total = model.Detalles.Sum(d => d.Cantidad * d.PrecioUnitario);
                var saldoRestante = total - model.MontoAbonado;

                if (model.MontoAbonado > total)
                    return ServiceResponseResult.SetWarningResponse("El anticipo no puede ser mayor al total de la venta.");
                var venta = new Venta
                {
                  
                    ClienteId = model.ClienteId,
                    FechaVenta = DateTime.Now,
                    Total = total,
                    SaldoPendiente = saldoRestante,
                    Detalles = model.Detalles.Select(d => new DetalleVenta
                    {
                        ProductoId = d.ProductoId,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario
                    }).ToList()
                };

                _context.Ventas.Add(venta);
                //agregamos pago si se efectuo alguno
                if (model.MontoAbonado > 0)
                {
                    var pago = new Pago
                    {
                        ClienteId = model.ClienteId,
                        Venta = venta,
                        FechaPago = DateTime.Now,
                        Monto = model.MontoAbonado,
                        MetodoPago = model.MetodoPago,
                        TipoAbono = model.EsContado ? TipoAbono.Total : TipoAbono.Parcial,
                        Estado = model.EsContado ? EstadoPago.Completado : EstadoPago.Pendiente
                    };
                    _context.Pagos.Add(pago);

                    venta.Estado = model.EsContado ? EstadoVenta.Pagada : EstadoVenta.Parcial;
                }
                else if (model.EsCredito)
                {
                    venta.Estado = EstadoVenta.Pendiente;
                }

                foreach (var detalle in venta.Detalles)
                {
                    var producto = await _context.Productos.FindAsync(detalle.ProductoId);
                    producto.Stock -= detalle.Cantidad;
                }

                await _context.SaveChangesAsync();

                return ServiceResponseResult.SetOkResponse("Venta registrada",venta.Id);
            }
            catch (Exception ex)
            {

                return ServiceResponseResult.SetErrorResponse(ex.Message);
            }


        }

    }
}
