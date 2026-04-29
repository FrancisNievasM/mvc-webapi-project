namespace MVCObligatorio2.Exceptions {
    public class ExcepcionPropiaException : Exception{
        public ExcepcionPropiaException() { }

        public ExcepcionPropiaException(string message) : base(message) { }

        public ExcepcionPropiaException(string mensaje, Exception innerException) : base(mensaje, innerException) {
        }
    }
}
