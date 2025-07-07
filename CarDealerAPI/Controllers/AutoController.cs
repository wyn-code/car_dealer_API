using CarDealerAPI.Models.Auto;
using CarDealerAPI.Services;
using CarDealerAPI.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


namespace CarDealerAPI.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class AutoController : ControllerBase
    {
        private readonly AutoServices _autoServices; // Asegúrate de que esta interfaz esté definida
        public AutoController(AutoServices autoServices)
        {
            _autoServices = autoServices;
        }

        [HttpGet]
        //public List<Auto> GetAutos()
        //{
        //    return _autoServices.GetAll();
        //}

        [HttpDelete("{Id_Autos}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpMessage))]
        public async Task<ActionResult> Delete(int Id_Autos)
        {
            try
            {
                await _autoServices.DeleteOneById(Id_Autos); // Asegúrate de que este método esté implementado
                return Ok(new HttpMessage($"Auto con ID = {Id_Autos} eliminado correctamente."));
            }
            catch (HttpError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
        }
    }

}
