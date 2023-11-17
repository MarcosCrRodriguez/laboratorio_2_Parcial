using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivos<T> 
    {
        /// <summary>
        /// Generamos un archivo
        /// </summary>
        /// <param name="path">Ruta dedl archivo</param>
        /// <param name="dato">Dato que le cargaremos al archivo</param>
        /// <returns>Retorna un true o false si pudo o no generar el archivo</returns>
        bool EscribirArchivo(string path, T dato);
    }
}
