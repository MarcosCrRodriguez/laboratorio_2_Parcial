using System.Text;

namespace Entidades
{
    public class Usuario
    {
        protected string nombre;
        protected string apellido;

        public Usuario(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

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

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.nombre} {this.apellido} -");

            return sb.ToString();
        }
    }
}