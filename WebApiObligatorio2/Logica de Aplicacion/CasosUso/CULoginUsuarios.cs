using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CULoginUsuarios : ICULoginUsuarios {
        public IRepositorioUsuarios Repo { get; set; }
        public CULoginUsuarios(IRepositorioUsuarios repo) {
            Repo = repo;
        }
        public DTOUsuario Login(string mail, string password) {
            string encriptada = Seguridad.EncriptarContraseña(password);
            return UsuarioMapper.ToDTO(Repo.Login(mail, encriptada));
        }
    }
}
