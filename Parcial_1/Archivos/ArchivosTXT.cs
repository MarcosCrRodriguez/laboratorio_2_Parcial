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
