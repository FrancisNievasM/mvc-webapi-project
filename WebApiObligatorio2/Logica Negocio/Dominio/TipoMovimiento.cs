using LogicaNegocio.Exceptions;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class TipoMovimiento :IValidable{
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Tipo {  get; set; }

        public TipoMovimiento() { } 
        public TipoMovimiento(string nombre, string tipo) {
            Nombre = nombre;
            Tipo = tipo;
        }

        public void EsValido() {
            if(Nombre == null || Tipo == null) throw new DatosInvalidosException("Nombre y Tipo no pueden ser vacios");
            if (Tipo != "SUMA" && Tipo != "RESTA") throw new DatosInvalidosException("'Tipo' de Tipo Movimiento inválido");
        }
    }
}
