using System.Text;

namespace Entidades
{
    public class Usuario
    {
        protected int id;
        protected string puesto; 

        public Usuario()
        {

        }
        public Usuario(int id, string puesto)
        {
            this.id = id;
            this.puesto = puesto;
        }

        #region Propiedades

        /// <summary>
        /// Retorna el valor del ID
        /// </summary>
        public int ID
        {
            get { return this.id; }
        }

        /// <summary>
        /// Retorna la cadena de Puesto
        /// </summary>
        public string Puesto
        {
            get { return this.puesto; }
        }
        #endregion

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cídog Usuario: {this.id}");
            sb.AppendLine($"Cargo: {this.puesto}");

            return sb.ToString();
        }
    }
}