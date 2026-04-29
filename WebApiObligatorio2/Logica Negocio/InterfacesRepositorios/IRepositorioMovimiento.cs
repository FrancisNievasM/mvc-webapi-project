using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios {
    public interface IRepositorioMovimiento{
        public List<Movimiento> MovimientosSobreArticulo(string codigoArt, int idTipo, int pagina);
        public Movimiento FindById(int id);
        void Add(Movimiento item);

        int CantidadMovimientosSobreArticulo(string codigoArt, int idTipo);

        IEnumerable<ResumenMovimiento> ResumenMovimientos();

        
    }
}
