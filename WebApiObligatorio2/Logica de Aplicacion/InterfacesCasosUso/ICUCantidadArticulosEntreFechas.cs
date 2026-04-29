using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosUso {
    public interface ICUCantidadArticulosEntreFechas {
        int CantidadArticulosEntreFechas(DateTime fechaIni, DateTime fechaFin);
    }
}
