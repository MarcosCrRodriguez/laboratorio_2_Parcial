using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IUsuario<T> 
        where T : Usuario
    {
        /// <summary>
        /// Registrar un Usuario en la DB
        /// </summary>
        /// <param name="usuario">Usuario a registrar</param>
        /// <returns>Retorna un true o flase si pudo o no registrar correctamente un Usuario en la DB</returns>
        bool GuardarRegistro(T usuario);

        /// <summary>
        /// Leo un Usuario por ID de la DB
        /// </summary>
        /// <param name="id">ID necesario para saber a que Usuario visualizare</param>
        /// <returns>Retorno un Usuario</returns>
        T LeerPorID(int id);

        /// <summary>
        /// Leo un Usuario por DNI de la DB
        /// </summary>
        /// <param name="dni">DNI necesario para saber a que Usuario visualizare</param>
        /// <returns>Retorno un Usuario</returns>
        T LeerPorDNI(long dni);
    }
}
