using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class NegativeValueException : Exception
    {
        public NegativeValueException(string mensaje) : this(mensaje, null)
        {

        }

        public NegativeValueException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
