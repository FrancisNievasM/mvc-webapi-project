using LogicaNegocio.Exceptions;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.VOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class Usuario : IValidable {

        public int Id { get; set; }
        [Column("Mail")]
        public MailUsuario Mail { get; set; }
        [Column("Nombre")]
        public NombreUsuario Nombre { get; set; }
        [Column("Apellido")]
        public NombreUsuario Apellido { get; set; }
        public string Password { get; set; }
        public string PasswordEncrypted { get; set; }
        public TipoUsuario Tipo { get; set; }
        public Usuario() { }
        public Usuario(string mail, string nombre, string apellido, string password, string passwordEnc, string tipo) {
            Mail = new MailUsuario(mail);
            Nombre = new NombreUsuario(nombre);
            Apellido = new NombreUsuario(apellido);
            Password = password;
            PasswordEncrypted = passwordEnc;
            Tipo = new TipoUsuario(tipo);
        }

        public void EsValido() {
            if (Mail != null && Nombre != null && Apellido != null) {
                string puntuacion = ".;,!";
                string digitos = "1234567890";
                bool passValid = false;
                for (int i = 0; i < puntuacion.Length; i++) {
                    if (Password.Contains(puntuacion[i])) {
                        passValid = true;
                        break;
                    }
                }
                if (passValid) {
                    passValid = false;
                    for (int i = 0; i < digitos.Length; i++) {
                        if (Password.Contains(digitos[i])) {
                            passValid = true;
                            break;
                        }
                    }
                }
                if (Password.ToUpper() == Password || Password.ToLower() == Password) {
                    passValid = false;
                }
                if(Password.Length <= 6) {
                    passValid = false;
                }
                if (!passValid) {
                    throw new DatosInvalidosException("La contraseña debe tener al menos una Mayuscula, una Minuscula, un signo de puntuacion, un digito y más de 6 caracteres");
                }
            } else {
                throw new DatosInvalidosException("Los campos no pueden ser nulos");
            }
        }
    }
}
