using DTOs;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUResumenMovimientos : ICUResumenMovimientos {
        IRepositorioMovimiento Repo {  get; set; }

        public CUResumenMovimientos(IRepositorioMovimiento repo) {
            Repo = repo;
        }

        public List<DTOResumen> ResumenMovimientos() {
            return MovimientoMapper.ToListDTOResumen(Repo.ResumenMovimientos());
        }
    }
}
