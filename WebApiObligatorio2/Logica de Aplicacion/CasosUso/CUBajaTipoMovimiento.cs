using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUBajaTipoMovimiento : ICUBajaTipoMovimiento {
        IRepositorio<TipoMovimiento> Repo {  get; set; }
        public CUBajaTipoMovimiento(IRepositorio<TipoMovimiento> repo) {
            Repo = repo;
        }

        public void Baja(int id) {
            Repo.Remove(id);
        }
    }
}
