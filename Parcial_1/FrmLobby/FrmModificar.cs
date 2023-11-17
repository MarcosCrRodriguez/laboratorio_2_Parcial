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

        private IArchivos<string> manejadorArchivosTXT;
        private IUsuario<Operario> manejadorOperario;
        private IUsuario<Supervisor> manejadorSupervisor;

        private Configuracion configJson;
        private Operario? operario;
        private string path;
        private string pathTXT;
        private string pathJSON;
        public FrmModificar()
        {
            InitializeComponent();
            this.manejadorArchivosTXT = new ArchivosTXT<string>();
            this.manejadorOperario = new OperarioDAO<Operario>();
            this.manejadorSupervisor = new SupervisorDAO<Supervisor>();

            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
            this.pathTXT = "Log_Excepciones.txt";
            this.pathJSON = "Imagenes.json";
        }

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
        }

        private void BtnBackToLobby_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Mostrar mostrarError = new Mostrar(FrmLobby.MostrarError);
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);

            try
            {
                if (this.txtBoxNombre.Text == "" || this.txtBoxApellido.Text == "" || this.txtBoxEdad.Text == "" || this.txtBoxEmail.Text == "" || this.txtBoxTelefono.Text == "" || this.txtBoxDNI.Text == "" || this.txtBoxDireccion.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio - [ParametrosVaciosException]");
                }
                Operario operario = new Operario(this.txtBoxNombre.Text, this.txtBoxApellido.Text, Operario.CasteoInt(this.txtCodigoUsuario.Text), this.txtBoxCargo.Text, Operario.CasteoLong(this.txtBoxDNI.Text), this.txtBoxEmail.Text, Operario.CasteoInt(this.txtBoxEdad.Text), this.monthCalendar.SelectionStart, this.txtBoxDireccion.Text, this.txtBoxTelefono.Text);
                if (SupervisorDAO<Supervisor>.ModificarUsuario(operario))
                {
                    mostrarInformacion("Se modifico el Operario correctamente", "Modificación de datos");
                    this.Close();
                }
            }
            catch (EmptyParametersException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("EmptyParametersException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Parametros Vacios");
            }
            catch (FormatException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("FormatException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Tipo de dato Incorrecto");
            }
            catch (DataBasesException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("DataBasesException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Error con DB");
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Error inesperado");
            }
        }

        private void BtnIngresarID_Click(object sender, EventArgs e)
        {
            Mostrar mostrarError = new Mostrar(FrmLobby.MostrarError);

            try
            {
                if (this.txtCodigoUsuario.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio - [ParametrosVaciosException]");
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
                    mostrarError("El Usuario no se encuentra en la base de datos\nO no puede dar de bajo ya que tiene un cargo igual o superior al suyo", "Usuario no encontrado");
                }
            }
            catch (EmptyParametersException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("EmptyParametersException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Parametros Vacios");
            }
            catch (FormatException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("FormatException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Tipo de dato Incorrecto");
            }
            catch (DataBasesException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("DataBasesException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Error con DB");
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Error inesperado");
            }
        }
    }
}
