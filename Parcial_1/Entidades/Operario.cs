using System.Text;

namespace Entidades
{
    public class Operario : Usuario
    {
        protected string puesto;
        public Operario(string nombre, string apellido, string puesto)
            :base(nombre, apellido)
        {
            this.puesto = puesto;
        }

        public string Puesto
        {
            get { return this.puesto; }
            set { this.puesto = value; }
        }

        public string MostrarOperario()
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
            sb.AppendLine($"- {s.puesto} -");

            return sb.ToString();
        }
    }
}
