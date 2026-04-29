using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs {
    public class MovimientoMapper {
        public static DTOMostrarMovimiento ToMostrar(Movimiento unMov) {
            DTOMostrarMovimiento dto = new DTOMostrarMovimiento() {
                Id = unMov.Id,
                NombreArt = unMov.Art.Nombre,
                NombreTipo = unMov.Tipo.Nombre,
                Mail = unMov.Mail.Value,
                Cantidad = unMov.Cantidad,
            };
            return dto;
        }
        public static List<DTOMovimientoCompleto> ToListDTOCompleto(List<Movimiento> listaMov) {
            return listaMov.Select(m => new DTOMovimientoCompleto() {
                Id = m.Id,
                NombreArt = m.Art.Nombre,
                NombreTipo = m.Tipo.Nombre,
                Mail = m.Mail.Value,
                Cantidad = m.Cantidad,
                TipoTipo = m.Tipo.Tipo,
                Fecha = m.Fecha
            })
            .ToList();
        }
        public static List<DTOResumen> ToListDTOResumen(IEnumerable<ResumenMovimiento> listaRes) {
            return listaRes.Select(m => new DTOResumen() {
                Anio = m.Anio,
                ResumenesTipos = ToListDTOResumenTipo(m.ResumenesTipo),
                Cantidad = m.Cantidad
            })
            .ToList();
        }

        public static List<DTOResumenTipo> ToListDTOResumenTipo(List<ResumenTipo> listaRestipo) {
            return listaRestipo.Select(m => new DTOResumenTipo() {
                NombreTipo = m.Tipo.Nombre,
                Cantidad = m.Cantidad
            })
            .ToList();
        }
    }
}
