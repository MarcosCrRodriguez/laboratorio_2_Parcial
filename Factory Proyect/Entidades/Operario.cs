using ExcepcionesPropias;
using System.Text;

namespace Entidades
{
    public class Operario : Usuario
    {
        private string nombre;
        private string apellido;
        private long dni;
        private string email;
        private int edad;
        private DateTime fechaIngreso;
        private string direccion;
        private string telefono;
        private const string password = "operario";

        public Operario(int id, string puesto) : base(id, puesto)
        {

        }
        public Operario(int id, string puesto, string nombre, string apellido, long dni) : this(id, puesto)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }

        public Operario(int id, string puesto, string nombre, string apellido, long dni, string email, int edad, DateTime fechaNacimiento, string direccion, string telefono) : this(id, puesto, nombre, apellido, dni)
        {
            this.email = email;
            this.edad = edad;
            this.fechaIngreso = fechaNacimiento;
            this.direccion = direccion;
            this.telefono = telefono;
        }


        #region Propiedades
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }

        /// <summary>
        /// Retorna el valor del DNI
        /// </summary>
        public long DNI
        {
            get { return this.dni; }
        }

        /// <summary>
        /// Retorna la cadena de Email
        /// </summary>
        public string Email
        {
            get { return this.email; }
        }

        /// <summary>
        /// Retorna el valor del Edad
        /// </summary>
        public int Edad
        {
            get { return this.edad; }
        }

        /// <summary>
        /// Retorna el dato DateTime de FechaIngreso
        /// </summary>
        public DateTime FechaIngreso
        {
            get { return this.fechaIngreso; }
        }

        /// <summary>
        /// Retorna la cadena de Direccion
        /// </summary>
        public string Direccion
        {
            get { return this.direccion; }
        }

        /// <summary>
        /// Retorna la cadena de Telefono
        /// </summary>
        public string Telefono
        {
            get { return this.telefono; }
        }

        /// <summary>
        /// Retorna la cadena de Password
        /// </summary>
        public string Password
        {
            get { return password; }
        }
        #endregion

        /// <summary>
        /// Castea un dato a entero
        /// </summary>
        /// <param name="dato">Dato a convertir en entero</param>
        /// <returns>Retorna el valor de un entero</returns>
        /// <exception cref="FormatException">Formato incorrecto</exception>
        public static int CasteoInt(string dato)
        {
            int numeroInt;

            if (int.TryParse(dato, out numeroInt))
            {
                return numeroInt;
            }
            else
            {
                throw new FormatException("El formato de entrada no es correcto");
            }
        }

        /// <summary>
        /// Castea un valor a long
        /// </summary>
        /// <param name="dato">Dato a convertir en tipo long</param>
        /// <returns>Retorna el valor de un long</returns>
        /// <exception cref="FormatException">Formato incorrecto</exception>
        public static long CasteoLong(string dato)
        {
            long numeroLong;

            if (long.TryParse(dato, out numeroLong))
            {
                return numeroLong;
            }
            else
            {
                throw new FormatException("El formato de entrada no es correcto");
            }
        }

        /// <summary>
        /// Validamos que la contraseña sea igual a la requrida
        /// </summary>
        /// <param name="dato">Dato que contiene la contraseña ingresada por el usuario</param>
        /// <param name="operario">Operario con sus datos ingresados</param>
        /// <returns>Retora true si cumple o false si no cumple con las condiciones</returns>
        /// <exception cref="InvalidPasswordException">Contraseña ingresada incorrecta</exception>
        public static bool ValidarPasswordOperario(string dato)
        {
            if (dato != password)
            {
                throw new InvalidPasswordException("La constraseña es invalida\n-> [InvalidPasswordException]");
            }
            else if (dato == password)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verificamos mediante los parametros ingresados que el operario existe en la DB
        /// </summary>
        /// <param name="operarios">Lista de operarios existente de la DB</param>
        /// <param name="op">Operario ingresado por el usuario</param>
        /// <returns>Retorna ture si cumple y flase si no cumple con las condiciones</returns>
        public bool VerificarExisteOperario(List<Operario> operarios, Operario op) 
        {
            if (operarios.Count > 0 && operarios != null)
            {
                foreach (var operario in operarios)
                {
                    if (op.ID == operario.ID)
                    {
                        return true;
                    }
                }   
            }
            return false;
        }

        /// <summary>
        /// Verificamos que el ID ingresado existe en la DB
        /// </summary>
        /// <param name="operarios">Lista de operarios existente de la DB</param>
        /// <param name="id">ID ingresado por el usuario</param>
        /// <returns>Retorna ture si cumple y flase si no cumple con las condiciones</returns>
        public static bool VerificarExisteID(List<Operario> operarios, int id)
        {
            if (operarios.Count > 0 && operarios != null)
            {
                foreach (var operario in operarios)
                {
                    if (id == operario.ID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Mostramos datos del Operario
        /// </summary>
        /// <returns>Returonamos un string con los datos de Operario</returns>
        public override string Mostrar()
        {
            string cadena;

            StringBuilder sb = new StringBuilder();
            cadena = base.Mostrar();
            sb.Append(cadena);
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Apellido: {this.apellido}");
            sb.AppendLine($"DNI: {this.dni}");

            return sb.ToString();
        }

        /// <summary>
        /// Mostramos datos del Operario (sobrecarga)
        /// </summary>
        /// <param name="o">Operario a mostrar</param>
        public static explicit operator string(Operario o)
        {
            string cadena;

            StringBuilder sb = new StringBuilder();
            cadena = o.Mostrar();
            sb.Append(cadena);

            return sb.ToString();
        }

        /// <summary>
        /// Mostramos datos del Operario
        /// </summary>
        /// <returns>Returonamos un string con los datos de Operario</returns>
        public string MostrarTodosDatos()
        {
            string cadena;

            StringBuilder sb = new StringBuilder();
            cadena = base.Mostrar();
            sb.Append(cadena);
            sb.AppendLine($"Email: {this.email}");
            sb.AppendLine($"Edad: {this.edad}");
            sb.AppendLine($"Fecha Nacimiento: {this.fechaIngreso.ToString("dd/MM/yyyy")}");
            sb.AppendLine($"Direccion: {this.direccion}");
            sb.AppendLine($"Telefono: {this.telefono}");

            return sb.ToString();
        }
    }
}
