using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Archivos
{
    public class ArchivosJSON<T> : IArchivos<T> where T : class
    {
        public bool EscribirArchivo(string path, T dato)
        {
            bool rtn = false;

			try
			{
                JsonSerializerOptions opciones = new JsonSerializerOptions 
                { 
                    Converters = { new JsonStringEnumConverter() } 
                };
                opciones.WriteIndented = true;

                string jsonString = JsonSerializer.Serialize(dato, opciones);

                File.WriteAllText(path, jsonString);
                rtn = true;
            }
            catch (UnauthorizedAccessException ex)

            {
                throw new UnauthorizedAccessException("Problemas de permisos", ex);
            }
            catch (JsonException ex)

            {
                throw new JsonException("Ocurrio un problema con la serializacion Json", ex); 
            }
            catch (Exception ex)
			{
                throw new Exception("Error al trabajar con el archivo", ex); 
            }
            return rtn;
        }

        public static T LeerArchivo(string path)
        {
            try
            {
                string objetoJson = File.ReadAllText(path);
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
                {
                    Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
                };
                jsonSerializerOptions.WriteIndented = true;

                T objetoDeserealizado = JsonSerializer.Deserialize<T>(objetoJson, jsonSerializerOptions);

                return objetoDeserealizado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
