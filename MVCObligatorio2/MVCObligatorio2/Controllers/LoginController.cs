using DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MVCObligatorio2.ClasesAuxiliares;
namespace MVCObligatorio2.Controllers {
    public class LoginController : Controller {
        public string UrlApi;
        public LoginController(IConfiguration config) {
            UrlApi = config.GetValue<string>("URLAPI");
        }
        public IActionResult Index() {
            return View();
        }
        [HttpPost]
        public IActionResult Index(DTOUsuario dtoUser) {
            try {
                if (ModelState.IsValid) {
                    HttpClient client = new HttpClient();
                    var tarea = client.PostAsJsonAsync(UrlApi + "Usuario/Login", dtoUser);
                    tarea.Wait();
                    var respuesta = tarea.Result;
                    string cuerpo = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                    if (respuesta.IsSuccessStatusCode) {
                        DTOUsuarioLogueado usuarioLogueado = JsonConvert.DeserializeObject<DTOUsuarioLogueado>(cuerpo);
                        if (usuarioLogueado != null) {
                            HttpContext.Session.SetString("Rol", usuarioLogueado.Rol);
                            HttpContext.Session.SetString("Token", usuarioLogueado.Token);
                            HttpContext.Session.SetString("Mail", usuarioLogueado.Mail);
                            return RedirectToAction("Index", "Home");
                        }
                        ViewBag.Mensaje = "Datos incorrectos";
                    } else if ((int)respuesta.StatusCode == StatusCodes.Status400BadRequest || (int)respuesta.StatusCode == StatusCodes.Status404NotFound || (int)respuesta.StatusCode == StatusCodes.Status500InternalServerError) {
                        ViewBag.Mensaje = cuerpo;
                    } else {
                        ViewBag.Mensaje = "Error en los datos";
                    }


                } else {
                    ViewBag.Mensaje = "Datos incorrectos";
                }
            } catch (Exception ex) {
                ViewBag.Mensaje = "Error";
            }
            return View();
        }
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
