using Entidades;
using ExcepcionesPropias;
using Archivos;
using System.Text;

namespace FrmLobby
{
    public partial class FrmLobby : Form
    {
        private string path;

        public FrmLobby()
        {
            InitializeComponent();
            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
        }

        private void FrmLobby_Load(object sender, EventArgs e)
        {
            this.CrearDirectorio();
            this.cboxCargo.Items.Add("");
            this.cboxCargo.Items.Add("Operario");
            this.cboxCargo.Items.Add("Supervisor");
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNombre.Text == "" || this.txtApellido.Text == "" || this.txtCodigo.Text == "" || this.cboxCargo.Text == "" || this.txtPassword.Text == "" || this.txtDNI.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio - [ParametrosVaciosException]");
                }

                if (this.cboxCargo.Text == "Operario")
                {
                    Operario operario = new Operario(this.txtNombre.Text, this.txtApellido.Text, Operario.CasteoInt(this.txtCodigo.Text), this.cboxCargo.Text, Operario.CasteoLong(this.txtDNI.Text));
                    if (operario.VerificarExisteOperario(OperarioDAO.LeerOperarios("Operario"), operario))
                    {
                        if (operario.ValidarPasswordOperario(this.txtPassword.Text, operario))
                        {
                            operario = OperarioDAO.LeerPorID(operario.ID);
                            if (operario != null)
                            {
                                MessageBox.Show($"{operario.Nombre} {operario.Apellido} esta ingresando al menu", "Iniciando Menu Principal", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show("Contraseña o cargo INCORRECTO\nIngrese correctamente los datos", "Error de ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe ningun operario con esos datos", "No existe el Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (this.cboxCargo.Text == "Supervisor")
                {
                    Supervisor supervisor = new Supervisor(this.txtNombre.Text, this.txtApellido.Text, Supervisor.CasteoInt(this.txtCodigo.Text), this.cboxCargo.Text, Supervisor.CasteoLong(this.txtDNI.Text));
                    if (supervisor.VerificarExisteSupervisor(SupervisorDAO.LeerSupervisores("Supervisor"), supervisor))
                    {
                        if (supervisor.ValidarPasswordSupervisor(this.txtPassword.Text, supervisor))
                        {
                            supervisor = SupervisorDAO.LeerPorID(supervisor.ID);
                            if (supervisor != null)
                            {
                                MessageBox.Show($"{supervisor.Nombre} {supervisor.Apellido} esta ingresando al menu", "Iniciando Menu Principal", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show("Contraseña o cargo INCORRECTO\nIngrese correctamente los datos", "Error de ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe ningun supervisor con esos datos", "No existe el Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (EmptyParametersException ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "EmptyParametersException", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "Parametros Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "FormatException", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "Tipo de dato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidPasswordException ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "InvalidPasswordException", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "Constraseña incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ObjectNullException ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "ObjectNullException", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "Objeto Null", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DataBasesException ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "DataBasesException", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "Error con BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "Exception", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            FormularioRegistro frmRegistro = new FormularioRegistro();
            frmRegistro.ShowDialog();
        } 

        private void FrmLobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Desea cerrar el formulario", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

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
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "UnauthorizedAccessException", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "Falta de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (PathTooLongException ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "PathTooLongException", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "Error con la ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "DirectoryNotFoundException", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "La ruta no se encuentra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "IOException", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "Error al crear el directorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "Exception", $"{ex.StackTrace}");
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
    }
}