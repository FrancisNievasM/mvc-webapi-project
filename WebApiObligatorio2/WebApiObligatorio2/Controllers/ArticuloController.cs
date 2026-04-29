using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiObligatorio2.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase {
        ICUArticulosEntreFechas CUArticulosEntreFechas { get; set; }
        ICUCantidadArticulosEntreFechas CUCantidadArticulosEntreFechas { get; set; }
        ICUCantMaxArtPorPagina CUCantMaxArtPorPagina { get; set; }
        ICUListarArticulos CUListarArticulos { get; set; }
        public ArticuloController(ICUArticulosEntreFechas cUArticulosEntreFechas, ICUCantidadArticulosEntreFechas cUCantidadArticulosEntreFechas, ICUCantMaxArtPorPagina cUCantMaxArtPorPagina, ICUListarArticulos cUListarArticulos) {
            CUArticulosEntreFechas = cUArticulosEntreFechas;
            CUCantidadArticulosEntreFechas = cUCantidadArticulosEntreFechas;
            CUCantMaxArtPorPagina = cUCantMaxArtPorPagina;
            CUListarArticulos = cUListarArticulos;
        }

        [HttpGet("{fechaIni}/{fechaFin}/{pagina}")]
        [Authorize(Roles = "Encargado")]
        public IActionResult GetArticulosEntreFechas(DateTime fechaIni, DateTime fechaFin, int pagina) {
            try {
                if(pagina <= 0) { throw new DatosInvalidosException("Numero de pagina invalido, debe ser mayor a cero"); }
                CUCantMaxArtPorPagina.CantMaxArtPorPagina();
                List<DTOArticulo> listado = CUArticulosEntreFechas.ArticulosEntreFechas(fechaIni, fechaFin, pagina);
                return Ok(listado);
            }catch(DatosInvalidosException ex) {
                return BadRequest(ex.Message);
            }catch(NotFoundException ex) {
                return NotFound(ex.Message);
            }catch (Exception ex) {
                return StatusCode(500, "Ha ocurrido un error inesperado");
            }
        }

        [HttpGet("CantidadEntreFechas/{fechaIni}/{fechaFin}/")]
        [Authorize(Roles = "Encargado")]
        public IActionResult CantidadPaginasEntreFechas(DateTime fechaIni, DateTime fechaFin) {
            try {
                double cantidadPaginas = (double)CUCantidadArticulosEntreFechas.CantidadArticulosEntreFechas(fechaIni, fechaFin) / Articulo.CantMaxPorPagina;
                return Ok(cantidadPaginas);
            } catch (DatosInvalidosException ex) {
                return BadRequest(ex.Message);
            } catch (NotFoundException ex) {
                return NotFound(ex.Message);
            } catch (Exception ex) {
                return StatusCode(500, "Ha ocurrido un error inesperado");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Encargado")]
        public IActionResult Get() {
            try {
                List<DTOArticuloReducido> listado = CUListarArticulos.ListarArticulos();
                return Ok(listado);
            }catch(Exception ex) {
                return StatusCode(500, "Ha ocurrido un error inesperado");
            }
        }

    }
}
