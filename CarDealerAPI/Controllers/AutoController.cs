using CarDealerAPI.Models.Auto;
using CarDealerAPI.Models.Auto.Dto;
using CarDealerAPI.Services;
using CarDealerAPI.Utils;
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpMessage))]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _autoServices.DeleteOneById(id); // Asegúrate de que este método esté implementado
                return Ok(new HttpMessage($"Auto con ID = {id} eliminado correctamente."));
            }
            catch (HttpError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
        }

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


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Auto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(HttpMessage))]

        public async Task<ActionResult> Create([FromBody] CreateAutoDTO auto)
        {
            try
            {
                var createdAuto = await _autoServices.CreateOne(auto);
                return Created("api/cars", createdAuto);
            }
            catch (HttpError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage($"Error al crear el auto"));
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Auto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(HttpMessage))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(HttpMessage))]
        public async Task<ActionResult<Auto>> Update(int id, [FromBody] UpdateAutoDTO auto)
        {
            try
            {
                var updatedAuto = await _autoServices.UpdateAuto(id, auto);
                return Ok(updatedAuto);
            }
            catch (HttpError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch (Exception ex) // 👈 ahora capturás el detalle real
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Algo salió mal actualizando el auto con ID = {id}",
                    error = ex.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }
    }
}
