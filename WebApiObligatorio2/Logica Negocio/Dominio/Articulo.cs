using LogicaNegocio.Exceptions;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class Articulo : IValidable {
        [Key]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public int Precio { get; set; }
        public static int CantMaxPorPagina { get; set; }

        public Articulo() {

        }

        public Articulo(string nombre, string descripcion, string codigo, int precio) {
            Nombre = nombre;
            Descripcion = descripcion;
            Codigo = codigo;
            Precio = precio;
        }

        public void EsValido() {
            if (Nombre.Length < 10 || Nombre.Length > 200) {
                throw new DatosInvalidosException("El largo del nombre debe estar entre 10 y 200 caracteres");
            }else if(Codigo == null || Codigo.Length != 13) {
                throw new DatosInvalidosException("El código debe tener exactamente 13 caracteres");
            } else if(Precio < 0) {
                throw new DatosInvalidosException("El precio debe ser mayor a cero");
            }

        }
    }
}

