using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivos<T> 
    {
        bool EscribirArchivo(string path, T dato);
    }
}
