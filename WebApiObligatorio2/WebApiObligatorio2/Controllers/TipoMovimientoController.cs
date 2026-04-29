using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace WebApiObligatorio2.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class TipoMovimientoController : ControllerBase {

        public ICUListarTipoMovimientos CUListarTipoMovimientos { get; set; }
        public ICUAltaTipoMovimiento CUAltaTipoMovimiento { get; set; }
        public ICUBajaTipoMovimiento CUBajaTipoMovimiento { get; set; }
        public ICUUpdateTipoMovimiento CUUpdateTipoMovimiento { get; set; }
        public ICUBuscarTipoMovimiento CUBuscarTipoMovimiento { get; set; }
        public TipoMovimientoController(ICUListarTipoMovimientos cUListarTipoMovimientos, ICUAltaTipoMovimiento cUAltaTipoMovimiento, ICUBajaTipoMovimiento cUBajaTipoMovimiento, ICUUpdateTipoMovimiento cUUpdateTipoMovimiento, ICUBuscarTipoMovimiento cUBuscarTipoMovimiento) {
            CUListarTipoMovimientos = cUListarTipoMovimientos;
            CUAltaTipoMovimiento = cUAltaTipoMovimiento;
            CUBajaTipoMovimiento = cUBajaTipoMovimiento;
            CUUpdateTipoMovimiento = cUUpdateTipoMovimiento;
            CUBuscarTipoMovimiento = cUBuscarTipoMovimiento;
        }

        [HttpGet]
        public IActionResult List() {
            try {
                List<DTOMostrarTipoMovimiento> lista = CUListarTipoMovimientos.Listar();
                return Ok(lista);
            }catch (DatosInvalidosException ex) {
                return BadRequest(ex.Message);
            }catch (Exception ex) {
                return StatusCode(500,"Ha ocurrido un error inesperado");
            }
        }

        [HttpGet("{id}", Name = "BuscarPorId")]
        public IActionResult Get(int id) {
            try {
                if(id <= 0) {
                    throw new DatosInvalidosException("El Id debe ser mayor a 0");
                }
                DTOMostrarTipoMovimiento buscado = CUBuscarTipoMovimiento.Buscar(id);
                return Ok(buscado);
            } catch (DatosInvalidosException ex) {
                return BadRequest(ex.Message);
            } catch (NotFoundException ex) {
                return NotFound(ex.Message);
            } catch (Exception ex) {
                return StatusCode(500,"Ha ocurrido un error inesperado");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] DTOAltaTipoMovimiento tmDTO) {
            try {
                if(tmDTO == null) { return BadRequest("No se proporcionaron los datos requeridos para el alta"); }
                DTOMostrarTipoMovimiento dtoFinal = CUAltaTipoMovimiento.Alta(tmDTO.Nombre, tmDTO.Tipo);
                return CreatedAtRoute("BuscarPorId", new {id = dtoFinal.Id}, dtoFinal);
            }catch(DatosInvalidosException ex) {
                return BadRequest(ex.Message);
            }catch(Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                if (id <= 0) { return BadRequest("El id debe ser un entero positivo"); }
                if(CUBuscarTipoMovimiento.Buscar(id) == null) { throw new NotFoundException("No existe un Tipo de Movimiento con el Id proporcionado"); }
                CUBajaTipoMovimiento.Baja(id);
                return Ok("Baja realizada con éxito");
            } catch (DatosInvalidosException ex) {
                return BadRequest(ex.Message);
            }catch(NotFoundException ex) {
                return NotFound(ex.Message);
            }catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DTOMostrarTipoMovimiento tmDTO) {
            if(id <= 0) return BadRequest("El id debe ser un entero positivo");
            if (tmDTO == null) return BadRequest("No se proporcionaron datos para la modificación");
            if (id != tmDTO.Id) return BadRequest("Se proporcionaron dos id de tema diferentes");
            try {
                CUUpdateTipoMovimiento.Update(tmDTO);
                return Ok(tmDTO);
            } catch (DatosInvalidosException ex) {
                return BadRequest(ex.Message);
            } catch (NotFoundException ex) {
                return NotFound(ex.Message);
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
