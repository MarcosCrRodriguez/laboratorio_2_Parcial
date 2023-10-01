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
        private string cargo;
        private List<string> listNombre;
        private List<string> listApellido;
        private List<string> listCargo;

        public MenuUsuario(FrmLobby menuPrincipal, Usuario usuario, string cargo)
        {
            InitializeComponent();
            this.menuPrincipal = menuPrincipal;
            this.usuario = usuario;
            this.cargo = cargo;

            this.listNombre = new List<string>();
            this.listApellido = new List<string>();
            this.listCargo = new List<string>();
            this.CargarListas();
        }

        private void MenuSu_Load(object sender, EventArgs e)
        {
            if (this.cargo == "Supervisor")
            {
                this.supervisor = new Supervisor(usuario.Nombre, usuario.Apellido, this.cargo);
                this.txtNombre.Text = $" {this.supervisor.Nombre} {this.supervisor.Apellido}";
                this.gboxUsuario.Text = "Supervisor";
            }
            else
            {
                this.operario = new Operario(usuario.Nombre, usuario.Apellido, this.cargo);
                this.txtNombre.Text = $" {this.operario.Nombre} {this.operario.Apellido}";
                this.gboxUsuario.Text = "Operario";
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

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("-- Listado de operarios --\n");

            for (int i = 0; i < listNombre.Count; i++)
            {
                sb.AppendLine($"- {this.listNombre[i]} {this.listApellido[i]} -");
                sb.AppendLine($"- {this.listCargo[i]} -\n");
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
            //------------------------Operario------------------------//
            this.listNombre.Add("Juan");
            this.listApellido.Add("Carlos");
            this.listCargo.Add("Sector: Motherboard");

            this.listNombre.Add("Santiago");
            this.listApellido.Add("Cano");
            this.listCargo.Add("Sector: Motherboard");

            this.listNombre.Add("Gabriel");
            this.listApellido.Add("Abano");
            this.listCargo.Add("Sector: Video Card");

            this.listNombre.Add("Martin");
            this.listApellido.Add("Santos");
            this.listCargo.Add("Sector: Video Card");

            this.listNombre.Add("Candela");
            this.listApellido.Add("Dacorso");
            this.listCargo.Add("Sector: Cabinet");

            this.listNombre.Add("Sofia");
            this.listApellido.Add("Alfonso");
            this.listCargo.Add("Sector: Cabinet");

            this.listNombre.Add("Pablo");
            this.listApellido.Add("Carmes");
            this.listCargo.Add("Sector: Ram");

            this.listNombre.Add("Pedro");
            this.listApellido.Add("Roesse");
            this.listCargo.Add("Sector: Ram");
        }

        /// <summary>
        /// Actualizo los valores en el formulario de materias primas y productos terminados
        /// </summary>
        public void CargaDatos()
        {
            this.txtCircuitoElect.Text = Stock.CantCircuitosElectronicos.ToString();
            this.txtCircuitoElectAv.Text = Stock.CantCircuitosElectronicosAvanzados.ToString();
            this.txtUniProcesamiento.Text = Stock.CantUnidadProcesamiento.ToString();
            this.txtBarraPlastica.Text = Stock.CantBarraPlastico.ToString();
            this.txtCableVerde.Text = Stock.CantCableVerde.ToString();
            this.txtCableRojo.Text = Stock.CantCableRojo.ToString();
            this.txtBaraHierro.Text = Stock.CantBaraHierro.ToString();
            this.txtEngranajeHierro.Text = Stock.CantEngranajeHierro.ToString();
            this.txtFibtaVidrio.Text = Stock.CantFibrasVidrio.ToString();
            this.txtCondensador.Text = Stock.CantCondensador.ToString();
            this.txtVentilador.Text = Stock.CantVentilador.ToString();
            this.txtBoxCantVideoCard.Text = VideoCard.CantidadProducto.ToString();
            this.txtBoxCantMotherboard.Text = Motherboard.CantidadProducto.ToString();
            this.txtBoxCantRam.Text = Ram.CantidadProducto.ToString();
            this.txtBoxCantCabinet.Text = Cabinet.CantidadProducto.ToString();
        }
    }
}
