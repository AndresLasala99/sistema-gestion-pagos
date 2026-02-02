using CasosUso.DTOs;
using CasosUso.InterfacesCU;
using ExcepcionesPropias.Excepciones;
using LogicaAplicacion.CasosUso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPI.JWT;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IListadoPagosDeUnUsuario CUListado { get; set; }
        public ILoginUsuario CULogin { get; set; }
        public IResetearPass CUResetear { get; set; }
        public IListadoUsuarios CUListadoUsuarios { get; set; }

        public UsuariosController(IListadoPagosDeUnUsuario cuListado, ILoginUsuario cuLogin, IResetearPass cUResetear, IListadoUsuarios cUListadoUsuarios)
        {
            CUListado = cuListado;
            CUResetear = cUResetear;
            CULogin = cuLogin;
            CUListadoUsuarios = cUListadoUsuarios;
        }

        [Authorize(Roles = "Empleado,Gerente")]
        [HttpGet("{id}/pagos")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<PagoDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult GetPagosDeUsuario(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El id de usuario debe ser un número positivo mayor a 0.");
            }

            try
            {
                var pagos = CUListado.ObtenerPagosDeUnUsuario(id);
                var lista = pagos.ToList();
                if (lista.Count == 0)
                {
                    return NotFound("El usuario no tiene pagos registrados.");
                }
                return Ok(lista);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }


        [Authorize(Roles = "Administrador")]
        [HttpPost("{id}/reset-password")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(UsuarioDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult ResetearPass(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El id de usuario debe ser mayor a 0.");
            }

            try
            {
                UsuarioDTO dto = CUResetear.Ejecutar(id);
                return Ok(dto);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(UsuarioDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type = typeof(string))]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            try
            {
                UsuarioDTO buscado = CULogin.Login(dto.Mail, dto.Pass);

                if (buscado == null)
                    return Unauthorized("Email o contraseña inválidos.");

                string token = ManejadorJWT.GenerarToken(buscado);
                buscado.TokenJWT = token;

                return Ok(buscado);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ha ocurrido un error inesperado.");
            }
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<UsuarioDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<UsuarioDTO> usuarios = CUListadoUsuarios.ObtenerListadoUsuarios();
                return Ok(usuarios);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }
    }
}
