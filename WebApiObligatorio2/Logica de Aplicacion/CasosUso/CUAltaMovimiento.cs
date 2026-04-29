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
    public class CUAltaMovimiento : ICUAltaMovimiento{
        public IRepositorioMovimiento RepoMov {  get; set; }
        public IRepositorio<TipoMovimiento> RepoTipo { get; set; }
        public IRepositorioArticulos RepoArti { get; set; }
        public CUAltaMovimiento(IRepositorioMovimiento repo, IRepositorioArticulos repoArti, IRepositorio<TipoMovimiento> repotipo) {
            RepoMov = repo;
            RepoArti = repoArti;
            RepoTipo = repotipo;
        }

        public DTOMostrarMovimiento Alta(DTOAltaMovimiento item) {
            if(item.Cantidad > Movimiento.TopeCant) { throw new DatosInvalidosException("La cantidad no debe superar el tope establecido de: " + Movimiento.TopeCant + " unidades"); }
            Articulo art = RepoArti.FindByCode(item.CodigoArt);
            if(art == null) { throw new NotFoundException("No se encontró un articulo con el codigo proporcionado"); }
            TipoMovimiento tipo = RepoTipo.FindById(item.IdTipo);
            if(tipo == null) { throw new NotFoundException("No se encontró un tipo de movimiento con el id proporcionado"); }
            Movimiento mov = new Movimiento(art,DateTime.Now,item.Cantidad,tipo,item.Mail);
            mov.EsValido();
            RepoMov.Add(mov);
            return MovimientoMapper.ToMostrar(mov);
        }
    }
}
