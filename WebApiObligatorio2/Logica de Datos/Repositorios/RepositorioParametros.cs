using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioParametros : IRepositorioParametros {
        LibreriaContext Context { get; set; }
        public RepositorioParametros(LibreriaContext context) {
            Context = context;
        }
        public int FindCantMaxArticulos() {
            return Context.Parametros.FirstOrDefault().CantArtPagina;
        }

        public int FindCantMaxMovimientos() {
            return Context.Parametros.FirstOrDefault().CantMovPagina;
        }

        public int FindTopeCant() {
            return Context.Parametros.FirstOrDefault().TopeCant;
        }
    }
}
