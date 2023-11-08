using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class ObjectNullException : Exception
    {
        public ObjectNullException(string mensaje) : this(mensaje, null)
        {

        }

        public ObjectNullException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
