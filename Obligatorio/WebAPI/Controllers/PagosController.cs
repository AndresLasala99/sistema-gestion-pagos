using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using ExcepcionesPropias.Excepciones;
using LogicaAplicacion.CasosUso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        public IBuscarPagoPorId CUBuscarPorId { get; set; }
        public IAltaPago CUAlta {  get; set; }
        public PagosController(IBuscarPagoPorId cuBuscar, IAltaPago cUAlta)
        {
            CUBuscarPorId = cuBuscar;
            CUAlta = cUAlta;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El id debe ser un número positivo mayor a 0.");
            }

            try
            {
                PagoDTO dto = CUBuscarPorId.Buscar(id);

                if (dto == null)
                {
                    return NotFound("El pago con id " + id + " no existe.");
                }
                return Ok(dto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type = typeof(string))]
        public IActionResult Post([FromBody] PagoDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Los datos del pago son requeridos.");
            }

            try
            {
                CUAlta.EjecutarAlta(dto);
                return StatusCode(201, "Pago creado correctamente.");
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado al dar de alta el pago.");
            }
        }
    }
}
