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
    public class CUBuscarMovimientoPorId : ICUBuscarMovimientoPorId {
        IRepositorioMovimiento Repo { get; set; }
        public CUBuscarMovimientoPorId(IRepositorioMovimiento repo) {
            Repo = repo;
        }
        public DTOMostrarMovimiento Buscar(int id) {
            Movimiento unMovimiento = Repo.FindById(id);
            if (unMovimiento == null) throw new NotFoundException("No existe un Movimiento con la Id proporcionada");
            return MovimientoMapper.ToMostrar(unMovimiento);
        }
    }
}
