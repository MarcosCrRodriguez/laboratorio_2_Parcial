using Entidades;
using ExcepcionesPropias;
using Archivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace FrmLobby
{
    public partial class FrmEliminar : Form
    {
        public delegate void Mostrar(string texto, string titulo);
        public delegate void ManejadorEventos(string path, string texto);
        public event ManejadorEventos manejadorEventos;

        private IArchivos<string> manejadorArchivosTXT;
        private Configuracion configJson;

        private string path;
        private string pathTXT;
        private string pathDB;
        private string pathJSON;
        public FrmEliminar()
        {
            InitializeComponent();
            this.manejadorArchivosTXT = new ArchivosTXT<string>();

            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
            this.pathTXT = "Log_Excepciones.txt";
            this.pathDB = "Log_DB.txt";
            this.pathJSON = "Imagenes.json";
        }

        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEliminar_Load(object sender, EventArgs e)
        {
            this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
            Image img = Image.FromFile(this.configJson.PathImagenCircuitoRojo);
            this.BackgroundImage = img;
            this.lblMessage.Text = "Esperando el ingreso de datos...";

            this.manejadorEventos += EscribirArchivoDB;
        }

        /// <summary>
        /// Boton donde da la baja del Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCodigoUsuario.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio\n-> [ParametrosVaciosException]");
                }
                if (Operario.VerificarExisteID(OperarioDAO<Operario>.LeerOperarios("Operario"), Convert.ToInt32(this.txtCodigoUsuario.Text)))
                {
                    DialogResult result = MessageBox.Show("¿Esta seguro que desea Dar De Baja a este Usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        EliminarUsuario("Operario", Convert.ToInt32(this.txtCodigoUsuario.Text));
                    }
                    else
                    {
                        CargarLblError("El Usuario no se dio de baja");
                    }
                }
                else
                {
                    CargarLblError("El Usuario no se encuentra en la base de datos\nO no puede dar de bajo ya que\ntiene un cargo igual o superior al suyo");
                }
            }
            catch (EmptyParametersException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("EmptyParametersException", $"{ex.StackTrace}"));
                CargarLblError(ex.Message);
            }
            catch (FormatException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("FormatException", $"{ex.StackTrace}"));
                CargarLblError(ex.Message);
            }
            catch (DataBasesException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("DataBasesException", $"{ex.StackTrace}"));
                CargarLblError(ex.Message);
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                CargarLblError("Error inesperado");
            }
        }

        /// <summary>
        /// Boton que vuelve al formulario anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo donde se da la baja del Usuario
        /// </summary>
        /// <param name="cargo">Cargo del Usuario</param>
        /// <param name="ID">ID del Usuario</param>
        public void EliminarUsuario(string cargo, int ID)
        {
            if (SupervisorDAO<Supervisor>.Eliminar(cargo, ID))
            {
                if (this.manejadorEventos is not null)
                {
                    this.manejadorEventos.Invoke(this.path + this.pathDB, "Baja de Usuario");
                }
                CargarLblInformacion("El Usuario se ha dado de baja correctamente");
                this.Close();
            }
            else
            {
                CargarLblError("El Usuario no se encuentra en la DB\nO no puede dar de bajo ya que\ntiene un cargo igual o superior al suyo");
            }
        }

        /// <summary>
        /// Genero un archivo TXT
        /// </summary>
        /// <param name="path">Ruta del archivo</param>
        /// <param name="texto">Texto que se guardara en el archivo</param>
        public void EscribirArchivoDB(string path, string texto)
        {
            this.manejadorArchivosTXT.EscribirArchivo(path, LogFormat.CrearFormatoDB(texto, $"{this.txtCodigoUsuario.Text}"));
        }

        public void CargarLblInformacion(string texto)
        {
            this.lblMessage.ForeColor = Color.Green;
            this.lblMessage.Text = texto;
        }

        public void CargarLblError(string texto)
        {
            this.lblMessage.ForeColor = Color.Red;
            this.lblMessage.Text = texto;
        }
    }
}
