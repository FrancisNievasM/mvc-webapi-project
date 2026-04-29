using System.ComponentModel.DataAnnotations;

namespace MVCObligatorio2.Models {
    public class ResumenViewModel {
        [Display(Name = "Año")]
        public int Anio { get; set; }
        [Display(Name = "Tipo")]
        public List<ResumenTipoViewModel> ResumenesTipo { get; set; } = new List<ResumenTipoViewModel>();
        [Display(Name ="Total anual")]
        public int Cantidad { get; set; }
    }
}
