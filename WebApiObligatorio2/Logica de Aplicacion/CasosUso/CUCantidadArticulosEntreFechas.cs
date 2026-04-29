using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Exceptions;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso {
    public class CUCantidadArticulosEntreFechas : ICUCantidadArticulosEntreFechas {
        public IRepositorioArticulos Repo { get; set; }
        public CUCantidadArticulosEntreFechas(IRepositorioArticulos repo) {
            Repo = repo;
        }

        public int CantidadArticulosEntreFechas(DateTime fechaIni, DateTime fechaFin) {
            if (fechaIni > fechaFin) {
                throw new DatosInvalidosException("La primera fecha debe ser anterior a la segunda");
            }
            return Repo.CantidadArticulosEntreFechas(fechaIni, fechaFin);
        }
    }
}
