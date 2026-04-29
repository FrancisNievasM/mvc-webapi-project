using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOs {
    public class DTOResumen {
        public int Anio { get; set; }
        public List<DTOResumenTipo> ? ResumenesTipos { get; set; } = new List<DTOResumenTipo>();
        public int Cantidad { get; set; }
    }
}
