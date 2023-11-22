using Entidades;
using ExcepcionesPropias;
using Archivos;
using System.Text;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.Json;

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
            this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
            Image img = Image.FromFile(this.configJson.PathImagenCircuitoAzul);
            this.BackgroundImage = img;
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
            Mostrar mostrarError = new Mostrar(MostrarError);

            try
            {
                if (this.txtNombre.Text == "" || this.txtApellido.Text == "" || this.txtCodigo.Text == "" || this.cboxCargo.Text == "" || this.txtPassword.Text == "" || this.txtDNI.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio - [ParametrosVaciosException]");
                }

                if (this.cboxCargo.Text == "Operario")
                {
                    Operario operario = new Operario(this.txtNombre.Text, this.txtApellido.Text, Operario.CasteoInt(this.txtCodigo.Text), this.cboxCargo.Text, Operario.CasteoLong(this.txtDNI.Text));
                    if (operario.VerificarExisteOperario(OperarioDAO<Operario>.LeerOperarios("Operario"), operario))
                    {
                        if (operario.ValidarPasswordOperario(this.txtPassword.Text, operario))
                        {
                            operario = manejadorOperario.LeerPorID(operario.ID);
                            if (operario != null)
                            {
                                FrmLoading frmLoading = new FrmLoading();
                                frmLoading.ShowDialog();

                                MessageBox.Show($"{operario.Nombre} {operario.Apellido} ingreso al menu", "Menu Principal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                MenuUsuario frmOperario = new MenuUsuario(this, operario.ID, operario.Puesto);
                                frmOperario.Show();
                            }
                            else
                            {
                                throw new ObjectNullException("No se pudieron cargar los datos al Usuario, no se puede trabajar con un dato tipo null - [ObjetoNullException]");
                            }
                        }
                        else
                        {
                            mostrarError("Contraseña o cargo INCORRECTO\nIngrese correctamente los datos", "Error de ingreso de datos");
                        }
                    }
                    else
                    {
                        mostrarError("No existe ningun operario con esos datos", "No existe el Usuario");
                    }
                }
                else if (this.cboxCargo.Text == "Supervisor")
                {
                    Supervisor supervisor = new Supervisor(this.txtNombre.Text, this.txtApellido.Text, Supervisor.CasteoInt(this.txtCodigo.Text), this.cboxCargo.Text, Supervisor.CasteoLong(this.txtDNI.Text));
                    if (supervisor.VerificarExisteSupervisor(SupervisorDAO<Supervisor>.LeerSupervisores("Supervisor"), supervisor))
                    {
                        if (supervisor.ValidarPasswordSupervisor(this.txtPassword.Text, supervisor))
                        {
                            supervisor = manejadorSupervisor.LeerPorID(supervisor.ID);
                            if (supervisor != null)
                            {
                                FrmLoading frmLoading = new FrmLoading();
                                frmLoading.ShowDialog();

                                MessageBox.Show($"{supervisor.Nombre} {supervisor.Apellido} ingreso al menu", "Menu Principal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                MenuUsuario frmSupervisor = new MenuUsuario(this, supervisor.ID, supervisor.Puesto);
                                frmSupervisor.Show();
                            }
                            else
                            {
                                throw new ObjectNullException("No se pudieron cargar los datos al Usuario, no se puede trabajar con un dato tipo null - [ObjetoNullException]");
                            }
                        }
                        else
                        {
                            mostrarError("Contraseña o cargo INCORRECTO\nIngrese correctamente los datos", "Error de ingreso de datos");
                        }
                    }
                    else
                    {
                        mostrarError("No existe ningun supervisor con esos datos", "No existe el Usuario");
                    }
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
            catch (InvalidPasswordException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("InvalidPasswordException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Constraseña incorrecta");
            }
            catch (ObjectNullException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("ObjectNullException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Objeto Null");
            }
            catch (DataBasesException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("DataBasesException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Error con BD");
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Error Inesperado");
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
                MessageBox.Show(ex.Message, "Falta de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PathTooLongException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("PathTooLongException", $"{ex.StackTrace}"));
                MessageBox.Show(ex.Message, "Error con la ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("DirectoryNotFoundException", $"{ex.StackTrace}"));
                MessageBox.Show(ex.Message, "La ruta no se encuentra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("IOException", $"{ex.StackTrace}"));
                MessageBox.Show(ex.Message, "Error al crear el directorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                MessageBox.Show(ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpio las casillas de texto del Formulario Lobby
        /// </summary>
        public void LimpiarDatos()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtCodigo.Text = string.Empty;
            this.cboxCargo.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtDNI.Text = string.Empty;
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
                "C:\\Users\\rodri\\OneDrive\\Documentos\\Parciales Progra.ll\\laboratorio_2_Parcial\\Factory Proyect\\Factory.IO\\bin\\Debug\\net6.0\\Data\\loading.gif"
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

    }
}