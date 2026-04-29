using LogicaNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.VOs {
    public class NombreUsuario {
        public string Value { get; init; }

        public NombreUsuario(string value) {
            this.Value = value;
            Validar();
        }

        private NombreUsuario()
        {
        }

        public void Validar() {
            string validadosLetras = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZñÑÁáÉéÍíÓóÚúÜü- '";
            string validadosNoLetras = "- '";
            bool stringValid = true;
            if (this.Value != null) {
                for (int i = 0; i < validadosNoLetras.Length; i++) {
                    if (Value.StartsWith(validadosNoLetras[i]) || Value.EndsWith(validadosNoLetras[i])) {
                        stringValid = false; break;
                    }
                }
                if (stringValid) {
                    for(int i = 0; i < Value.Length;i++) {
                        if (!validadosLetras.Contains(Value[i])) {
                            stringValid = false; break;
                        }
                    }
                }
                if (!stringValid) {
                    throw new DatosInvalidosException("Nombre o Apellido Invalido");
                }
            } else {
                throw new DatosInvalidosException("Nombre o Apellido Invalido");
            }

        }

        public override bool Equals(object? obj) {
            NombreUsuario otro = obj as NombreUsuario;
            if (otro == null) return false;
            return otro.Value == Value;
        }
    }
}
