using LogicaNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.VOs {
    public class TipoUsuario {
        public string Value { get; init; }

        public TipoUsuario(string value) {
            this.Value = value;
            Validar();
        }

        private TipoUsuario() {
        }

        private void Validar() {
            if(Value != "Administrador" && Value != "Encargado") {
                throw new DatosInvalidosException("Tipo de usuario invalidos");
            }
        }
    }
}
