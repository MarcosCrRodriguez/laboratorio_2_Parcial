using ExcepcionesPropias;
using System.Net.NetworkInformation;
using System.Text;

namespace Entidades
{

    public class Supervisor : Usuario
    {
        private int id;
        private string puesto;
        private long dni;
        private string email;
        private int edad;
        private DateTime fechaIngreso;
        private string direccion;
        private string telefono;
        private const string password = "superusuario";

        public Supervisor(string nombre, string apellido) : base(nombre, apellido)
        {
            this.puesto = "Supervisor";
        }
        public Supervisor(string nombre, string apellido, int id, string puesto, long dni) : this(nombre, apellido)
        {
            this.id = id;
            this.puesto = puesto;
            this.dni = dni;
        }

        public Supervisor(string nombre, string apellido, int id, string puesto, long dni, string email, int edad, DateTime fechaNacimiento, string direccion, string telefono) : this(nombre, apellido, id, puesto, dni)
        {
            this.email = email;
            this.edad = edad;
            this.fechaIngreso = fechaNacimiento;
            this.direccion = direccion;
            this.telefono = telefono;
        }


        #region Propiedades
        public int ID
        {
            get { return this.id; }
        }

        public long DNI
        {
            get { return this.dni; }
            set { this.dni = value; }
        }
        public string Puesto
        {
            get { return this.puesto; }
            set { this.puesto = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }

        public DateTime FechaIngreso
        {
            get { return this.fechaIngreso; }
            set { this.fechaIngreso = value; }
        }

        public string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }

        public string Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }

        public string Password
        {
            get { return password; }
        }
        #endregion

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

        public bool ValidarPasswordSupervisor(string dato, Supervisor supervisor)
        {
            if (supervisor != null)
            {
                if (dato != password)
                {
                    throw new InvalidPasswordException("La constraseña es invalida - [InvalidPasswordException]");
                }
                else if (dato == password && supervisor.Puesto == "Supervisor")
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificarExisteSupervisor(List<Supervisor> supervisores, Supervisor su)
        {
            if (supervisores.Count > 0 && supervisores != null)
            {
                foreach (var supervisor in supervisores)
                {
                    if (su.ID == supervisor.ID && su.DNI == supervisor.DNI && su.Puesto == supervisor.Puesto
                        && su.Nombre == supervisor.Nombre && su.Apellido == supervisor.Apellido)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string Mostrar()
        {
            string cadena;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CODIGO_USUARIO: {this.id}");
            cadena = base.Mostrar();
            sb.Append(cadena);
            sb.AppendLine($"DNI: {this.dni}");
            sb.AppendLine($"Puesto: {this.puesto}");

            return sb.ToString();
        }

        public static explicit operator string(Supervisor s)
        {
            string cadena;

            StringBuilder sb = new StringBuilder();
            cadena = s.Mostrar();
            sb.Append(cadena);

            return sb.ToString();
        }

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
