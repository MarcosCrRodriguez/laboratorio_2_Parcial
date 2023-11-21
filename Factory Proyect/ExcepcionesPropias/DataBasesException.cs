using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class DataBasesException : Exception
    {
        public DataBasesException(string mensaje) : this(mensaje, null)
        {

        }

        public DataBasesException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
