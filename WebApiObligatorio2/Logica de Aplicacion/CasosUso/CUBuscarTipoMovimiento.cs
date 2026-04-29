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
    public class CUBuscarTipoMovimiento : ICUBuscarTipoMovimiento {
        IRepositorio<TipoMovimiento> Repo {  get; set; }
        public CUBuscarTipoMovimiento(IRepositorio<TipoMovimiento> repo) {
            Repo = repo;
        }

        public DTOMostrarTipoMovimiento Buscar(int id) {
            TipoMovimiento unTipo = Repo.FindById(id);
            if (unTipo == null) throw new NotFoundException("No existe un Tipo de Movimiento con la Id proporcionada");
            return TipoMovimientoMapper.ToMostrar(unTipo);
        }
    }
}
