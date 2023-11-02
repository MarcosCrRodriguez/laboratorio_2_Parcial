﻿using System.Text;

namespace Entidades
{
    public class Operario : Usuario
    {
        private int id;
        private string puesto;
        private long dni;
        private string email;
        private int edad;
        private DateTime fechaNacimiento;
        private string direccion;
        private string telefono;
        private const string password = "operario";
        private static List<string>? listNombre;
        private static List<string>? listApellido;
        private static List<string>? listSector;
        // va a haber que agregar datos del Supervisor cuando veamos base de datos

        public Operario(string nombre, string apellido) : base(nombre, apellido)
        {
            this.puesto = "Operario";
        }
        public Operario(string nombre, string apellido, int id, string puesto, long dni) : this(nombre, apellido)
        {
            this.id = id;
            this.puesto = puesto;
            this.dni = dni;
        }

        public Operario(string nombre, string apellido, int id, string puesto, long dni, string email, int edad, DateTime fechaNacimiento, string direccion, string telefono) : this(nombre, apellido, id, puesto, dni)
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

        public bool ValidarPassword(string dato, Operario operario)
        {
            if (operario != null)
            {
                if (dato == password && operario.Puesto == "Operario")
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificarExisteOperario(List<Operario> operarios, Operario op) 
        {
            if (operarios.Count > 0 && operarios != null)
            {
                foreach (var operario in operarios)
                {
                    if (op.ID == operario.ID && op.DNI == operario.DNI && op.Puesto == operario.Puesto)
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

            listNombre.Add("Juan");
            listNombre.Add("Santiago");
            listNombre.Add("Gabriel");
            listNombre.Add("Martin");
            listNombre.Add("Pedro");
            listNombre.Add("Julieta");
            listNombre.Add("Pablo");
            listNombre.Add("Cecilia");

            return listNombre;
        }

        public static List<string> HardcodearApellido()
        {
            listApellido = new List<string>();

            listApellido.Add("Carlos");
            listApellido.Add("Cano");
            listApellido.Add("Abano");
            listApellido.Add("Santos");
            listApellido.Add("Ramon");
            listApellido.Add("Indigo");
            listApellido.Add("Perez");
            listApellido.Add("Bernau");

            return listApellido;
        }

        public static List<string> HardcodearSector()
        {
            listSector = new List<string>();

            listSector.Add("Cabinet");
            listSector.Add("Cabinet");
            listSector.Add("Motherboard");
            listSector.Add("Motherboard");
            listSector.Add("Ram");
            listSector.Add("Ram");
            listSector.Add("Video Card");
            listSector.Add("Video Card");

            return listSector;
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

        public static explicit operator string(Operario s)
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
