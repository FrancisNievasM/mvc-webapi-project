using LogicaNegocio.Exceptions;
using LogicaNegocio.InterfacesDominio;
using LogicaNegocio.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio {
    public class Movimiento : IValidable{
        public int Id { get; set; }
        public Articulo Art { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public TipoMovimiento Tipo {  get; set; }
        public MailUsuario Mail {  get; set; }
        public static int CantMaxPorPagina {get;set;}
        public static int TopeCant { get;set;}

    public Movimiento() { }
        public Movimiento(Articulo art, DateTime fecha, int cantidad, TipoMovimiento tipo, string mail) {
            Art = art;
            Fecha = fecha;
            Cantidad = cantidad;
            Tipo = tipo;
            Mail = new MailUsuario(mail);
        }

        public void EsValido() {
            if(Mail == null || Art == null ||Tipo == null) throw new DatosInvalidosException("Todos los campos deben ser completados");
            if (Cantidad < 0) throw new DatosInvalidosException("La cantidad debe ser mayor  o igual a cero");
        }
    }
}
