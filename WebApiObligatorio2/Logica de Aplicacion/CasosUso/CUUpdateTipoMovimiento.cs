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
    public class CUUpdateTipoMovimiento : ICUUpdateTipoMovimiento {
        IRepositorio<TipoMovimiento> Repo { get; set; }
        public CUUpdateTipoMovimiento(IRepositorio<TipoMovimiento> repo) {
            Repo = repo;
        }
        public DTOMostrarTipoMovimiento Update(DTOMostrarTipoMovimiento unTipo) {
            Repo.Update(TipoMovimientoMapper.ToTipoMovimientoFromMostrar(unTipo));
            return unTipo;
        }
    }
}
