using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUCantMaxMovPorPagina : ICUCantMaxMovPorPagina {
        IRepositorioParametros Repo { get; set; }
        public CUCantMaxMovPorPagina(IRepositorioParametros repo) {
            Repo = repo;
        }

        public void CantMaxMovPorPagina() {
            int cant = Repo.FindCantMaxMovimientos();
            Movimiento.CantMaxPorPagina = cant;
        }
    }
}
