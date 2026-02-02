using ClienteHttpMVC.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace ClienteHttpMVC.Controllers
{
    public class UsuariosController : Controller
    {
        private string URLApiUsuarios { get; set; }

        public UsuariosController(IConfiguration config, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                URLApiUsuarios = config.GetValue<string>("URLApiUsuarios");
            }
            if (env.IsProduction())
            {
                URLApiUsuarios = config.GetValue<string>("URLApiUsuariosAzure");
            }
        }

        [HttpGet]
        public ActionResult Pagos(int? idUsuario)
        {
            IEnumerable<PagoDTO> pagos = new List<PagoDTO>();
            ViewBag.IdUsuario = idUsuario;
            ViewBag.Error = null;

            string token = HttpContext.Session.GetString("Token");
            string rol = HttpContext.Session.GetString("Rol");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login");
            }

            if (rol != "Empleado" && rol != "Gerente")
            {
                return Forbid();
            }

            CargarUsuariosEnViewBag(token);

            if (!idUsuario.HasValue)
            {
                return View(pagos);
            }

            if (idUsuario < 0)
            {
                ViewBag.Error = "El Id de usuario debe ser mayor a 0.";
                return View(pagos);
            }

            try
            {
                HttpClient cliente = new HttpClient();

                cliente.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                string url = URLApiUsuarios + "/" + idUsuario + "/pagos";

                HttpResponseMessage respuesta = cliente.GetAsync(url).Result;
                string body = respuesta.Content.ReadAsStringAsync().Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    pagos = JsonConvert.DeserializeObject<List<PagoDTO>>(body);
                    return View(pagos);
                }

                if (respuesta.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Unauthorized();
                }

                if (respuesta.StatusCode == HttpStatusCode.Forbidden)
                {
                    return Forbid();
                }

                if (string.IsNullOrWhiteSpace(body))
                {
                    ViewBag.Error = "Error de la API. Status: " + (int)respuesta.StatusCode;
                }
                else
                {
                    ViewBag.Error = body;
                }

                return View(pagos);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error contactando la API: " + ex.Message;
                return View(pagos);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new UsuarioDTO());
        }

        [HttpPost]
        public IActionResult Login(UsuarioDTO dto)
        {
            try
            {
                HttpClient cliente = new HttpClient();

                string json = JsonConvert.SerializeObject(dto);
                StringContent contenido = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage resp = cliente.PostAsync(URLApiUsuarios + "/login", contenido).Result;
                string body = resp.Content.ReadAsStringAsync().Result;

                if (resp.IsSuccessStatusCode)
                {
                    UsuarioDTO usuario = JsonConvert.DeserializeObject<UsuarioDTO>(body);

                    HttpContext.Session.SetString("Token", usuario.TokenJWT);
                    HttpContext.Session.SetString("Rol", usuario.RolSesion);
                    HttpContext.Session.SetString("Mail", usuario.Mail);
                    HttpContext.Session.SetInt32("IdUsuario", usuario.Id);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = body;
                    return View(dto);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error contactando la API: " + ex.Message;
                return View(dto);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult ResetPass()
        {
            string token = HttpContext.Session.GetString("Token");
            string rol = HttpContext.Session.GetString("Rol");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login");
            }

            if (rol != "Administrador")
            {
                return Forbid();
            }

            ViewBag.Error = null;
            ViewBag.Mensaje = null;

            CargarUsuariosEnViewBag(token);

            return View();
        }

        [HttpPost]
        public IActionResult ResetPass(int id)
        {
            string token = HttpContext.Session.GetString("Token");
            string rol = HttpContext.Session.GetString("Rol");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login");
            }

            if (rol != "Administrador")
            {
                return Forbid();
            }

            ViewBag.Error = null;
            ViewBag.Mensaje = null;

            if (id <= 0)
            {
                ViewBag.Error = "Debe seleccionar un usuario válido.";
                CargarUsuariosEnViewBag(token);
                return View();
            }

            try
            {
                HttpClient cliente = new HttpClient();
                cliente.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                string url = URLApiUsuarios + "/" + id + "/reset-password";

                StringContent contenido = new StringContent("{}", Encoding.UTF8, "application/json");

                HttpResponseMessage resp = cliente.PostAsync(url, contenido).Result;

                string body = "";
                if (resp.Content != null)
                {
                    body = resp.Content.ReadAsStringAsync().Result;
                }

                if (resp.IsSuccessStatusCode)
                {
                    UsuarioDTO usuario = null;

                    if (!string.IsNullOrWhiteSpace(body))
                    {
                        usuario = JsonConvert.DeserializeObject<UsuarioDTO>(body);
                    }

                    if (usuario != null && !string.IsNullOrEmpty(usuario.Pass))
                    {
                        ViewBag.Mensaje = "La nueva contraseña de " + usuario.Mail +
                                          " es: " + usuario.Pass;
                    }
                    else
                    {
                        ViewBag.Mensaje = "La contraseña fue reseteada correctamente.";
                    }

                    CargarUsuariosEnViewBag(token);
                    return View();
                }

                if (resp.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Unauthorized();
                }

                if (resp.StatusCode == HttpStatusCode.Forbidden)
                {
                    return Forbid();
                }

                CargarUsuariosEnViewBag(token);
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error contactando la API: " + ex.Message;
                CargarUsuariosEnViewBag(token);
                return View();
            }
        }

        private void CargarUsuariosEnViewBag(string token)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage resp = cliente.GetAsync(URLApiUsuarios).Result;
                string body = resp.Content.ReadAsStringAsync().Result;

                List<UsuarioDTO> usuarios = new List<UsuarioDTO>();

                if (resp.IsSuccessStatusCode)
                {
                    usuarios = JsonConvert.DeserializeObject<List<UsuarioDTO>>(body);
                    ViewBag.Usuarios = usuarios;
                }
                else
                {
                    ViewBag.Usuarios = new List<UsuarioDTO>();
                    ViewBag.ErrorUsuarios = body;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Usuarios = new List<UsuarioDTO>();
                ViewBag.ErrorUsuarios = "Error cargando usuarios: " + ex.Message;
            }
        }
    }
}
//anaper@laempresa.com - gerente1
//brugar@laempresa.com - admin123
//carrod@laempresa.com - emple123
