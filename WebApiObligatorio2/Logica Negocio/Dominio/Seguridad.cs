using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LogicaNegocio.Dominio {
    public static class Seguridad {
        public static string EncriptarContraseña(string password) {
            SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hash = "";
            for (int i = 0; i < bytes.Length; i++) {
                hash += bytes[i].ToString("x2");
            }
            sha256Hash.Dispose();
            return hash;
        }
    }
}
