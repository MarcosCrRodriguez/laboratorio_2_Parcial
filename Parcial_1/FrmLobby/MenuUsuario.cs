using Entidades;
using ExcepcionesPropias;
using Archivos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FrmLobby
{
    public partial class MenuUsuario : Form
    {
        private IMateriales gestorProductos;
        private IArchivos<string> manejadorArchivosTXT;
        private IArchivos<List<string>> gestorArchivos;
        private TiposProductos tiposProdcuto;
        private int numeroProducto;

        private FrmLobby menuInicial;
        private int codigoUsuario;
        private Supervisor supervisor;
        private Operario operario;
        private VideoCard videoCard;
        private Motherboard motherboard;
        private Ram ram;
        private Cabinet cabinet;

        private string cargo;
        private List<TextBox> listaTxtBox;
        private List<string> listaStock;
        private List<string> instanciaListFormat;

        private string path;
        private string pathTXT;

        public MenuUsuario(FrmLobby menuInicial, int codigoUsuario, string cargo)
        {
            InitializeComponent();
            this.gestorProductos = new ProductosDAO();
            this.manejadorArchivosTXT = new ArchivosTXT<string>();
            this.gestorArchivos = new ArchivosXML<List<string>>();
            this.menuInicial = menuInicial;
            this.codigoUsuario = codigoUsuario;
            this.videoCard = new VideoCard();
            this.motherboard = new Motherboard();
            this.ram = new Ram();
            this.cabinet = new Cabinet();

            this.cargo = cargo;
            this.listaTxtBox = new List<TextBox>();
            this.listaStock = new List<string>();
            this.instanciaListFormat = new List<string>();

            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
            this.pathTXT = "Log_Excepciones.txt";
            this.CargarListas();
        }

        private void MenuSu_Load(object sender, EventArgs e)
        {
            if (this.cargo == "Supervisor")
            {
                this.supervisor = SupervisorDAO.LeerPorID(this.codigoUsuario);
                this.txtNombre.Text = $" {this.supervisor.Nombre} {this.supervisor.Apellido}";
                this.gboxUsuario.Text = "Supervisor";
                this.gboxUsuario.Enabled = false;
            }
            else
            {
                this.operario = OperarioDAO.LeerPorID(this.codigoUsuario);
                this.txtNombre.Text = $" {this.operario.Nombre} {this.operario.Apellido}";
                this.gboxUsuario.Text = "Operario";
                this.gboxUsuario.Enabled = false;
                this.BtnRegistro.Visible = false;
                this.BtnReStock.Visible = false;
            }
            this.CrearDirectorio();
            this.CargaDatos();
        }

        private void BtnBackSu_Click_1(object sender, EventArgs e)
        {
            this.menuInicial.LimpiarDatos();
            this.menuInicial.Show();
            this.Close();
        }

        private void BtnConfig_Click_1(object sender, EventArgs e)
        {
            if (this.cargo == "Supervisor")
            {
                MessageBox.Show($"{this.supervisor.MostrarTodosDatos()}", "Configuracion datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"{this.operario.MostrarTodosDatos()}", "Configuracion datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            if (this.cargo == "Supervisor")
            {
                MessageBox.Show($"Cargando regsitro <Registro Operarios>", "Ingresando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FrmDataGirdView frmDtgv = new FrmDataGirdView(this);
                frmDtgv.Show();
            }
        }

        private void BtnReStock_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Cargando ventana de <Stock>", "Ingresando", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Ingreso unicamente en el constructor, me "crea" una lista de TextBox
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
        }

        /// <summary>
        /// Actualizo los valores en el formulario de materias primas y productos terminados
        /// </summary>
        public void CargaDatos()
        {
            this.listaStock = StockDAO.LeerStockPorID(1077);

            for (int i = 0; i < this.listaTxtBox.Count; i++)
            {
                this.listaTxtBox[i].Text = this.listaStock[i];
            }

            foreach (TextBox item in this.listaTxtBox)
            {
                item.Enabled = false;
            }

            this.txtBoxCantVideoCard.Text = this.gestorProductos.LeerPorMaterial(1329, "VIDEO_CARD").ToString();
            this.txtBoxCantMotherboard.Text = this.gestorProductos.LeerPorMaterial(1329, "MOTHERBOARD").ToString();
            this.txtBoxCantRam.Text = this.gestorProductos.LeerPorMaterial(1329, "RAM").ToString();
            this.txtBoxCantCabinet.Text = this.gestorProductos.LeerPorMaterial(1329, "CABINET").ToString();

            this.txtBoxCantVideoCard.Enabled = false;
            this.txtBoxCantMotherboard.Enabled = false;
            this.txtBoxCantRam.Enabled = false;
            this.txtBoxCantCabinet.Enabled = false;

            this.ActualizarStockXML();
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

        public void ActualizarStockXML()
        {
            string pathXML = "Stock.xml";

            try
            {
                if (Directory.Exists(this.path))
                {
                    this.instanciaListFormat = Stock.InstanciarListaFormateada();
                    //EscribirXML
                    if (!(this.gestorArchivos.EscribirArchivo(this.path + pathXML, this.instanciaListFormat)))
                    {
                        MessageBox.Show("No se pudo actualizar la carpeta xml", "Carpeta XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                MessageBox.Show(ex.Message);
            }
        }
    }
}
