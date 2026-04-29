using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Token;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiObligatorio2.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase {
        ICULoginUsuarios CULoginUsuarios { get; set; }
        public UsuarioController(ICULoginUsuarios cULoginUsuarios) {
            CULoginUsuarios = cULoginUsuarios;
        }

        [HttpPost("Login")]
        public IActionResult Post([FromBody] DTOUsuario dto) {
            try {
                if(dto == null || dto.Mail == null || dto.Mail == "" || dto.Password == null || dto.Password == "") { throw new DatosInvalidosException("Los campos no deben ser vacíos"); }
                DTOUsuario user  = CULoginUsuarios.Login(dto.Mail, dto.Password);
                if(user == null) { throw new NotFoundException("No existe un usuario con los datos proporcionados"); }
                return Ok(new DTOUsuarioLogueado() {
                    Rol = user.Rol,
                    Token = ManejadorToken.CrearToken(user),
                    Mail = user.Mail
                });

            } catch(DatosInvalidosException ex) {
                return BadRequest(ex.Message);
            }catch(NotFoundException ex) {
                return NotFound(ex.Message);
            } catch (Exception ex) {
                return StatusCode(500, "Error interno");
            }
        }
    }
}
