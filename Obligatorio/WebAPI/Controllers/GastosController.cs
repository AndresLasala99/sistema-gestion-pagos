using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.Mappers;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class GastosController : ControllerBase  
{
    public IListadoGastos CUListado { get; set; }

    public GastosController(IListadoGastos cuListado)
    {
        CUListado = cuListado;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<GastoDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError,Type = typeof(string))]
    public IActionResult Get()
    {
        try
        {
            IEnumerable<GastoDTO> dto = CUListado.ObtenerListadoGastos();
            return Ok(dto);
        }
        catch (Exception)
        {
            return StatusCode(500, "Ocurrió un error inesperado.");
        }
    }
}