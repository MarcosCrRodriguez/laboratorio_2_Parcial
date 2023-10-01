using System.Net.NetworkInformation;
using System.Text;

namespace Entidades
{
    public class Supervisor : Usuario
    {
        protected string puesto;
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

        public string MostrarSupervisor()
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
            sb.AppendLine($"- {s.puesto} -");

            return sb.ToString();
        }
    }
}
