using DTOs;
using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso {
    public interface ICUBuscarMovimientosDeArticulo {
        List<DTOMovimientoCompleto> BuscarMovimientosDeArticulo(string codigoArt, int idTipo, int pagina);
    }
}
