using System.Net.NetworkInformation;
using System.Text;

namespace Entidades
{
    public class Supervisor : Usuario
    {
        protected string puesto;
        protected static List<string> listNombre;
        protected static List<string> listApellido;
        protected static List<string> listCargo;
        protected static List<string> listPassword;
        public Supervisor(string nombre, string apellido, string puesto)
            :base(nombre, apellido)
        {
            this.puesto = puesto;
        }

        public string Puesto
        {
            get { return this.puesto; }
            set { this.puesto = value; }
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

            return listCargo;
        }

        public static List<string> HardcodearPassword()
        {
            listPassword = new List<string>();

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

            return listPassword;
        }

        public override string Mostrar()
        {
            string cadena;

            StringBuilder sb = new StringBuilder();
            cadena = base.Mostrar();
            sb.Append(cadena);
            sb.AppendLine($"- {this.puesto} -");

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
    }
}
