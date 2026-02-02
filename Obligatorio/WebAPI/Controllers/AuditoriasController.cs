using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using LogicaNegocio.EntidadesDominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriasController : ControllerBase
    {
        public IListadoAuditoriasDeUnTipoDeGasto CUListado { get; set; }
        public IBuscarGastoPorId CUBuscar { get; set; }
        public AuditoriasController(IListadoAuditoriasDeUnTipoDeGasto cUListado, IBuscarGastoPorId cUBuscar)
        {
            CUListado = cUListado;
            CUBuscar = cUBuscar;
        }

        [Authorize(Roles ="Administrador")]
        [HttpGet("gastos/{idGasto}")]

        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<AuditoriaDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetPorTipoDeGasto(int idGasto)
        {
            if (idGasto <= 0)
            {
                return BadRequest("El id del tipo de gasto debe ser un número positivo mayor a 0.");
            }

            try
            {
                GastoDTO g = CUBuscar.Buscar(idGasto);

                if (g == null)
                {
                    return BadRequest("No existe tipo de gasto con ese Id.");
                }

                var auditorias = CUListado.ObtenerAuditoriasDeUnTipoDeGasto(idGasto);

                var lista = auditorias.ToList();
                if (lista.Count == 0)
                {
                    return NotFound("No hay operaciones registradas para el tipo de gasto indicado.");
                }

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado: " + ex.Message);
            }
        }
    }
}
