using System.Text;

namespace Entidades
{
    public class Operario : Usuario
    {
        protected string puesto;
        protected static List<string> listNombre;
        protected static List<string> listApellido;
        protected static List<string> listSector;
        public Operario(string nombre, string apellido, string puesto) : base(nombre, apellido)
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

            listNombre.Add("Juan");
            listNombre.Add("Santiago");
            listNombre.Add("Gabriel");
            listNombre.Add("Martin");

            return listNombre;
        }

        public static List<string> HardcodearApellido()
        {
            listApellido = new List<string>();

            listApellido.Add("Carlos");
            listApellido.Add("Cano");
            listApellido.Add("Abano");
            listApellido.Add("Santos");

            return listApellido;
        }

        public static List<string> HardcodearSector()
        {
            listSector = new List<string>();

            listSector.Add("Motherboard");
            listSector.Add("Video Card");
            listSector.Add("Cabinet");
            listSector.Add("Ram");

            return listSector;
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

        public static explicit operator string(Operario s)
        {
            string cadena;

            StringBuilder sb = new StringBuilder();
            cadena = s.Mostrar();
            sb.Append(cadena);

            return sb.ToString();
        }
    }
}
