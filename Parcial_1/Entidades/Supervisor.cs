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
        private DateTime fechaNacimiento;
        private string direccion;
        private string telefono;
        private const string password = "superusuario";
        private static List<string>? listNombre;
        private static List<string>? listApellido;
        private static List<string>? listCargo;
        private static List<string>? listPassword;
        // va a haber que agregar datos del Supervisor cuando veamos base de datos

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
            this.fechaNacimiento = fechaNacimiento;
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

        public DateTime FechaNacimiento
        {
            get { return this.fechaNacimiento; }
            set { this.fechaNacimiento = value; }
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

        public bool ValidarPassword(string dato, Supervisor supervisor)
        {
            if (supervisor != null)
            {
                if (dato == password && supervisor.Puesto == "Supervisor")
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

        public static List<string> HardcodearNombre()
        {
            listNombre = new List<string>();

            //-------------- Op --------------//
            listNombre.Add("Juan");
            listNombre.Add("Santiago");
            listNombre.Add("Gabriel");
            listNombre.Add("Martin");
            //-------------- Su --------------//
            listNombre.Add("Kenpachi");
            listNombre.Add("Brandon");
            listNombre.Add("Stephen");
            listNombre.Add("Marcos");

            return listNombre;
        }

        public static List<string> HardcodearApellido()
        {
            listApellido = new List<string>();

            //-------------- Op --------------//
            listApellido.Add("Carlos");
            listApellido.Add("Cano");
            listApellido.Add("Abano");
            listApellido.Add("Santos");
            //-------------- Su --------------//
            listApellido.Add("Zaraki");
            listApellido.Add("Sanderson");
            listApellido.Add("King");
            listApellido.Add("Rodriguez");

            return listApellido;
        }

        public static List<string> HardcodearCargo()
        {
            listCargo = new List<string>();

            if (listNombre != null)
            {
                //-------------- Op --------------//
                for (int i = 0; listNombre.Count / 2 > i; i++)
                {
                    listCargo.Add("Operario");
                }
                //-------------- Su --------------//
                for (int i = 0; listNombre.Count / 2 > i; i++)
                {
                    listCargo.Add("Supervisor");
                }
            }

            return listCargo;
        }

        public static List<string> HardcodearPassword()
        {
            listPassword = new List<string>();

            if (listNombre != null)
            {
                //-------------- Op --------------//
                for (int i = 0; listNombre.Count / 2 > i; i++)
                {
                    listPassword.Add("operario");
                }
                //-------------- Su --------------//
                for (int i = 0; listNombre.Count / 2 > i; i++)
                {
                    listPassword.Add("superusaurio");
                }
            }

            return listPassword;
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
            sb.AppendLine($"Fecha Nacimiento: {this.fechaNacimiento.ToString("dd/MM/yyyy")}");
            sb.AppendLine($"Direccion: {this.direccion}");
            sb.AppendLine($"Telefono: {this.telefono}");

            return sb.ToString();
        }
    }
}
