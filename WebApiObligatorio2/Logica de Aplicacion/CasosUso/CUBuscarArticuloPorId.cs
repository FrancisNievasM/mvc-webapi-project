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
    public class CUBuscarArticuloPorId : ICUBuscarArticuloPorId {
        public IRepositorioArticulos Repo { get; set; }
        public CUBuscarArticuloPorId(IRepositorioArticulos repo) {
            Repo = repo;
        }
        public Articulo BuscarArticuloPorId(string codigo) {
            if (codigo == null) throw new DatosInvalidosException("El codigo del articulo no puede ser nulo o vacio");
            Articulo art = Repo.FindByCode(codigo);
            if (art == null) throw new NotFoundException("No existe un articulo con el codigo proporcionado");
            return art;
        }
    }
}
