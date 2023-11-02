using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class ObjetoNullException : Exception
    {
        public ObjetoNullException(string mensaje) : this(mensaje, null)
        {

        }

        public ObjetoNullException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
