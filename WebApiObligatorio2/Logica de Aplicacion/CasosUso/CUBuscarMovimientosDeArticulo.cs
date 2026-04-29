using DTOs;
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
    public class CUBuscarMovimientosDeArticulo : ICUBuscarMovimientosDeArticulo {
        public IRepositorioMovimiento Repo { get; set; }
        public IRepositorioArticulos RepoArt {  get; set; }
        public IRepositorio<TipoMovimiento> RepoTipo { get; set; }
        public CUBuscarMovimientosDeArticulo(IRepositorioMovimiento repo, IRepositorioArticulos repoArt, IRepositorio<TipoMovimiento> repoTipo) {
            Repo = repo;
            RepoArt = repoArt;
            RepoTipo = repoTipo;
        }

        public List<DTOMovimientoCompleto> BuscarMovimientosDeArticulo(string codigoArt, int idTipo, int pagina) {
            if(RepoArt.FindByCode(codigoArt) == null) { throw new NotFoundException("No existe un articulo con el codigo proporcionado"); }
            if(RepoTipo.FindById(idTipo) == null) { throw new NotFoundException("No existe un tipo de movimiento con el id proporcionado"); }
            return MovimientoMapper.ToListDTOCompleto(Repo.MovimientosSobreArticulo(codigoArt, idTipo, pagina));
        }
    }
}
