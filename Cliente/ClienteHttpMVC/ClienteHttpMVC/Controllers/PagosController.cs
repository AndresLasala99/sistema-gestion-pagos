using ClienteHttpMVC.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace ClienteHttpMVC.Controllers
{
    public class PagosController : Controller
    {
        private string URLApiPagos { get; set; }
        private string URLApiGastos { get; set; }

        public PagosController(IConfiguration config, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                URLApiPagos = config.GetValue<string>("URLApiPagos");
                URLApiGastos = config.GetValue<string>("URLApiGastos");
            }
            if (env.IsProduction())
            {
                URLApiPagos = config.GetValue<string>("URLApiPagosAzure");
                URLApiGastos = config.GetValue<string>("URLApiGastosAzure");
            }
        }

        // ============ LISTADO DE PAGOS (si lo usás) ============

        public ActionResult Index()
        {
            IEnumerable<PagoDTO> pagos = new List<PagoDTO>();
            ViewBag.Error = null;

            string token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Usuarios");
            }

            try
            {
                HttpClient cliente = new HttpClient();
                cliente.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage respuesta = cliente.GetAsync(URLApiPagos).Result;
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
                ViewBag.Error = "Error al contactar la API: " + ex.Message;
                return View(pagos);
            }
        }

        [HttpGet]
        public ActionResult AltaUnico()
        {
            string token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Usuarios");
            }

            CargarGastosEnViewBag(token);

            return View(new PagoDTO());
        }

        [HttpPost]
        public ActionResult AltaUnico(PagoDTO pago)
        {
            string token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Usuarios");
            }

            int? idSesion = HttpContext.Session.GetInt32("IdUsuario");
            if (!idSesion.HasValue)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            pago.idUsuario = idSesion.Value;

            pago.FechaInicio = null;
            pago.FechaFin = null;

            if (pago.Fecha == null || pago.Fecha==DateTime.MinValue)
            {
                ViewBag.Error = "La fecha no puede estar vacía.";
                CargarGastosEnViewBag(token);
                return View(pago);
            }
            if (string.IsNullOrEmpty(pago.Descripcion))
            {
                ViewBag.Error = "La descripción no puede estar vacía.";
                CargarGastosEnViewBag(token);
                return View(pago);
            }
            if(pago.NroRecibo < 1)
            {
                ViewBag.Error = "El número de recibo no puede ser negativo.";
                CargarGastosEnViewBag(token);
                return View(pago);
            }
            if (pago.Monto <= 0)
            {
                ViewBag.Error = "El monto no puede ser negativo.";
                CargarGastosEnViewBag(token);
                return View(pago);
            }

            try
            {
                HttpClient cliente = new HttpClient();
                cliente.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                string json = JsonConvert.SerializeObject(pago);
                StringContent contenido = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage resp = cliente.PostAsync(URLApiPagos, contenido).Result;
                string body = resp.Content.ReadAsStringAsync().Result;

                if (resp.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Pago único registrado correctamente.";
                    CargarGastosEnViewBag(token);
                    return View(new PagoDTO());
                }

                if (resp.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Unauthorized();
                }

                if (resp.StatusCode == HttpStatusCode.Forbidden)
                {
                    return Forbid();
                }

                ViewBag.Error = body;
                CargarGastosEnViewBag(token);
                return View(pago);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al contactar la API: " + ex.Message;
                CargarGastosEnViewBag(token);
                return View(pago);
            }
        }

        [HttpGet]
        public ActionResult AltaRecurrente()
        {
            string token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Usuarios");
            }

            CargarGastosEnViewBag(token);

            return View(new PagoDTO());
        }

        [HttpPost]
        public ActionResult AltaRecurrente(PagoDTO pago)
        {
            string token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Usuarios");
            }

            int? idSesion = HttpContext.Session.GetInt32("IdUsuario");
            if (!idSesion.HasValue)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            pago.idUsuario = idSesion.Value;
            pago.Fecha = null;
            pago.NroRecibo = null;

            if (pago.FechaFin == null || pago.FechaInicio == DateTime.MinValue)
            {
                ViewBag.Error = "La fecha de inicio no puede estar vacía.";
                CargarGastosEnViewBag(token);
                return View(pago);
            }
            if (string.IsNullOrEmpty(pago.Descripcion))
            {
                ViewBag.Error = "La descripción no puede estar vacía.";
                CargarGastosEnViewBag(token);
                return View(pago);
            }
            if (pago.FechaFin == null || pago.FechaFin == DateTime.MinValue)
            {
                ViewBag.Error = "La fecha de fin no puede estar vacía.";
                CargarGastosEnViewBag(token);
                return View(pago);
            }
            if (pago.Monto <= 0)
            {
                ViewBag.Error = "El monto no puede ser negativo.";
                CargarGastosEnViewBag(token);
                return View(pago);
            }
            if (pago.FechaInicio > pago.FechaFin)
            {
                ViewBag.Error = "La fecha de inicio no puede ser mayor a la fecha fin.";
                CargarGastosEnViewBag(token);
                return View(pago);
            }
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                string json = JsonConvert.SerializeObject(pago);
                StringContent contenido = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage resp = cliente.PostAsync(URLApiPagos, contenido).Result;
                string body = resp.Content.ReadAsStringAsync().Result;

                if (resp.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Pago recurrente registrado correctamente.";
                    CargarGastosEnViewBag(token);
                    return View(new PagoDTO());
                }

                if (resp.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return Unauthorized();
                }

                if (resp.StatusCode == HttpStatusCode.Forbidden)
                {
                    return Forbid();
                }

                ViewBag.Error = body;
                CargarGastosEnViewBag(token);
                return View(pago);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error al contactar la API: " + ex.Message;
                CargarGastosEnViewBag(token);
                return View(pago);
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