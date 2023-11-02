using Entidades;
using ExcepcionesPropias;
using System.Text;

namespace FrmLobby
{
    public partial class FrmLobby : Form
    {
        private int cantHardcode;
        private const int constanteHarcodeos = 7;
        private List<string> listNombre;
        private List<string> listApellido;
        private List<string> listCargo;
        private List<string> listPassword;
        private Usuario? usuario;

        public FrmLobby()
        {
            InitializeComponent();
            this.listNombre = new List<string>();
            this.listApellido = new List<string>();
            this.listCargo = new List<string>();
            this.listPassword = new List<string>();
        }
        private void FrmLobby_Load(object sender, EventArgs e)
        {
            this.cantHardcode = 0;
            this.CargarListas();

            cboxCargo.Items.Add("Operario");
            cboxCargo.Items.Add("Supervisor");
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            this.usuario = new Usuario(this.txtNombre.Text, this.txtApellido.Text);

            try
            {
                if (this.txtNombre.Text == "" || this.txtApellido.Text == "" || this.txtCodigo.Text == "" || this.cboxCargo.Text == "" || this.txtPassword.Text == "" || this.txtDNI.Text == "")
                {
                    throw new ParametrosVaciosException("Alguno de los campos esta vacio");
                }

                if (this.cboxCargo.Text == "Operario")
                {
                    Operario operario = new Operario(this.txtNombre.Text, this.txtApellido.Text, Operario.CasteoInt(this.txtCodigo.Text), this.cboxCargo.Text, Operario.CasteoLong(this.txtDNI.Text));
                    if (operario.VerificarExisteOperario(OperarioDAO.LeerOperarios(), operario))
                    {
                        if (operario.ValidarPassword(this.txtPassword.Text, operario))
                        {
                            operario = OperarioDAO.LeerPorID(operario.ID);
                            if (operario != null)
                            {
                                MessageBox.Show($"{(string)operario}", "Iniciando Menu Principal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                MenuUsuario frmOperario = new MenuUsuario(this, operario, this.cboxCargo.Text);
                                frmOperario.Show();
                            }
                            else
                            {
                                throw new ObjetoNullException("Alguno de los campos esta vacio");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Contraseña o cargo INCORRECTO\nIngrese correctamente los datos", "Error de ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No contengo ningun operario con esos datos\nRegistrar al operario", "No existe el Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (this.cboxCargo.Text == "Supervisor")
                {
                    Supervisor supervisor = new Supervisor(this.txtNombre.Text, this.txtApellido.Text, Supervisor.CasteoInt(this.txtCodigo.Text), this.cboxCargo.Text, Supervisor.CasteoLong(this.txtDNI.Text));
                    if (supervisor.VerificarExisteSupervisor(SupervisorDAO.LeerSupervisores(), supervisor))
                    {
                        if (supervisor.ValidarPassword(this.txtPassword.Text, supervisor))
                        {
                            if (supervisor != null)
                            {
                                supervisor = SupervisorDAO.LeerPorID(supervisor.ID);
                                MessageBox.Show($"{(string)supervisor}", "Iniciando Menu Principal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                MenuUsuario frmSupervisor = new MenuUsuario(this, supervisor, this.cboxCargo.Text);
                                frmSupervisor.Show();
                            }
                            else
                            {
                                throw new ObjetoNullException("Alguno de los campos esta vacio");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Contraseña o cargo INCORRECTO\nIngrese correctamente los datos", "Error de ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No contengo ningun supervisor con esos datos\nRegistrar al supervisor", "No existe el Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (ParametrosVaciosException ex)
            {
                MessageBox.Show(ex.Message, "Parametros Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ObjetoNullException ex)
            {
                MessageBox.Show(ex.Message, "Objeto Null", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Tipo de dato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormularioRegistro frmSupervisor = new FormularioRegistro(this);
            frmSupervisor.Show();
        }

        //private void BtnHardcode_Click(object sender, EventArgs e)
        //{
        //    if (this.cantHardcode > 7)
        //    {
        //        this.cantHardcode = 0;
        //    }

        //    this.txtNombre.Text = listNombre[this.cantHardcode];
        //    this.txtApellido.Text = listApellido[this.cantHardcode];
        //    this.cboxCargo.Text = listCargo[this.cantHardcode];
        //    this.txtPassword.Text = listPassword[this.cantHardcode];
        //    this.cantHardcode++;
        //}

        private void FrmLobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Desea cerrar el formulario", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Ingreso unicamente cuando cargo el formulario, me hardcodea una lista con datos, que 
        /// esos datos son los uruarios, operarios/supervisores para facilitar el ingreso al sistema
        /// </summary>
        private void CargarListas()
        {
            //------------------------Usuarios Harcodeados------------------------//
            this.listNombre = Supervisor.HardcodearNombre();
            this.listApellido = Supervisor.HardcodearApellido();
            this.listCargo = Supervisor.HardcodearCargo();
            this.listPassword = Supervisor.HardcodearPassword();
        }

    }
}