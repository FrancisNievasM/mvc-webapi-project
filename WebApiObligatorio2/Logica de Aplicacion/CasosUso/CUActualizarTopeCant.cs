using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUActualizarTopeCant : ICUActualizarTopeCant {

        IRepositorioParametros Repo {  get; set; }
        public CUActualizarTopeCant(IRepositorioParametros repo) {
            Repo = repo;
        }

        public void ActualizarTopeCant() {
            Movimiento.TopeCant = Repo.FindTopeCant();
        }
    }
}
