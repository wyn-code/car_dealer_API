using CarDealerAPI.Models.Modelos;
using CarDealerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerAPI.Controllers
{
    [ApiController]
    [Route("api/modelos")]
    public class ModeloController : ControllerBase
    {
        private readonly ModeloServices _modeloServices;

        public ModeloController(ModeloServices modeloServices)
        {
            _modeloServices = modeloServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var modelos = await _modeloServices.GetAll();
                return Ok(modelos);
            }
            catch (Exception ex)
            {
                // Loguear el error en consola o logger (opcional)
                return StatusCode(500, $"Error al obtener modelos: {ex.Message}");
            }
        }
    }
}
