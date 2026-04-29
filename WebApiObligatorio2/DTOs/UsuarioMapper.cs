using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs {
    public class UsuarioMapper {
        public static DTOUsuario ToDTO(Usuario user) {
            DTOUsuario dto = new DTOUsuario() {
                Mail = user.Mail.Value,
                Password = user.Password,
                Rol = user.Tipo.Value,
            };
            return dto;
        }
    }
}
