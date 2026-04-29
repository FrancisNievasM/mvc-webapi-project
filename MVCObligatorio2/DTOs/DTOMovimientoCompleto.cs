using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs {
    public class DTOMovimientoCompleto {
        public int Id { get; set; }
        public string NombreArt { get; set; }
        public int Cantidad { get; set; }
        public string Mail { get; set; }
        public string NombreTipo { get; set; }
        public string TipoTipo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
