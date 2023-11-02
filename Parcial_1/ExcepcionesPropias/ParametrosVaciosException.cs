namespace ExcepcionesPropias
{
    public class ParametrosVaciosException : Exception
    {
        public ParametrosVaciosException(string mensaje) : this(mensaje, null)
        {

        }

        public ParametrosVaciosException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}