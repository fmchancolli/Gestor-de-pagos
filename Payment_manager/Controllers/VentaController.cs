using Microsoft.AspNetCore.Mvc;
using Payment_manager.Common.Response;
using Payment_manager.Domain.Interfaces;
using Payment_manager.Models.VentaModel;

namespace Payment_manager.Controllers
{
    public class VentaController : Controller
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        [HttpPost]
        public async Task< IActionResult> Create(VentaViewModel model)
        { 
            if(!ModelState.IsValid)
                return View(model);
           var result= await _ventaService.RegistrarVentaAsync(model);
            if(result.Status==Application.DTOs.EStatusResponse.Ok)
                return Json(WebResult.Success("Proceso finalizado", result.Message));
            else
                return Json(WebResult.Warning("Proceso finalizado", result.Message));

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
