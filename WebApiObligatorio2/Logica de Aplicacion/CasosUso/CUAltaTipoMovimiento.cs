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
    public class CUAltaTipoMovimiento : ICUAltaTipoMovimiento {

        IRepositorio<TipoMovimiento> Repo {  get; set; }
        public CUAltaTipoMovimiento(IRepositorio<TipoMovimiento> repo) {
            Repo = repo;
        }

        public DTOMostrarTipoMovimiento Alta(string nombre, string tipo) {
            TipoMovimiento unTipo = new TipoMovimiento(nombre,tipo);
            unTipo.EsValido();
            Repo.Add(unTipo);
            return TipoMovimientoMapper.ToMostrar(unTipo);
        }
    }
}
