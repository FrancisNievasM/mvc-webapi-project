using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs {
    public class ArticuloMapper {
        public static List<DTOArticulo> ToListDTO(List<Articulo> listaArt) {
            return listaArt.Select(a => new DTOArticulo() {
                Codigo = a.Codigo,
                Nombre = a.Nombre,
                Descripcion = a.Descripcion,
                Precio = a.Precio
            })
            .ToList();
        }
        public static List<DTOArticuloReducido> ToListDTOReducido(List<Articulo> listaArt) {
            return listaArt.Select(a => new DTOArticuloReducido() {
                CodigoArt = a.Codigo,
                Nombre = a.Nombre,
            })
            .ToList();
        }
    }
}
