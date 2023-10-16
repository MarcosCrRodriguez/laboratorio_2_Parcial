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

        #region Propiedades
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
        #endregion

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Apellido: {this.apellido}");

            return sb.ToString();
        }
    }
}