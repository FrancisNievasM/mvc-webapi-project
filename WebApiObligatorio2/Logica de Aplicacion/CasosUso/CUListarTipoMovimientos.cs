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
    public class CUListarTipoMovimientos : ICUListarTipoMovimientos {
        IRepositorio<TipoMovimiento> Repo {  get; set; }
        public CUListarTipoMovimientos(IRepositorio<TipoMovimiento> repo) {
            Repo = repo;
        }

        public List<DTOMostrarTipoMovimiento> Listar() {
            return TipoMovimientoMapper.ToListDTOMostrar(Repo.FindAll());
        }
    }
}
