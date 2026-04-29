using LogicaNegocio.Dominio;
using LogicaNegocio.Exceptions;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioMovimiento : IRepositorioMovimiento {
        public LibreriaContext Context { get; set; }
        public RepositorioMovimiento(LibreriaContext ctx) {
            Context = ctx;
        }
        public void Add(Movimiento item) {
            Context.Add(item);
            Context.SaveChanges();
        }

        public Movimiento FindById(int id) {
            Movimiento mov = Context.Movimientos.Include(mov => mov.Art).Include(mov => mov.Tipo).Where(m => m.Id == id).SingleOrDefault();
            if (mov == null) { throw new NotFoundException("No existe un Movimiento con la id proporcionada"); }
            return mov;
        }

        public List<Movimiento> MovimientosSobreArticulo(string codigoArt, int idTipo, int pagina) {
            return Context.Movimientos.Include(mov => mov.Tipo).Where(mov => mov.Art.Codigo == codigoArt && mov.Tipo.Id == idTipo).OrderByDescending(mov => mov.Fecha).ThenBy(mov => mov.Cantidad).Skip((pagina - 1) * 2).Take(2).ToList();
        }

        public int CantidadMovimientosSobreArticulo(string codigoArt, int idTipo) {
            return Context.Movimientos.Include(mov => mov.Tipo).Where(mov => mov.Art.Codigo == codigoArt && mov.Tipo.Id == idTipo).Count();
        }

        public IEnumerable<ResumenMovimiento> ResumenMovimientos() {
            return Context.Movimientos.GroupBy(m => m.Fecha.Year).Select(g => new ResumenMovimiento {Anio = g.Key,Cantidad = g.Count(),ResumenesTipo = g.GroupBy(m => m.Tipo).Select(t => new ResumenTipo{Tipo = t.Key,Cantidad = t.Count()}).ToList()}).ToList();
        }
    }
}
