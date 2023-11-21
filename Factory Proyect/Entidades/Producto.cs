using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto : Empresa
    {
        private static IMateriales manejadorProductos;
        protected static ulong codigoFabricacion;
        protected Producto()
        {
            manejadorProductos = new ProductosDAO();
            codigoFabricacion = (ulong)new Random().Next(10000000, 99999999);
        }

        #region Propiedades
        protected ulong CodigoFabricacion
        {
            get { return codigoFabricacion; }
            set { codigoFabricacion = value; }
        }
        #endregion

        /// <summary>
        /// Verificamos que las cantidades "a agregar" a la DB no sean negativas
        /// </summary>
        /// <param name="cantidadAgregar">Cantidad a agregar</param>
        /// <param name="id">ID del material</param>
        /// <param name="material">Nombre del material</param>
        /// <returns>Retorna de ser el caso, la cantidad a agregar, con su diferencia calculada</returns>
        /// <exception cref="NegativeValueException">Error si el valor a devolver es negativo</exception>
        /// <exception cref="FormatException">Error de formato con algun dato trabajado</exception>
        /// <exception cref="Exception">Captura algun error generico</exception>
        public static int VerificarValorPositivo(int cantidadAgregar, int id, string material)
        {
            int rtn = -1;
            int cantidadProducto;

            try
            {
                cantidadProducto = manejadorProductos.LeerPorMaterial(id, material);
                if (cantidadProducto != -1)
                {
                    cantidadAgregar += cantidadProducto;
                    if (cantidadAgregar >= 0)
                    {
                        rtn = cantidadAgregar;
                    }
                    else
                    {
                        throw new NegativeValueException("El valor en Stock no puede ser menor que 0 - [NegativeValueException]");
                    }
                }
                else
                {
                    throw new NegativeValueException("El valor en Stock no puede ser menor que 0 - [NegativeValueException]");
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException("Error con el formato de la cantidad ingresada", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error inesperado", ex);
            }
            return rtn;
        }

        /// <summary>
        /// Metodo abstracto de la clase base, Fabricación del producto
        /// </summary>
        /// <param name="valor">Valor que le dara positivo o negativo</param>
        /// <param name="lista">Lista </param>
        /// <returns></returns>
        public abstract bool FabricarProducto(int valor, List<int> lista);

        /// <summary>
        /// Metodo abstracto mostrar que heredara en sus distintos Productos
        /// </summary>
        /// <returns>Retornara un string con datos del Producto</returns>
        public abstract string Mostrar();
    }
}

