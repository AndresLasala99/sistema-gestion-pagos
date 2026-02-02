using ClienteHttpMVC.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace ClienteHttpMVC.Controllers
{
    public class EquiposController : Controller
    {
        private string URLApiEquipos { get; set; }

        public EquiposController(IConfiguration config, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                URLApiEquipos = config.GetValue<string>("URLApiEquipos");
            }
            if (env.IsProduction())
            {
                URLApiEquipos = config.GetValue<string>("URLApiEquiposAzure");
            }
        }

        public ActionResult Index(double monto)
        {
            IEnumerable<EquipoDTO> equipos = new List<EquipoDTO>();
            ViewBag.Monto = monto;
            ViewBag.Error = null;

            string token = HttpContext.Session.GetString("Token");
            string rol = HttpContext.Session.GetString("Rol");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Usuarios");
            }

            if (rol != "Gerente")
            {
                return Forbid();
            }

            if (monto == 0)
            {
                return View(equipos);
            }

            if (monto <= 0)
            {
                ViewBag.Error = "El monto debe ser mayor a 0.";
                return View(equipos);
            }

            try
            {
                HttpClient cliente = new HttpClient();


                cliente.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("Bearer", token);

                string url = URLApiEquipos + "?monto=" + monto;

                HttpResponseMessage respuesta = cliente.GetAsync(url).Result;
                string body = respuesta.Content.ReadAsStringAsync().Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    equipos = JsonConvert.DeserializeObject<List<EquipoDTO>>(body);
                    return View(equipos);
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

                return View(equipos);
            }
            catch (System.Exception ex)
            {
                ViewBag.Error = "Ocurrió un error al contactar la API: " + ex.Message;
                return View(equipos);
            }
        }
    }
}