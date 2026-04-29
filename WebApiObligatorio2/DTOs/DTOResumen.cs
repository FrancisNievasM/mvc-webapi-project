using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs {
    public class DTOResumen {
        public int Anio { get; set; }
        public List<DTOResumenTipo> ResumenesTipos { get; set; }
        public int Cantidad { get; set; }
    }
}
