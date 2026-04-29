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
    public class CUArticulosEntreFechas : ICUArticulosEntreFechas {
        IRepositorioArticulos Repo {  get; set; }
        public CUArticulosEntreFechas(IRepositorioArticulos repo) {
            Repo = repo;
        }

        public List<DTOArticulo> ArticulosEntreFechas(DateTime fechaIni, DateTime fechaFin, int pagina) {
            if(fechaIni > fechaFin) {
                throw new DatosInvalidosException("La primera fecha debe ser anterior a la segunda");
            }
            return ArticuloMapper.ToListDTO(Repo.ArticulosEntreFechas(fechaIni, fechaFin, pagina));
        }
    }
}
