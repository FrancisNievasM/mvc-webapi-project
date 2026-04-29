namespace MVCObligatorio2.Models {
    public class AltaMovimientoViewModel {
        public int IdTipo {  get; set; }
        public string CodigoArti {  get; set; }
        public int Cantidad { get; set; }
        public List<ArticuloReducidoViewModel> ? Articulos { get; set; }
        public List<TipoMovimientoViewModel>? Tipos { get; set; }
    }
}
