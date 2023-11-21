using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMateriales
    {
        /// <summary>
        /// Materiales que se modificaran en la DB
        /// </summary>
        /// <param name="material">Material a modificar en la DB</param>
        /// <param name="cantidadAgregar">Cantidad a modificar</param>
        /// <param name="id">ID que necesito para poder modificar datos en la DB</param>
        /// <returns>Retorna un true o flase si pudo o no modificar los datos</returns>
        bool Modificar(string material, int cantidadAgregar, int id);

        /// <summary>
        /// Lectura de datos de la DB
        /// </summary>
        /// <param name="id">ID para poder interactuar con la DB</param>
        /// <param name="material">Material que voy a leer</param>
        /// <returns>Retorna un int, la cantidad leida</returns>
        int LeerPorMaterial(int id, string material);
    }
}
