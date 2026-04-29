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
    public class CUListarArticulos : ICUListarArticulos {
        IRepositorioArticulos Repo { get; set; }
        public CUListarArticulos(IRepositorioArticulos repo) {
            Repo = repo;
        }

        public List<DTOArticuloReducido> ListarArticulos() {
            return ArticuloMapper.ToListDTOReducido(Repo.FindAll());
        }
    }
}
