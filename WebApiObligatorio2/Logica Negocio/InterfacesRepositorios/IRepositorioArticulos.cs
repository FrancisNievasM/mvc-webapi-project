using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios {
    public interface IRepositorioArticulos : IRepositorio<Articulo> {

        Articulo FindByCode(string code);
        public List<Articulo> ArticulosEntreFechas(DateTime fechaIni, DateTime fechaFin, int pagina);
        int CantidadArticulosEntreFechas(DateTime fechaIni, DateTime fechaFin);
    }
}
