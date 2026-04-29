using DTOs;
using Microsoft.AspNetCore.Mvc;
using MVCObligatorio2.ClasesAuxiliares;
using MVCObligatorio2.Exceptions;
using MVCObligatorio2.Models;
using Newtonsoft.Json;

namespace MVCObligatorio2.Controllers {
    public class MovimientoController : Controller {
        public string UrlApi { get; set; }

        public MovimientoController(IConfiguration config) {
            UrlApi = config.GetValue<string>("URLAPI");
        }
        public IActionResult Alta() {
            if (HttpContext.Session.GetString("Rol") != "Encargado") {
                return RedirectToAction("Index", "Home");
            }
            if (TempData["Mensaje"] != null) {
                ViewBag.Mensaje = TempData["Mensaje"];
            }
            TempData["Mensaje"] = null;
            AltaMovimientoViewModel vm = new AltaMovimientoViewModel();
            try { 
                HttpClient cliente = new HttpClient();
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token"));
                var tarea = cliente.GetAsync(UrlApi + "Articulo");
                tarea.Wait();
                var respuesta = tarea.Result;
                var contenido = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                if (respuesta.IsSuccessStatusCode) {
                    List<DTOArticuloReducido> articulos = JsonConvert.DeserializeObject<List<DTOArticuloReducido>>(contenido);
                    List<ArticuloReducidoViewModel> listVm = new List<ArticuloReducidoViewModel>();
                    if (articulos == null) {
                        throw new ExcepcionPropiaException("No se encontraron articulos válidos para mostrar");
                    }
                    foreach (DTOArticuloReducido art in articulos) {
                        ArticuloReducidoViewModel vmArt = new ArticuloReducidoViewModel();
                        vmArt.Codigo = art.CodigoArt;
                        vmArt.Nombre = art.Nombre;
                        listVm.Add(vmArt);
                    }
                    vm.Articulos = listVm;
                } else if ((int)respuesta.StatusCode == StatusCodes.Status500InternalServerError) {
                    ViewBag.Mensaje = contenido;
                }
                var tarea2 = cliente.GetAsync(UrlApi + "TipoMovimiento");
                tarea2.Wait();
                respuesta = tarea2.Result;
                contenido = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                if (respuesta.IsSuccessStatusCode) {
                    List<DTOTipoMovimiento> tipos = JsonConvert.DeserializeObject<List<DTOTipoMovimiento>>(contenido);
                    List<TipoMovimientoViewModel> listVmTipo = new List<TipoMovimientoViewModel>();
                    if(tipos == null) {
                        throw new ExcepcionPropiaException("No se encontraron tipos de movimientos válidos para mostrar");
                    }
                    foreach (DTOTipoMovimiento tipo in tipos) {
                        TipoMovimientoViewModel vmTipo = new TipoMovimientoViewModel();
                        vmTipo.Id = tipo.Id;
                        vmTipo.Nombre = tipo.Nombre;
                        listVmTipo.Add(vmTipo);
                    }
                    vm.Tipos = listVmTipo;
                } else if ((int)respuesta.StatusCode == StatusCodes.Status400BadRequest || (int)respuesta.StatusCode == StatusCodes.Status500InternalServerError) {
                    ViewBag.Mensaje = contenido;
                }
            }catch(ExcepcionPropiaException ex) {
                ViewBag.Mensaje = ex.Message;
            } catch (Exception ex) {
                ViewBag.Mensaje = "Ha ocurrido un error en la obtención de los datos, por favor recargue la página";
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult Alta(AltaMovimientoViewModel vm) {
            try {
                if (ModelState.IsValid) {
                    DTOAltaMovimiento dtoMov = new DTOAltaMovimiento();
                    dtoMov.Cantidad = vm.Cantidad;
                    dtoMov.IdTipo = vm.IdTipo;
                    dtoMov.Fecha = DateTime.Now;
                    dtoMov.CodigoArt = vm.CodigoArti;
                    dtoMov.Mail = HttpContext.Session.GetString("Mail");
                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token"));
                    var tarea = client.PostAsJsonAsync(UrlApi + "Movimiento", dtoMov);
                    tarea.Wait();
                    var respuesta = tarea.Result;
                    string cuerpo = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                    if (respuesta.IsSuccessStatusCode) {
                        DTOAltaMovimiento movimientoCreado = JsonConvert.DeserializeObject<DTOAltaMovimiento>(cuerpo);
                        if (movimientoCreado != null) {
                            TempData["Mensaje"] = "Movimiento creado con exito"; 
                            return RedirectToAction("Alta");
                        }
                        TempData["Mensaje"] = "Ocurrió un error";
                    } else if ((int)respuesta.StatusCode == StatusCodes.Status400BadRequest || (int)respuesta.StatusCode == StatusCodes.Status404NotFound || (int)respuesta.StatusCode == StatusCodes.Status500InternalServerError) {
                        TempData["Mensaje"] = cuerpo;
                    } else {
                        TempData["Mensaje"] = "Error en los datos";
                    }


                } else {
                    TempData["Mensaje"] = "Datos incorrectos";
                }
            } catch (Exception ex) {
                TempData["Mensaje"] = "Ocurrió un error inesperado";
            }
            return RedirectToAction("Alta");
        }

        public IActionResult MovimientosDeArticulo(int? pagina) {
            if (HttpContext.Session.GetString("Rol") != "Encargado") {
                return RedirectToAction("Index", "Home");
            }
            if (pagina == null) {
                pagina = 1;
            }
            return View();
        }

        [HttpPost]
        public IActionResult MovimientosDeArticulo(string codigoArt,int idTipo, int? pagina) {
            try {
                if (pagina == null) {
                    pagina = 1;
                }
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token"));
                var tarea1 = client.GetAsync(UrlApi + $"Movimiento/{codigoArt}/{idTipo}/{pagina}");
                tarea1.Wait();
                var respuesta = tarea1.Result;
                string cuerpo = HerramientasAPI.LeerContenidoRespuesta(respuesta);

                if (respuesta.IsSuccessStatusCode) {
                    List<DTOMovimientoCompleto> movimientos = JsonConvert.DeserializeObject<List<DTOMovimientoCompleto>>(cuerpo);
                    List<MovimientoCompletoViewModel> listVm = new List<MovimientoCompletoViewModel>();
                    if (movimientos == null) {
                        throw new ExcepcionPropiaException("No hay movimientos para mostrar");
                    }
                    foreach (DTOMovimientoCompleto mov in movimientos) {
                        MovimientoCompletoViewModel vmMov = new MovimientoCompletoViewModel();
                        vmMov.Id = mov.Id;
                        vmMov.NombreArticulo = mov.NombreArt;
                        vmMov.NombreTipo = mov.NombreTipo;
                        vmMov.Mail = mov.Mail;
                        vmMov.TipoTipo = mov.TipoTipo;
                        vmMov.Fecha = mov.Fecha;
                        vmMov.Cantidad = mov.Cantidad;
                        listVm.Add(vmMov);
                    }
                    ViewBag.CodigoArt = codigoArt;
                    ViewBag.IdTipo = idTipo;
                    double cantidadPaginas = ObtenerCantidadPaginas(codigoArt, idTipo);
                    ViewBag.Paginas = Math.Ceiling(cantidadPaginas);
                    return View(listVm);
                } else if ((int)respuesta.StatusCode == StatusCodes.Status401Unauthorized) {
                    return RedirectToAction("Index", "Home");
                } else {
                    ViewBag.Mensaje = cuerpo;
                    return View(new List<MovimientoCompletoViewModel>());
                }
            } catch (ExcepcionPropiaException ex) {
                ViewBag.Mensaje = ex.Message;
            } catch (Exception ex) {
                ViewBag.Mensaje = "Ha ocurrido un error inesperado";
            }
            return View(new List<MovimientoCompletoViewModel>());
        }
        private double ObtenerCantidadPaginas(string codigoArt, int idTipo) {
            double cantidadPaginas = 0;
            try {
                HttpClient cliente = new HttpClient();
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token"));
                var tarea = cliente.GetAsync(UrlApi + $"Movimiento/CantidadMovimientosDeArticulo/{codigoArt}/{idTipo}");
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

        public IActionResult Resumen() {
            if (HttpContext.Session.GetString("Rol") != "Encargado") {
                return RedirectToAction("Index", "Home");
            }
            try {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token"));
                var tarea1 = client.GetAsync(UrlApi + $"Movimiento/Resumen");
                tarea1.Wait();
                var respuesta = tarea1.Result;
                string cuerpo = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                if (respuesta.IsSuccessStatusCode) {
                    List<DTOResumen> movimientos = JsonConvert.DeserializeObject<List<DTOResumen>>(cuerpo);
                    List<ResumenViewModel> listVm = new List<ResumenViewModel>();
                    if (movimientos == null) {
                        throw new ExcepcionPropiaException("No hay movimientos para mostrar");
                    }
                    foreach (DTOResumen mov in movimientos) {
                        ResumenViewModel vmMov = new ResumenViewModel();
                        vmMov.Anio = mov.Anio;
                        foreach (DTOResumenTipo tipo in mov.ResumenesTipos) {
                            ResumenTipoViewModel subVm = new ResumenTipoViewModel();
                            subVm.NombreTipo = tipo.NombreTipo;
                            subVm.Cantidad = tipo.Cantidad;
                            vmMov.ResumenesTipo.Add(subVm);
                        }
                        vmMov.Cantidad = mov.Cantidad;
                        listVm.Add(vmMov);
                    }
                    return View(listVm);
                } else if ((int)respuesta.StatusCode == StatusCodes.Status401Unauthorized) {
                    return RedirectToAction("Index", "Home");
                } else {
                    ViewBag.Mensaje = cuerpo;
                    return View(new List<ResumenViewModel>());
                }
            } catch (Exception ex){
                ViewBag.Mensaje = "Ha ocurrido un error";
            }
            return View(new List<ResumenViewModel>());
        }
    }
}
