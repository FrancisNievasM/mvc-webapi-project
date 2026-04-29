using LogicaNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.VOs {

    //[Owned]
    public class MailUsuario {
        public string Value { get; init; }

        public MailUsuario(string value) {
            this.Value = value;
            Validar();
        }

        private MailUsuario() {
        }

        private void Validar() {
            string validados = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ.1234567890";
 
            if(this.Value != null && this.Value.Contains("@") && this.Value.EndsWith(".com")) {
                string substringMail = Value.Substring(0,Value.IndexOf("@"));
                bool substringValid = true;
                for (int i = 0; i < substringMail.Length; i++) {
                    if (!validados.Contains(substringMail[i])) {
                        substringValid = false; break;
                    }
                }
                if (substringMail.Length < 3 || !substringValid) {
                    throw new DatosInvalidosException("Correo Invalido");
                }
            } else {
                throw new DatosInvalidosException("Correo Invalido");
            }

        }
        public override bool Equals(object? obj) {
            MailUsuario otro = obj as MailUsuario;
            if (otro == null) return false;
            return otro.Value == Value;
        }
    }
}
