using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Exceptions {
    public class DatosInvalidosException : Exception {

        public DatosInvalidosException() { }

        public DatosInvalidosException(string message) : base(message) { }

        public DatosInvalidosException(string mensaje, Exception innerException) : base(mensaje, innerException) {
        }
    }
}
