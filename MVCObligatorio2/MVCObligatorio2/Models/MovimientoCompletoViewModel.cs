using System.ComponentModel.DataAnnotations;

namespace MVCObligatorio2.Models {
    public class MovimientoCompletoViewModel {
        public int Id { get; set; }
        public string Mail { get; set; }
        [Display(Name = "Nombre Tipo")]
        public string NombreTipo { get; set; }
        [Display(Name = "Nombre Articulo")]
        public string NombreArticulo { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        [Display(Name = "Tipo de Tipo")]
        public string TipoTipo {  get; set; }
    }
}
