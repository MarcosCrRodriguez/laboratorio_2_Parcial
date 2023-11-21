using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string mensaje) : this(mensaje, null)
        {

        }

        public InvalidPasswordException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
