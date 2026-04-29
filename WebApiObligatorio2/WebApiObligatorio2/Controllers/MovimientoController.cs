using DTOs;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiObligatorio2.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase {
        public ICUAltaMovimiento CUAltaMovimiento { get; set; }
        public ICUBuscarTipoMovimiento CUBuscarTipoMovimiento { get; set; }
        public ICUBuscarUsuarioPorMail CUBuscarUsuarioPorMail { get; set; }
        public ICUBuscarArticuloPorId CUBuscarArticuloPorId { get; set; }
        public ICUBuscarMovimientoPorId CUBuscarMovimientoPorId { get; set; }
        public ICUBuscarMovimientosDeArticulo CUBuscarMovimientosDeArticulo {  get; set; }
        public ICUResumenMovimientos CUResumenMovimientos { get; set; }
        public ICUCantidadMovimientosDeArticulo CUCantidadMovimientosDeArticulo { get; set; }
        public ICUCantMaxMovPorPagina CUCantMaxMovPorPagina { get; set; }
        public ICUActualizarTopeCant CUActualizarTopeCant { get; set; }
        public MovimientoController(ICUAltaMovimiento cUAltaMovimiento, ICUBuscarTipoMovimiento cUBuscarTipoMovimiento, ICUBuscarUsuarioPorMail cUBuscarUsuarioPorMail, ICUBuscarArticuloPorId cUBuscarArticuloPorId, ICUBuscarMovimientoPorId cUBuscarMovimientoPorId, ICUBuscarMovimientosDeArticulo cUBuscarMovimientosDeArticulo, ICUResumenMovimientos cUResumenMovimientos, ICUCantidadMovimientosDeArticulo cUCantidadMovimientosDeArticulo, ICUCantMaxMovPorPagina cUCantMaxMovPorPagina, ICUActualizarTopeCant cUActualizarTopeCant) {
            CUAltaMovimiento = cUAltaMovimiento;
            CUBuscarTipoMovimiento = cUBuscarTipoMovimiento;
            CUBuscarArticuloPorId = cUBuscarArticuloPorId;
            CUBuscarUsuarioPorMail = cUBuscarUsuarioPorMail;
            CUBuscarMovimientoPorId = cUBuscarMovimientoPorId;
            CUBuscarMovimientosDeArticulo = cUBuscarMovimientosDeArticulo;
            CUResumenMovimientos = cUResumenMovimientos;
            CUCantidadMovimientosDeArticulo = cUCantidadMovimientosDeArticulo;
            CUCantMaxMovPorPagina = cUCantMaxMovPorPagina;
            CUActualizarTopeCant = cUActualizarTopeCant;
        }

        // GET api/<MovimientoController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Encargado")]
        public IActionResult Get(int id) {
            try {
                if (id <= 0) {
                    throw new DatosInvalidosException("El Id debe ser mayor a 0");
                }
                DTOMostrarMovimiento buscado = CUBuscarMovimientoPorId.Buscar(id);
                return Ok(buscado);
            } catch (DatosInvalidosException ex) {
                return BadRequest(ex.Message);
            } catch (NotFoundException ex) {
                return NotFound(ex.Message);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }


        // POST api/<MovimientoController>
        [HttpPost]
        [Authorize(Roles = "Encargado")]
        public IActionResult Post([FromBody] DTOAltaMovimiento mDTO) {
            try {
                if (mDTO == null) { throw new DatosInvalidosException("No se proporcionaron los datos requeridos para el alta"); }
                Usuario user = CUBuscarUsuarioPorMail.BuscarUsuarioPorMail(mDTO.Mail);
                if (user == null) throw new NotFoundException("No se encontró un usuario con el mail proporcionado");
                if(user.Tipo.Value != "Encargado") { throw new DatosInvalidosException("Solo los encargados pueden dar movimientos de alta"); }
                CUActualizarTopeCant.ActualizarTopeCant();
                DTOMostrarMovimiento dtoFinal = CUAltaMovimiento.Alta(mDTO);
                return CreatedAtRoute("BuscarPorId", new { id = dtoFinal.Id }, dtoFinal);
            } catch (DatosInvalidosException ex) {
                return BadRequest(ex.Message);
            }catch (NotFoundException ex) {
                return NotFound(ex.Message);//A FALTA DE MEJOR ERROR DEJAMOS EN 500
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{codigoArt}/{idTipo}/{pagina}")]
        [Authorize(Roles = "Encargado")]
        public IActionResult GetMovimientosdeArticulo(string codigoArt,int idTipo, int pagina) {
            try {
                if (codigoArt == null || codigoArt.Length != 13) { throw new DatosInvalidosException("El codigo del articulo debe tener 13 caracteres y no ser nulo"); }
                if (idTipo <= 0) { throw new DatosInvalidosException("El id del tipo debe ser mayor a cero y no ser nulo"); }
                if(pagina <= 0) { throw new DatosInvalidosException("Numero de pagina invalido, debe ser mayor a cero"); }
                CUCantMaxMovPorPagina.CantMaxMovPorPagina();
                List<DTOMovimientoCompleto> listado = CUBuscarMovimientosDeArticulo.BuscarMovimientosDeArticulo(codigoArt, idTipo, pagina);
                return Ok(listado);
            }catch(DatosInvalidosException ex) {
                return BadRequest(ex.Message);
            }catch(NotFoundException ex) {
                return NotFound(ex.Message);
            }catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }

            
        }

        [HttpGet ("Resumen")]
        //[Authorize(Roles = "Encargado")]
        public IActionResult GetResumen() {
            try {
                List<DTOResumen> listado = CUResumenMovimientos.ResumenMovimientos();
                return Ok(listado);
            }catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("CantidadMovimientosDeArticulo/{codigoArt}/{idTipo}")]
        [Authorize(Roles = "Encargado")]
        public IActionResult GetCantidadDeArticulo(string codigoArt,int idTipo) {
            try {
                
                if (codigoArt == null || codigoArt.Length != 13) { throw new DatosInvalidosException("El codigo del articulo debe tener 13 caracteres y ser no nulo"); }
                if (idTipo <= 0) { throw new DatosInvalidosException("El id del tipo debe ser mayor a cero y no ser nulo"); }
                double cantidadPaginas = (double)CUCantidadMovimientosDeArticulo.CantidadMovimientosDeArticulo(codigoArt, idTipo) / 2;
                return Ok(cantidadPaginas);
            } catch (DatosInvalidosException ex) {
                return BadRequest(ex.Message);
            } catch (NotFoundException ex) {
                return NotFound(ex.Message);
            } catch (Exception ex) {
                return StatusCode(500, "Ha ocurrido un error inesperado");
            }
        }
    }
}
