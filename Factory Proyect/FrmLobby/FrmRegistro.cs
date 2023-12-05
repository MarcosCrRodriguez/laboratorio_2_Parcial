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

namespace FrmLobby
{
    public partial class FormularioRegistro : Form
    {
        public delegate void Mostrar(string texto, string titulo);
        public delegate void ManejadorEventos(string path, string texto, int codigo);
        public event ManejadorEventos manejadorEventos;

        private IArchivos<string> manejadorArchivosTXT;
        private IUsuario<Operario> manejadorOperario;
        private IUsuario<Supervisor> manejadorSupervisor;
        private FrmDataGirdView frmDataGirdView;
        private Configuracion configJson;

        private string path;
        private string pathTXT;
        private string pathDB;
        private string pathJSON;
        public FormularioRegistro()
        {
            InitializeComponent();
            this.manejadorArchivosTXT = new ArchivosTXT<string>();
            this.manejadorOperario = new OperarioDAO<Operario>();
            this.manejadorSupervisor = new SupervisorDAO<Supervisor>();

            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
            this.pathTXT = "Log_Excepciones.txt";
            this.pathDB = "Log_DB.txt";
            this.pathJSON = "Imagenes.json";
        }

        public FormularioRegistro(FrmDataGirdView frmDataGirdView)
        {
            InitializeComponent();
            this.frmDataGirdView = frmDataGirdView;
            this.manejadorArchivosTXT = new ArchivosTXT<string>();
            this.manejadorOperario = new OperarioDAO<Operario>();
            this.manejadorSupervisor = new SupervisorDAO<Supervisor>();

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
        private void FormularioRegistro_Load(object sender, EventArgs e)
        {
            this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
            Image img = Image.FromFile(this.configJson.PathImagenCircuitoRojo);
            this.BackgroundImage = img;

            this.cboxCargo.Items.Add("Operario");
            this.cboxCargo.Items.Add("Supervisor");

            this.manejadorEventos += EscribirArchivoDB;
        }

        /// <summary>
        /// Boton donde registro a un Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Mostrar mostrarError = new Mostrar(FrmLobby.MostrarError);
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);

            try
            {
                if (this.txtBoxNombre.Text == "" || this.txtBoxApellido.Text == "" || this.txtBoxEdad.Text == "" || this.txtBoxEmail.Text == "" || this.txtBoxTelefono.Text == "" || this.txtBoxDNI.Text == "" || this.txtBoxDireccion.Text == "" || this.cboxCargo.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio\n-> [ParametrosVaciosException]");
                }
                if (this.cboxCargo.Text == "Operario")
                {
                    Operario operario = new Operario(0, this.cboxCargo.Text, this.txtBoxNombre.Text, this.txtBoxApellido.Text, Operario.CasteoLong(this.txtBoxDNI.Text), this.txtBoxEmail.Text, Operario.CasteoInt(this.txtBoxEdad.Text), this.monthCalendar.SelectionStart, this.txtBoxDireccion.Text, this.txtBoxTelefono.Text);
                    if (!(operario.VerificarExisteOperario(OperarioDAO<Operario>.LeerOperarios("Operario"), operario)))
                    {
                        if (manejadorOperario.GuardarRegistro(operario))
                        {
                            operario = manejadorOperario.LeerPorDNI(operario.DNI);
                            if (operario != null)
                            {
                                mostrarInformacion($"Código de Usuario generado >{operario.ID}<", "Código Usuario");

                                if (this.manejadorEventos is not null)
                                {
                                    this.manejadorEventos.Invoke(this.path + this.pathDB, "Generación de Usuario", operario.ID);
                                }
                                if (this.frmDataGirdView != null)
                                {
                                    this.frmDataGirdView.RefreshData();
                                }

                                CargarLblInformacion("Se registro el Operario con Exito");
                                this.Close();
                            }
                            else
                            {
                                throw new ObjectNullException("No se pudieron cargar los datos al Usuario\nNo se puede trabajar con un dato tipo null\n-> [ObjetoNullException]");
                            }
                        }
                    }
                }
                else if (this.cboxCargo.Text == "Supervisor")
                {
                    Supervisor supervisor = new Supervisor(0, this.cboxCargo.Text, this.txtBoxNombre.Text, this.txtBoxApellido.Text, Supervisor.CasteoLong(this.txtBoxDNI.Text), this.txtBoxEmail.Text, Supervisor.CasteoInt(this.txtBoxEdad.Text), this.monthCalendar.SelectionStart, this.txtBoxDireccion.Text, this.txtBoxTelefono.Text);
                    if (!(supervisor.VerificarExisteSupervisor(SupervisorDAO<Supervisor>.LeerSupervisores("Supervisor"), supervisor)))
                    {
                        if (manejadorSupervisor.GuardarRegistro(supervisor))
                        {
                            supervisor = manejadorSupervisor.LeerPorDNI(supervisor.DNI);
                            if (supervisor != null)
                            {
                                mostrarInformacion($"Código de Usuario generado >{supervisor.ID}<", "Código Usuario");

                                if (this.manejadorEventos is not null)
                                {
                                    this.manejadorEventos.Invoke(this.path + this.pathDB, "Generación de Usuario", supervisor.ID);
                                }
                                if (this.frmDataGirdView != null)
                                {
                                    this.frmDataGirdView.RefreshData();
                                }
                                CargarLblInformacion("Se registro el Supervisor con Exito");
                                this.Close();
                            }
                            else
                            {
                                throw new ObjectNullException("No se pudieron cargar los datos al Usuario\nNo se puede trabajar con un dato tipo null\n-> [ObjetoNullException]");
                            }
                        }
                    }
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
            catch (SqlExceptionDuplicateUserDB ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("SqlExceptionDuplicateUserDB", $"{ex.StackTrace}"));
                CargarLblError(ex.Message);
            }
            catch (DataBasesException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("DataBasesException", $"{ex.StackTrace}"));
                CargarLblError(ex.Message);
            }
            catch (ObjectNullException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("ObjectNullException", $"{ex.StackTrace}"));
                CargarLblError(ex.Message);
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                CargarLblError("Error Inesperado");
            }
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
        /// Boton para ingresar datos de un Usuario y asi facilitar el ingreso de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHardcodear_Click(object sender, EventArgs e)
        {
            this.txtBoxNombre.Text = "Juan";
            this.txtBoxApellido.Text = "Carlos";
            this.txtBoxEdad.Text = new Random().Next(18, 60).ToString();
            this.txtBoxEmail.Text = "juancarlos@gmail.com";
            this.txtBoxTelefono.Text = $"{new Random().Next(1000, 9999)}-{new Random().Next(1000, 9999)}";
            this.txtBoxDNI.Text = new Random().Next(15000000, 45000000).ToString();
            this.monthCalendar.SelectionStart = DateTime.Now;
            this.txtBoxDireccion.Text = $"Calle None {new Random().Next(100, 7777)}";
            this.cboxCargo.Text = "Operario";
        }

        /// <summary>
        /// Genero un archivo TXT
        /// </summary>
        /// <param name="path">Ruta del archivo</param>
        /// <param name="texto">Texto que cargare en el archivo</param>
        /// <param name="codigo">Codigo a cargar en el archivo</param>
        public void EscribirArchivoDB(string path, string texto, int codigo)
        {
            this.manejadorArchivosTXT.EscribirArchivo(path, LogFormat.CrearFormatoDB(texto, codigo.ToString()));
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
