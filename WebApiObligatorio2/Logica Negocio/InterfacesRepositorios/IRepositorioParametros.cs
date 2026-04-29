using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios {
    public interface IRepositorioParametros {
        int FindCantMaxMovimientos();
        int FindCantMaxArticulos();
        int FindTopeCant();
    }
}
