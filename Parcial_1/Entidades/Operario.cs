using System.Text;

namespace Entidades
{
    public class Operario : Usuario
    {
        protected string puesto;
        protected static List<string>? listNombre;
        protected static List<string>? listApellido;
        protected static List<string>? listSector;

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

        public static string StringBuilderList(List<string> listN, List<string> listA, List<string> listS)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("#------------------------------#");
            sb.AppendLine("#  Listado de Operarios  #");
            sb.AppendLine("#------------------------------#\n");

            if (listN != null && listA != null && listS != null)
            {
                for (int i = 0; i < listN.Count; i++)
                {
                    sb.AppendLine("#------------------------------#");
                    sb.AppendLine($"Nombre: {listN[i]}");
                    sb.AppendLine($"Apellido: {listA[i]}");
                    sb.AppendLine($"Sector -> {listS[i]}\n");
                }
            }
            
            return sb.ToString();
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
