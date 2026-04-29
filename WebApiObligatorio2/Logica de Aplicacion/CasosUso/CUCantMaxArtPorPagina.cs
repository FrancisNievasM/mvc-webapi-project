using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUCantMaxArtPorPagina : ICUCantMaxArtPorPagina {
        IRepositorioParametros Repo {  get; set; }
        public CUCantMaxArtPorPagina(IRepositorioParametros repo) {
            Repo = repo;
        }

        public void CantMaxArtPorPagina() {
            int cant = Repo.FindCantMaxArticulos();
            Articulo.CantMaxPorPagina = cant;
        }
    }
}
