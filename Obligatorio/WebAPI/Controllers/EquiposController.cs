using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using ExcepcionesPropias.Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        public IListadoEquiposConPagosUnicosMayoresA CUListado { get; set; }

        public EquiposController(IListadoEquiposConPagosUnicosMayoresA cuListado)
        {
            CUListado = cuListado;
        }

        [Authorize(Roles = "Gerente")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<EquipoDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetEquiposConPagosUnicosMayoresA([FromQuery] double monto)
        {
            if (monto <= 0)
            {
                return BadRequest("El monto debe ser mayor a 0.");
            }

            try
            {
                var equipos = CUListado.ObtenerEquiposConPagosUnicosMayoresA(monto);
                var lista = equipos.ToList();

                if (lista.Count == 0)
                {
                    return NotFound("No hay equipos con pagos únicos mayores al monto indicado.");
                }

                return Ok(lista);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }
    }
}
