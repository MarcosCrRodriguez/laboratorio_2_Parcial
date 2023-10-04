using Entidades;
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

        private Usuario usuario;

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

            if (this.txtPassword.Text == "operario")
            {
                Operario operario = new Operario(this.txtNombre.Text, this.txtApellido.Text, this.cboxCargo.Text);
                MessageBox.Show($"{(string)operario}", "Iniciando sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MenuUsuario frmOperario = new MenuUsuario(this, this.usuario, this.cboxCargo.Text);
                frmOperario.Show();
            }
            else if (this.txtPassword.Text == "superusaurio")
            {
                Supervisor supervisor = new Supervisor(this.txtNombre.Text, this.txtApellido.Text, this.cboxCargo.Text);
                MessageBox.Show($"{(string)supervisor}", "Iniciando sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MenuUsuario frmSupervisor = new MenuUsuario(this, this.usuario, this.cboxCargo.Text);
                frmSupervisor.Show();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta", "Reingrese la contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnHardcode_Click(object sender, EventArgs e)
        {
            if (this.cantHardcode > 7)
            {
                this.cantHardcode = 0;
            }

            this.txtNombre.Text = listNombre[this.cantHardcode];
            this.txtApellido.Text = listApellido[this.cantHardcode];
            this.cboxCargo.Text = listCargo[this.cantHardcode];
            this.txtPassword.Text = listPassword[this.cantHardcode];
            this.cantHardcode++;
        }

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