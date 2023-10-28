using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public static class ArchivosXML<T>
    {
        public static bool EscribirXML(string path, T obj)
        {
			try
			{
                using (StreamWriter sw = new StreamWriter(path))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(sw, obj);
                }
                return true;
            }
			catch (Exception)
			{
                //puedo fijarme si lanzo una excepcion 
                return false;
            }
        }
    }
}
