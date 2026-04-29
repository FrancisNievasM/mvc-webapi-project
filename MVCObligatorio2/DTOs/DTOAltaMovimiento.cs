using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs {
    public class DTOAltaMovimiento {
        public string CodigoArt { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Mail { get; set; }
        public int IdTipo { get; set; }
    }
}
