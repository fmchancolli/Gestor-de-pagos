using Payment_manager.Application.Services;
using Payment_manager.Domain.Interfaces;

namespace Payment_manager.Application
{
    public static class ServiceExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddTransient<IVentaService, VentaService>();
        }
    }
}
