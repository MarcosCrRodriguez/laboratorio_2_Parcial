using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Archivos
{
    public class ArchivosTXT<T> : IArchivos<T>
    {
        /// <summary>
        /// Genero un archivo TXT
        /// </summary>
        /// <param name="path">Ruta del archivo</param>
        /// <param name="dato">Dato a cargar en el archivo</param>
        /// <returns>Retorna true o flase si pudo o no cargar el archivo correctamente</returns>
        /// <exception cref="Exception">Error generico</exception>
        public bool EscribirArchivo(string path, T dato)
        {
            bool rtn = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(dato);
                    sw.Close();
                }
                rtn =  true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la carga del archivo", ex);
            }
            return rtn;
        }
    }
}
