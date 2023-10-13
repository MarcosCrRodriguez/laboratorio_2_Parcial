using System.Text;

namespace Entidades
{
    public class Operario : Usuario
    {
        protected string puesto;
        protected static List<string>? listNombre;
        protected static List<string>? listApellido;
        protected static List<string>? listSector;

        public Operario(string nombre, string apellido) : base(nombre, apellido)
        {
            this.puesto = "Operario";
        }
        public Operario(string nombre, string apellido, string puesto) : base(nombre, apellido)
        {
            this.puesto = puesto;
        }

        #region Propiedades
        public string Puesto
        {
            get { return this.puesto; }
            set { this.puesto = value; }
        }
        #endregion

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
            cadena = base.Mostrar();
            sb.AppendLine($"- {this.puesto} -\n");
            sb.Append(cadena);

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
