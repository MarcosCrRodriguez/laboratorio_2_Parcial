using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesPropias
{
    public class SqlExceptionDuplicateUserDB : Exception
    {
        public SqlExceptionDuplicateUserDB(string mensaje) : this(mensaje, null)
        {

        }

        public SqlExceptionDuplicateUserDB(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
