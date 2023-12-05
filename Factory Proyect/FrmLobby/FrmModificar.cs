using Entidades;
using ExcepcionesPropias;
using Archivos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLobby
{
    public partial class FrmModificar : Form
    {
        public delegate void Mostrar(string texto, string titulo);
        public delegate void ManejadorEventos(string path, string texto);
        public event ManejadorEventos manejadorEventos;

        private IArchivos<string> manejadorArchivosTXT;
        private IUsuario<Operario> manejadorOperario;
        private FrmDataGirdView frmDataGirdView;
        private Configuracion configJson;
        private Operario? operario;
        private string path;
        private string pathTXT;
        private string pathDB;
        private string pathJSON;
        public FrmModificar(FrmDataGirdView frmDataGirdView)
        {
            InitializeComponent();
            this.manejadorArchivosTXT = new ArchivosTXT<string>();
            this.manejadorOperario = new OperarioDAO<Operario>();
            this.frmDataGirdView = frmDataGirdView;

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
        private void FrmModificar_Load(object sender, EventArgs e)
        {
            this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
            Image img = Image.FromFile(this.configJson.PathImagenCircuitoRojo);
            this.BackgroundImage = img;

            this.BtnModificar.Visible = false;
            this.txtBoxNombre.ReadOnly = true;
            this.txtBoxApellido.ReadOnly = true;
            this.txtBoxEdad.ReadOnly = true;
            this.txtBoxEmail.ReadOnly = true;
            this.txtBoxDireccion.ReadOnly = true;
            this.txtBoxTelefono.ReadOnly = true;
            this.monthCalendar.Enabled = false;
            this.txtBoxDireccion.ReadOnly = true;
            this.txtBoxCargo.ReadOnly = true;

            this.manejadorEventos += EscribirArchivoDB;
        }

        /// <summary>
        /// Boton que vuelve al formulario anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackToLobby_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Boton para modificar los datos de un Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Mostrar mostrarError = new Mostrar(FrmLobby.MostrarError);
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);

            try
            {
                if (this.txtBoxNombre.Text == "" || this.txtBoxApellido.Text == "" || this.txtBoxEdad.Text == "" || this.txtBoxEmail.Text == "" || this.txtBoxTelefono.Text == "" || this.txtBoxDNI.Text == "" || this.txtBoxDireccion.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio\n-> [ParametrosVaciosException]");
                }
                Operario operario = new Operario(Operario.CasteoInt(this.txtCodigoUsuario.Text), this.txtBoxCargo.Text, this.txtBoxNombre.Text, this.txtBoxApellido.Text, Operario.CasteoLong(this.txtBoxDNI.Text), this.txtBoxEmail.Text, Operario.CasteoInt(this.txtBoxEdad.Text), this.monthCalendar.SelectionStart, this.txtBoxDireccion.Text, this.txtBoxTelefono.Text);
                if (SupervisorDAO<Supervisor>.ModificarUsuario(operario))
                {
                    if (this.manejadorEventos is not null)
                    {
                        this.manejadorEventos.Invoke(this.path + this.pathDB, "Modificación de Usuario");
                    }
                    this.frmDataGirdView.RefreshData();
                    CargarLblInformacion("Se modifico el Operario correctamente");
                    this.Close();
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
        /// ID del Usuario que modificara
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIngresarID_Click(object sender, EventArgs e)
        {
            CargarLblInformacion("Código de Usuario ingresado\nEsperando la modificación de datos...");
            this.lblMessage.ForeColor = Color.White;

            try
            {
                if (this.txtCodigoUsuario.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio\n-> [ParametrosVaciosException]");
                }
                if (Operario.VerificarExisteID(OperarioDAO<Operario>.LeerOperariosDatosCompletos("Operario"), Operario.CasteoInt(this.txtCodigoUsuario.Text)))
                {
                    this.operario = manejadorOperario.LeerPorID(Operario.CasteoInt(this.txtCodigoUsuario.Text));
                    if (this.operario != null)
                    {
                        this.txtBoxNombre.Text = operario.Nombre;
                        this.txtBoxApellido.Text = operario.Apellido;
                        this.txtBoxEdad.Text = operario.Edad.ToString();
                        this.txtBoxEmail.Text = operario.Email;
                        this.txtBoxTelefono.Text = operario.Telefono;
                        this.txtBoxDNI.Text = operario.DNI.ToString();
                        this.monthCalendar.SelectionStart = operario.FechaIngreso;
                        this.txtBoxDireccion.Text = operario.Direccion;
                        this.txtBoxCargo.Text = operario.Puesto;

                        this.txtCodigoUsuario.ReadOnly = true;
                        this.txtBoxNombre.ReadOnly = false;
                        this.txtBoxApellido.ReadOnly = false;
                        this.txtBoxEdad.ReadOnly = false;
                        this.txtBoxEmail.ReadOnly = false;
                        this.txtBoxDireccion.ReadOnly = false;
                        this.txtBoxTelefono.ReadOnly = false;
                        this.monthCalendar.Enabled = true;
                        this.txtBoxDireccion.ReadOnly = false;
                        this.BtnModificar.Visible = true;
                        this.BtnIngresarID.Visible = false;
                    }
                }
                else
                {
                    CargarLblError("El Usuario no se encuentra en la DB\nO no puede dar de bajo ya que\ntiene un cargo igual o superior al suyo");
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
        /// Genero un archivo TXT
        /// </summary>
        /// <param name="path">Ruta del archivo</param>
        /// <param name="texto">Texto que cargare en el archivo</param>
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
