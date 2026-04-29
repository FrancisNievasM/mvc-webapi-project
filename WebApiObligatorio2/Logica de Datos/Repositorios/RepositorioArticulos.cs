using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.Exceptions;

namespace LogicaDatos.Repositorios {
    public class RepositorioArticulos : IRepositorioArticulos {
        public LibreriaContext Contexto { get; set; }

        public RepositorioArticulos(LibreriaContext ctx) {
            Contexto = ctx;
        }
        public void Add(Articulo item) {
            bool nombreExistente = Contexto.Set<Articulo>().Any(u => u.Nombre == item.Nombre);
            bool codigoExistente = Contexto.Set<Articulo>().Any(u => u.Codigo == item.Codigo);
            if (nombreExistente) {
                throw new DatosInvalidosException("Ya existe un Articulo con el mismo nombre.");
            }
            if (codigoExistente) {
                throw new DatosInvalidosException("Ya existe un Articulo con el mismo codigo.");
            }
            Contexto.Add(item);
            Contexto.SaveChanges();
        }

        public List<Articulo> FindAll() {
            List<Articulo> articulos = Contexto.Articulos.OrderBy(art => art.Nombre).ToList();
            return articulos;
        }

        public Articulo FindById(int id) {
            throw new NotImplementedException();
        }

        public void Remove(int id) {
            throw new NotImplementedException();
        }

        public void Update(Articulo item) {
            throw new NotImplementedException();
        }

        public Articulo FindByCode(string code) {
            return Contexto.Articulos
                .Where(art => art.Codigo.Equals(code))
                .SingleOrDefault();
        }
        public List<Articulo> ArticulosEntreFechas(DateTime fechaIni, DateTime fechaFin, int pagina) {
            List<Articulo> arti= Contexto.Movimientos.Select(mov=> mov.Art).Distinct().Skip((pagina - 1) * Articulo.CantMaxPorPagina).Take(Articulo.CantMaxPorPagina).ToList();
            return arti;



        }

        public int CantidadArticulosEntreFechas(DateTime fechaIni, DateTime fechaFin) {
            return Contexto.Movimientos.Where(mov => mov.Fecha < fechaFin && mov.Fecha > fechaIni).Select(mov => mov.Art).Distinct().Count();
        }
    }
}
