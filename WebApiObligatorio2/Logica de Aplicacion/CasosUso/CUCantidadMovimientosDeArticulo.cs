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
    public class CUCantidadMovimientosDeArticulo : ICUCantidadMovimientosDeArticulo {
        IRepositorioMovimiento RepoMov { get; set; }
        public IRepositorioArticulos RepoArt { get; set; }
        public IRepositorio<TipoMovimiento> RepoTipo { get; set; }
        public CUCantidadMovimientosDeArticulo(IRepositorioMovimiento repo, IRepositorioArticulos repoArt, IRepositorio<TipoMovimiento> repoTipo) {
            RepoMov = repo;
            RepoArt = repoArt;
            RepoTipo = repoTipo;
        }

        public int CantidadMovimientosDeArticulo(string codigoArt, int idTipo) {
            if (RepoArt.FindByCode(codigoArt) == null) { throw new NotFoundException("No existe un articulo con el codigo proporcionado"); }
            if (RepoTipo.FindById(idTipo) == null) { throw new NotFoundException("No existe un tipo de movimiento con el id proporcionado"); }
            return RepoMov.CantidadMovimientosSobreArticulo(codigoArt, idTipo);
        }
    }
}
