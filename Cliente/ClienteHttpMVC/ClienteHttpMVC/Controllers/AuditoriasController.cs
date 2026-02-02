using ClienteHttpMVC.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace ClienteHttpMVC.Controllers
{
    public class AuditoriasController : Controller
    {
        private string URLApiAuditorias { get; set; }
        private string URLApiGastos { get; set; }

        public AuditoriasController(IConfiguration config, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                URLApiAuditorias = config.GetValue<string>("URLApiAuditorias");
                URLApiGastos = config.GetValue<string>("URLApiGastos");
            }
            if (env.IsProduction())
            {
                URLApiAuditorias = config.GetValue<string>("URLApiAuditoriasAzure");
                URLApiGastos = config.GetValue<string>("URLApiGastosAzure");
            }
        }

        [HttpGet]
        public ActionResult Index(int idGasto = 0)
        {
            IEnumerable<AuditoriaDTO> auditorias = new List<AuditoriaDTO>();
            ViewBag.IdGasto = idGasto;
            ViewBag.Error = null;

            string token = HttpContext.Session.GetString("Token");
            string rol = HttpContext.Session.GetString("Rol");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Usuarios");
            }

            if (rol != "Administrador")
            {
                return Forbid();
            }

            CargarGastosEnViewBag(token);

            if (idGasto == 0)
            {
                return View(auditorias);
            }

            if (idGasto < 0)
            {
                ViewBag.Error = "El id del tipo de gasto no puede ser menor que 0.";
                return View(auditorias);
            }

            try
            {
                HttpClient cliente = new HttpClient();

                cliente.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                string url = URLApiAuditorias + "/gastos/" + idGasto;

                HttpResponseMessage respuesta = cliente.GetAsync(url).Result;
                string body = respuesta.Content.ReadAsStringAsync().Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    auditorias = JsonConvert.DeserializeObject<List<AuditoriaDTO>>(body);
                    return View(auditorias);
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

                return View(auditorias);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error al consultar la API de auditorías: " + ex.Message;
                return View(auditorias);
            }
        }

        private void CargarGastosEnViewBag(string token)
        {
            try
            {
                HttpClient cliente = new HttpClient();

                cliente.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage resp = cliente.GetAsync(URLApiGastos).Result;
                string body = resp.Content.ReadAsStringAsync().Result;

                List<GastoDTO> gastos = new List<GastoDTO>();

                if (resp.IsSuccessStatusCode)
                {
                    gastos = JsonConvert.DeserializeObject<List<GastoDTO>>(body);
                    ViewBag.Gastos = gastos;
                }
                else
                {
                    ViewBag.Gastos = new List<GastoDTO>();
                    ViewBag.ErrorGastos = body;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Gastos = new List<GastoDTO>();
                ViewBag.ErrorGastos = ex.Message;
            }
        }
    }
}