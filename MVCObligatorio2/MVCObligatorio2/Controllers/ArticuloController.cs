using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCObligatorio2.ClasesAuxiliares;
using MVCObligatorio2.Exceptions;
using MVCObligatorio2.Models;
using Newtonsoft.Json;

namespace MVCObligatorio2.Controllers {
    public class ArticuloController : Controller {
        public string UrlApi { get; set; }

        public ArticuloController(IConfiguration config) {
            UrlApi = config.GetValue<string>("URLAPI");
        }
        public IActionResult ArticulosConMovimiento(int ? pagina) {
            if(HttpContext.Session.GetString("Rol") != "Encargado") {
                return RedirectToAction("Index", "Home");
            }
            if (pagina == null) {
                pagina = 1;
            }
            return View();
        }

        [HttpPost]
        public IActionResult ArticulosConMovimiento(DateTime fechaIni, DateTime fechaFin, int ? pagina) {
            try {
                if (pagina == null) {
                    pagina = 1;
                }
                if(fechaIni >= fechaFin) {
                    throw new Exception();
                }
                fechaFin = fechaFin.Add(new TimeSpan(24, 00, 00));
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token"));
                var tarea1 = client.GetAsync(UrlApi + $"Articulo/{fechaIni:yyyy-MM-dd}/{fechaFin:yyyy-MM-dd}/{pagina}");
                tarea1.Wait();
                var respuesta = tarea1.Result;
                string cuerpo = HerramientasAPI.LeerContenidoRespuesta(respuesta);

                if (respuesta.IsSuccessStatusCode)
                {
                    List<DTOArticuloMostrar> articulos = JsonConvert.DeserializeObject<List<DTOArticuloMostrar>>(cuerpo);
                    List<ArticuloViewModel> listVm = new List<ArticuloViewModel>();
                    if(articulos == null) {
                        throw new ExcepcionPropiaException("No hay articulos para mostrar");
                    }
                    foreach (DTOArticuloMostrar art in articulos) {
                        ArticuloViewModel vm = new ArticuloViewModel();
                        vm.Codigo = art.Codigo;
                        vm.Nombre = art.Nombre;
                        vm.Descripcion = art.Descripcion;
                        vm.Precio = art.Precio;
                        listVm.Add(vm);
                    }
                    ViewBag.FechaIni = "" + fechaIni.Year+"-"+fechaIni.Month+"-"+fechaIni.Day;
                    ViewBag.FechaFin = "" + fechaFin.Year + "-" + fechaFin.Month + "-" + fechaFin.Day; ;
                    double cantidadPaginas = ObtenerCantidadPaginas(fechaIni,fechaFin);
                    ViewBag.Paginas = Math.Ceiling(cantidadPaginas);
                    return View(listVm);
                } else if ((int)respuesta.StatusCode == StatusCodes.Status401Unauthorized) {
                    return RedirectToAction("Index", "Home");
                } else {
                    ViewBag.Mensaje = cuerpo;
                    return View(new List<ArticuloViewModel>());
                }
            }catch(ExcepcionPropiaException ex) {
                ViewBag.Mensaje = ex.Message;
            }catch(Exception ex) {
                ViewBag.Mensaje = "Ha ocurrido un error inesperado";
            }
            return View(new List<ArticuloViewModel>());
        }
        private double ObtenerCantidadPaginas(DateTime fechaIni, DateTime fechaFin) {
            double cantidadPaginas = 0;
            try {
                HttpClient cliente = new HttpClient();
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token"));
                var tarea = cliente.GetAsync(UrlApi + $"Articulo/CantidadEntreFechas/{fechaIni:yyyy-MM-dd}/{fechaFin:yyyy-MM-dd}");
                tarea.Wait();
                var respuesta = tarea.Result;
                var contenido = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                if (respuesta.IsSuccessStatusCode) {
                    contenido = contenido.Replace(".", ",");
                    double.TryParse(contenido, out cantidadPaginas);
                } else if ((int)respuesta.StatusCode == StatusCodes.Status400BadRequest
                      || (int)respuesta.StatusCode == StatusCodes.Status500InternalServerError) {
                    cantidadPaginas = -1;
                }
            } catch (Exception ex) {
                throw;
            }
            return cantidadPaginas;
        }
    }
}
