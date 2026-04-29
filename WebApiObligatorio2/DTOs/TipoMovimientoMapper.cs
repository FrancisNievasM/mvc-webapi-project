using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs {
    public class TipoMovimientoMapper {
        public static TipoMovimiento ToTipoMovimientoFromAlta(DTOAltaTipoMovimiento tmDTO) {
            TipoMovimiento tm = new TipoMovimiento() {
                Nombre = tmDTO.Nombre,
                Tipo = tmDTO.Tipo
            };
            return tm;
        }
        public static DTOMostrarTipoMovimiento ToMostrar(TipoMovimiento tm) {
            DTOMostrarTipoMovimiento dto = new DTOMostrarTipoMovimiento() {
                Id = tm.Id,
                Nombre = tm.Nombre,
                Tipo = tm.Tipo
            };
            return dto;
        }
        public static TipoMovimiento ToTipoMovimientoFromMostrar(DTOMostrarTipoMovimiento tmDTO) {
            TipoMovimiento tm = new TipoMovimiento() {
                Nombre = tmDTO.Nombre,
                Id = tmDTO.Id,
                Tipo = tmDTO.Tipo
            };
            return tm;
        }
        public static List<DTOMostrarTipoMovimiento> ToListDTOMostrar(List<TipoMovimiento> listaTM) {
            return listaTM.Select(tm => new DTOMostrarTipoMovimiento() {
                Nombre = tm.Nombre,
                Id = tm.Id,
                Tipo = tm.Tipo
            })
            .ToList();
        }
    }
}
