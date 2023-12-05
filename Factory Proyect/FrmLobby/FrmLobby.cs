using Entidades;
using ExcepcionesPropias;
using Archivos;
using System.Text;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace FrmLobby
{
    public partial class FrmLobby : Form
    {
        public delegate void Mostrar(string texto, string titulo);

        private IArchivos<Configuracion> manejadorJson;
        private IArchivos<string> manejadorArchivosTXT;
        private IUsuario<Operario> manejadorOperario;
        private IUsuario<Supervisor> manejadorSupervisor;
        private Configuracion config;
        private Configuracion configJson;
        private string path;
        private string pathTXT;
        private string pathJSON;

        public FrmLobby()
        {
            InitializeComponent();
            this.manejadorJson = new ArchivosJSON<Configuracion>();
            this.manejadorArchivosTXT = new ArchivosTXT<string>();
            this.manejadorOperario = new OperarioDAO<Operario>();
            this.manejadorSupervisor = new SupervisorDAO<Supervisor>();
            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
            this.pathTXT = "Log_Excepciones.txt";
            this.pathJSON = "Imagenes.json";
        }

        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLobby_Load(object sender, EventArgs e)
        {
            this.CrearDirectorio();
            this.GenerarJson();
            this.CargaImagenes();
            this.pctBoxVisible.Visible = false;
            this.pctBoxNo.Visible = true;
            this.txtPassword.PasswordChar = '*';
            this.cboxCargo.Items.Add("");
            this.cboxCargo.Items.Add("Operario");
            this.cboxCargo.Items.Add("Supervisor");
        }

        /// <summary>
        /// Boton para ingresar al siguiente formulario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            Mostrar mostrarInformacion = new Mostrar(MostrarInformacion);

            try
            {
                if (this.txtCodigo.Text == "" || this.cboxCargo.Text == "" || this.txtPassword.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio\n-> [ParametrosVaciosException]");
                }

                if (this.cboxCargo.Text == "Supervisor")
                {
                    if (Supervisor.ValidarPasswordSupervisor(this.txtPassword.Text))
                    {
                        Supervisor supervisor = new Supervisor(Supervisor.CasteoInt(this.txtCodigo.Text), this.cboxCargo.Text);
                        if (supervisor.VerificarExisteSupervisor(SupervisorDAO<Supervisor>.LeerSupervisores("Supervisor"), supervisor))
                        {
                            supervisor = manejadorSupervisor.LeerPorID(supervisor.ID);
                            if (supervisor != null)
                            {
                                CargarLblInformacion("Cargando el menu...");
                                FrmGIF frmLoading = new FrmGIF("loading");
                                frmLoading.ShowDialog();

                                mostrarInformacion($"{supervisor.Nombre} {supervisor.Apellido} ingreso al menu", "Menu Principal");
                                this.Hide();
                                MenuUsuario frmOperario = new MenuUsuario(this, supervisor.ID, supervisor.Puesto);
                                frmOperario.Show();
                            }
                            else
                            {
                                throw new ObjectNullException("No se pudieron cargar los datos al Usuario\n-> [ObjetoNullException]");
                            }
                        }
                        else
                        {
                            throw new DataBasesException("No existe el Usuario en la DB");
                        }
                    }
                }
                else
                {
                    if (Operario.ValidarPasswordOperario(this.txtPassword.Text))
                    {
                        Operario operario = new Operario(Operario.CasteoInt(this.txtCodigo.Text), this.cboxCargo.Text);
                        if (operario.VerificarExisteOperario(OperarioDAO<Operario>.LeerOperarios("Operario"), operario))
                        {
                            operario = manejadorOperario.LeerPorID(operario.ID);
                            if (operario != null)
                            {
                                FrmGIF frmLoading = new FrmGIF("loading");
                                frmLoading.ShowDialog();

                                MessageBox.Show($"{operario.Nombre} {operario.Apellido} ingreso al menu", "Menu Principal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                MenuUsuario frmOperario = new MenuUsuario(this, operario.ID, operario.Puesto);
                                frmOperario.Show();
                            }
                            else
                            {
                                throw new ObjectNullException("No se pudieron cargar los datos al Usuario\n-> [ObjetoNullException]");
                            }
                        }
                        else
                        {
                            throw new DataBasesException("No existe el Usuario en la DB");
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
            catch (InvalidPasswordException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("InvalidPasswordException", $"{ex.StackTrace}"));
                CargarLblError(ex.Message);
            }
            catch (ObjectNullException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("ObjectNullException", $"{ex.StackTrace}"));
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
                CargarLblError(ex.Message);
            }
        }

        /// <summary>
        /// Boton para ingresar al formulario de registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            FormularioRegistro frmRegistro = new FormularioRegistro();
            frmRegistro.ShowDialog();
        }

        /// <summary>
        /// Click del apartado [x] donde se cierra o no el formulario principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Desea cerrar el formulario", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Creo un directorio 
        /// </summary>
        public void CrearDirectorio()
        {
            try
            {
                if (!Directory.Exists(this.path))
                {
                    Directory.CreateDirectory(this.path);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("UnauthorizedAccessException", $"{ex.StackTrace}"));
                CargarLblError("Falta permisos para realizar esta tarea");
            }
            catch (PathTooLongException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("PathTooLongException", $"{ex.StackTrace}"));
                CargarLblError("Error con la ruta del directorio");
                MessageBox.Show(ex.Message, "Error con la ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("DirectoryNotFoundException", $"{ex.StackTrace}"));
                CargarLblError("La ruta no se encuentra");
            }
            catch (IOException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("IOException", $"{ex.StackTrace}"));
                CargarLblError("Error al crear el directorio");
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                CargarLblError("Error inesperado");
            }
        }

        /// <summary>
        /// Limpio las casillas de texto del Formulario Lobby
        /// </summary>
        public void LimpiarDatos()
        {
            this.txtCodigo.Text = string.Empty;
            this.cboxCargo.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.lblMessage.Text = "Esperando el ingreso de datos...";
            this.lblMessage.ForeColor = Color.White;
        }

        /// <summary>
        /// Genero un archivo Json
        /// </summary>
        public void GenerarJson()
        {
            Mostrar mostrarError = new Mostrar(MostrarError);

            try
            {
                this.config = new Configuracion("C:\\Users\\rodri\\OneDrive\\Documentos\\Parciales Progra.ll\\laboratorio_2_Parcial\\Factory Proyect\\Factory.IO\\bin\\Debug\\net6.0\\Data\\medio_circuito_azul.jpg",
                "C:\\Users\\rodri\\OneDrive\\Documentos\\Parciales Progra.ll\\laboratorio_2_Parcial\\Factory Proyect\\Factory.IO\\bin\\Debug\\net6.0\\Data\\circuito_rojo.jpg",
                "C:\\Users\\rodri\\OneDrive\\Documentos\\Parciales Progra.ll\\laboratorio_2_Parcial\\Factory Proyect\\Factory.IO\\bin\\Debug\\net6.0\\Data\\circuito_azul.jpg",
                "C:\\Users\\rodri\\OneDrive\\Documentos\\Parciales Progra.ll\\laboratorio_2_Parcial\\Factory Proyect\\Factory.IO\\bin\\Debug\\net6.0\\Data\\apagado.png",
                "C:\\Users\\rodri\\OneDrive\\Documentos\\Parciales Progra.ll\\laboratorio_2_Parcial\\Factory Proyect\\Factory.IO\\bin\\Debug\\net6.0\\Data\\vista.png",
                "C:\\Users\\rodri\\OneDrive\\Documentos\\Parciales Progra.ll\\laboratorio_2_Parcial\\Factory Proyect\\Factory.IO\\bin\\Debug\\net6.0\\Data\\camion.png",
                "C:\\Users\\rodri\\OneDrive\\Documentos\\Parciales Progra.ll\\laboratorio_2_Parcial\\Factory Proyect\\Factory.IO\\bin\\Debug\\net6.0\\Data\\loading.gif",
                "C:\\Users\\rodri\\OneDrive\\Documentos\\Parciales Progra.ll\\laboratorio_2_Parcial\\Factory Proyect\\Factory.IO\\bin\\Debug\\net6.0\\Data\\envio-animacion.gif"
                );
                this.manejadorJson.EscribirArchivo(this.path + this.pathJSON, this.config);
            }
            catch (UnauthorizedAccessException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("UnauthorizedAccessException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Permisos");
            }
            catch (JsonException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("JsonException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Serializacion");
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Json");
            }
        }

        public void CargaImagenes()
        {
            this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
            Image imgBack = Image.FromFile(this.configJson.PathImagenCircuitoAzul);
            this.BackgroundImage = imgBack;
            Image imgApagado = Image.FromFile(this.configJson.PathImagenOjoApagado);
            this.pctBoxNo.Image = imgApagado;
            Image imgPrendido = Image.FromFile(this.configJson.PathImagenOjoPrendido);
            this.pctBoxVisible.Image = imgPrendido;
        }

        /// <summary>
        /// Mostramos un mensaje de Error con ciertos datos
        /// </summary>
        /// <param name="texto">Texto que tendra el mensaje</param>
        /// <param name="titulo">Titulo que tendra el mensaje</param>
        public static void MostrarError(string texto, string titulo)
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Mostramos un mensaje de Informacion con ciertos datos
        /// </summary>
        /// <param name="texto">Texto que tendra el mensaje</param>
        /// <param name="titulo">Titulo que tendra el mensaje</param>
        public static void MostrarInformacion(string texto, string titulo)
        {
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void pctBoxNo_Click(object sender, EventArgs e)
        {
            this.pctBoxNo.Visible = false;
            this.pctBoxVisible.Visible = true;
            this.txtPassword.PasswordChar = '\0';
        }

        private void pctBoxVisible_Click(object sender, EventArgs e)
        {
            this.pctBoxVisible.Visible = false;
            this.pctBoxNo.Visible = true;
            this.txtPassword.PasswordChar = '*';
        }
    }
}