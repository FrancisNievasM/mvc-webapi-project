using LogicaNegocio.Dominio;
using LogicaNegocio.Exceptions;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios {
    public class RepositorioTipoMovimiento : IRepositorio<TipoMovimiento> {
        public LibreriaContext Context { get; set; }
        public RepositorioTipoMovimiento(LibreriaContext context) {
            Context = context;
        }

        public void Add(TipoMovimiento item) {
            bool nombreExistente = Context.Set<TipoMovimiento>().Any(tm => tm.Nombre.Equals(item.Nombre));
            if (nombreExistente) {
                throw new DatosInvalidosException("Ya existe un tipo de movimiento con el mismo nombre.");
            }
            Context.Add(item);
            Context.SaveChanges();
        }

        public List<TipoMovimiento> FindAll() {
            return Context.TipoMovimientos.ToList();
        }

        public TipoMovimiento FindById(int id) {
            TipoMovimiento tm = Context.TipoMovimientos
                .Where(tm => tm.Id == id)
                .SingleOrDefault();
            return tm;
        }

        public void Remove(int id) {
            if(Context.Movimientos.Where(mov => mov.Tipo.Id == id).Any()) {
                throw new DatosInvalidosException("No fue posible eliminar el tipo de movimiento. Ya que existen Movimientos que lo utilizan");
            }
            TipoMovimiento tm = FindById(id);
            if (tm == null) { throw new NotFoundException("No existe un tipo de movimiento con ésta Id"); }
            Context.TipoMovimientos.Remove(tm);
            Context.SaveChanges();
        }

        public void Update(TipoMovimiento item) {
            Context.TipoMovimientos.Update(item);
            Context.SaveChanges();
        }
    }
}
