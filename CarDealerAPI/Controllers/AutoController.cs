using Car_DealerShip_Proyect.Models.Auto;
using Car_DealerShip_Proyect.Models.Auto.Dto;
using Car_DealerShip_Proyect.Services;
using Car_DealerShip_Proyect.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;


namespace Car_DealerShip_Proyect.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/Car-DealerShip-Proyect")]
    public class AutoController : ControllerBase
    {
        private readonly AutoServices _autoServices; // Asegúrate de que esta interfaz esté definida
        public AutoController(AutoServices autoServices)
        {
            _autoServices = autoServices;
        }
        /*
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
        */
        [HttpGet]
        public async Task<List<AllAutoDTO>> GetAll()
        {
            return await _autoServices.GetAll();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpMessage))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(HttpMessage))]
        public async Task<ActionResult<Auto>> GetAuto(int id)
        {
            try
            {
                return await _autoServices.GetOneById(id);
            }
            catch (HttpError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage("Algo salio mal"));
            }
        }
    }

}
