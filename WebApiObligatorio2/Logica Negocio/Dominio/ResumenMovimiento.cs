using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class ResumenMovimiento {
        public int Anio {  get; set; }
        public List<ResumenTipo> ResumenesTipo {  get; set; } 
        public int Cantidad { get; set; }

    }
}
