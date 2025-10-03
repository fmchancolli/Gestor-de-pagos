using Payment_manager.Application.DTOs;
using Payment_manager.Models.VentaModel;

namespace Payment_manager.Domain.Interfaces
{
    public interface IVentaService
    {
        Task<ServiceResponse> RegistrarVentaAsync(VentaViewModel model);
    }
}
