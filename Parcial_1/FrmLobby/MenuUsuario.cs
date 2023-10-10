using Entidades;
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
    public partial class MenuUsuario : Form
    {
        private TiposProductos tiposProdcuto;
        private int numeroProducto;

        private FrmLobby menuPrincipal;
        private Usuario usuario;
        private Supervisor supervisor;
        private Operario operario;
        private VideoCard videoCard;
        private Motherboard motherboard;
        private Ram ram;
        private Cabinet cabinet;

        private string cargo;
        private List<string> listNombre;
        private List<string> listApellido;
        private List<string> listSector;
        private List<TextBox> listaTxtBox;
        private List<int> listaStock;

        public MenuUsuario(FrmLobby menuPrincipal, Usuario usuario, string cargo)
        {
            InitializeComponent();
            this.menuPrincipal = menuPrincipal;
            this.usuario = usuario;
            this.supervisor = new Supervisor();
            this.operario = new Operario();
            this.videoCard = new VideoCard();
            this.motherboard = new Motherboard();
            this.ram = new Ram();
            this.cabinet = new Cabinet();

            this.cargo = cargo;
            this.listNombre = new List<string>();
            this.listApellido = new List<string>();
            this.listSector = new List<string>();
            this.listaTxtBox = new List<TextBox>();
            this.listaStock = new List<int>();
            this.CargarListas();
        }

        private void MenuSu_Load(object sender, EventArgs e)
        {
            if (this.cargo == "Supervisor")
            {
                this.supervisor = new Supervisor(usuario.Nombre, usuario.Apellido, this.cargo);
                this.txtNombre.Text = $" {this.supervisor.Nombre} {this.supervisor.Apellido}";
                this.gboxUsuario.Text = "Supervisor";
                this.gboxUsuario.Enabled = false;
            }
            else
            {
                this.operario = new Operario(usuario.Nombre, usuario.Apellido, this.cargo);
                this.txtNombre.Text = $" {this.operario.Nombre} {this.operario.Apellido}";
                this.gboxUsuario.Text = "Operario";
                this.gboxUsuario.Enabled = false;
                this.BtnRegistro.Visible = false;
                this.BtnReStock.Visible = false;
            }

            this.CargaDatos();
        }

        private void BtnBackSu_Click_1(object sender, EventArgs e)
        {
            this.menuPrincipal.Show();
            this.Close();
        }

        private void BtnConfig_Click_1(object sender, EventArgs e)
        {
            if (this.cargo == "Supervisor")
            {
                MessageBox.Show($"{(string)supervisor}", "Configuracion datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"{(string)operario}", "Configuracion datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // intentar armar un DataGirdView (investigar su uso)
        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("-- Listado de operarios --\n");

            for (int i = 0; i < listNombre.Count; i++)
            {
                sb.AppendLine("----           ----           ----");
                sb.AppendLine($"Nombre: {this.listNombre[i]}");
                sb.AppendLine($"Apellido: {this.listApellido[i]}\n");
                sb.AppendLine($"Sector: - {this.listSector[i]} -");
            }

            MessageBox.Show($"{sb}", "Registro de Operarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnReStock_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Cargando ventana Re Stock", "Ingresando", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            FrmReStockMateriales frmReStock = new FrmReStockMateriales(this);
            frmReStock.Show();
        }

        private void BtnVideoCard_Click(object sender, EventArgs e)
        {
            this.tiposProdcuto = TiposProductos.VideoCard;
            this.numeroProducto = (int)this.tiposProdcuto;
            MessageBox.Show($"Ingresando a produccion - Video Card -", "Ingresando", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            FrmProductoFinal frmReStock = new FrmProductoFinal(this, this.numeroProducto);
            frmReStock.Show();
        }

        private void BtnMotherboard_Click(object sender, EventArgs e)
        {
            this.tiposProdcuto = TiposProductos.Motherboard;
            this.numeroProducto = (int)this.tiposProdcuto;
            MessageBox.Show($"Ingresando a produccion - Motherboard -", "Ingresando", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            FrmProductoFinal frmReStock = new FrmProductoFinal(this, this.numeroProducto);
            frmReStock.Show();
        }

        private void BtnRam_Click(object sender, EventArgs e)
        {
            this.tiposProdcuto = TiposProductos.Ram;
            this.numeroProducto = (int)this.tiposProdcuto;
            MessageBox.Show($"Ingresando a produccion - Ram -", "Ingresando", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            FrmProductoFinal frmReStock = new FrmProductoFinal(this, this.numeroProducto);
            frmReStock.Show();
        }

        private void BtnCabinet_Click(object sender, EventArgs e)
        {
            this.tiposProdcuto = TiposProductos.Cabinet;
            this.numeroProducto = (int)this.tiposProdcuto;
            MessageBox.Show($"Ingresando a produccion - Cabinet -", "Ingresando", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            FrmProductoFinal frmReStock = new FrmProductoFinal(this, this.numeroProducto);
            frmReStock.Show();
        }

        /// <summary>
        /// Ingreso unicamente en el constructor, me hardcodea una lista con datos,
        /// que esos datos son los usuarios registrados 
        /// </summary>
        private void CargarListas()
        {
            this.listaTxtBox.Add(this.txtCircuitoElect);
            this.listaTxtBox.Add(this.txtCircuitoElectAv);
            this.listaTxtBox.Add(this.txtUniProcesamiento);
            this.listaTxtBox.Add(this.txtBarraPlastica);
            this.listaTxtBox.Add(this.txtCableVerde);
            this.listaTxtBox.Add(this.txtCableRojo);
            this.listaTxtBox.Add(this.txtBaraHierro);
            this.listaTxtBox.Add(this.txtEngranajeHierro);
            this.listaTxtBox.Add(this.txtFibtaVidrio);
            this.listaTxtBox.Add(this.txtCondensador);
            this.listaTxtBox.Add(this.txtVentilador);

            //------------------------Operario------------------------//
            this.listNombre = Operario.HardcodearNombre();
            this.listApellido = Operario.HardcodearApellido();
            this.listSector = Operario.HardcodearSector();
        }

        /// <summary>
        /// Actualizo los valores en el formulario de materias primas y productos terminados
        /// </summary>
        public void CargaDatos()
        {
            this.listaStock = Stock.InstanciarListaStock();

            for (int i = 0; i < this.listaTxtBox.Count; i++)
            {
                this.listaTxtBox[i].Text = this.listaStock[i].ToString();
            }

            foreach (TextBox item in this.listaTxtBox)
            {
                item.Enabled = false;
            }

            this.txtBoxCantVideoCard.Text = VideoCard.CantidadProducto.ToString();
            this.txtBoxCantMotherboard.Text = Motherboard.CantidadProducto.ToString();
            this.txtBoxCantRam.Text = Ram.CantidadProducto.ToString();
            this.txtBoxCantCabinet.Text = Cabinet.CantidadProducto.ToString();

            this.txtBoxCantVideoCard.Enabled = false;
            this.txtBoxCantMotherboard.Enabled = false;
            this.txtBoxCantRam.Enabled = false;
            this.txtBoxCantCabinet.Enabled = false;
        }

        private void LblVideo_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{videoCard.Mostrar()}", "Datos producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblMoth_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{motherboard.Mostrar()}", "Datos producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblRam_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{ram.Mostrar()}", "Datos producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LblCabinet_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{cabinet.Mostrar()}", "Datos producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
