using CarDealerAPI.Models.Es0Km;
using CarDealerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarDealerAPI.Controllers
{
    [ApiController]
    [Route("api/condiciones")]
    public class CondicionesController : ControllerBase
    {
        private readonly CondicionesService _condicionesService;

        public CondicionesController(CondicionesService condicionesService)
        {
            _condicionesService = condicionesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Condicion>>> GetAll()
        {
            var condiciones = await _condicionesService.GetAll();
            return Ok(condiciones);
        }
    }
}
