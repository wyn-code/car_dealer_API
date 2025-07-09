using CarDealerAPI.Models.Auto;
using CarDealerAPI.Models.Auto.Dto;
using CarDealerAPI.Models.Tipo_Auto;
using CarDealerAPI.Services;
using CarDealerAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace CarDealerAPI.Controllers
{
    [ApiController]
    [Route("api/tiposAutos")]
    public class TipoAutoControllers : Controller
    {
        private readonly TipoAutoServices _tipoAutoServ;

        public TipoAutoControllers(TipoAutoServices tipoAutoServ)
        {
            _tipoAutoServ = tipoAutoServ;
        }

        [HttpGet]
        public async Task<List<TipoDeAuto>> GetAll() 
        { 
            return await _tipoAutoServ.GetAll();
        }

    }
}
