namespace ExcepcionesPropias
{
    public class EmptyParametersException : Exception
    {
        public EmptyParametersException(string mensaje) : this(mensaje, null)
        {

        }

        public EmptyParametersException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}