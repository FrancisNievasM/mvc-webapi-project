using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios {
    public interface IRepositorioUsuarios : IRepositorio<Usuario> {
        Usuario Login(string username, string password);
        bool EsValidoMailUsuario(string mail);

        Usuario FindByMail(string mail);
    }
}
