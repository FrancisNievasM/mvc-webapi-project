using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.Exceptions;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUBuscarUsuarioPorMail: ICUBuscarUsuarioPorMail {
        public IRepositorioUsuarios Repo { get; set; }
        public CUBuscarUsuarioPorMail(IRepositorioUsuarios repo) {
            Repo = repo;
        }

        public Usuario BuscarUsuarioPorMail(string mail) {
            if (mail == null) throw new DatosInvalidosException("El mail del usuario no puede ser nulo o vacio");
            Usuario user = Repo.FindByMail(mail);
            if (user == null)throw new NotFoundException("No existe un usuario con el mail proporcionado");
            return user;
        }
    }
}
