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
        public delegate void Mostrar(string texto, string titulo);

        private IMateriales gestorProductos;
        private IArchivos<string> manejadorArchivosTXT;
        private IArchivos<List<string>> gestorArchivos;
        private IUsuario<Operario> manejadorOperario;
        private IUsuario<Supervisor> manejadorSupervisor;
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
        private Configuracion configJson;

        private string cargo;
        private List<TextBox> listaTxtBox;
        private List<string> listaStock;
        private List<string> instanciaListFormat;

        private string path;
        private string pathTXT;
        private string pathJSON;

        public MenuUsuario(FrmLobby menuInicial, int codigoUsuario, string cargo)
        {
            InitializeComponent();
            this.gestorProductos = new ProductosDAO();
            this.manejadorArchivosTXT = new ArchivosTXT<string>();
            this.gestorArchivos = new ArchivosXML<List<string>>();
            this.manejadorOperario = new OperarioDAO<Operario>();
            this.manejadorSupervisor = new SupervisorDAO<Supervisor>();

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
            this.pathJSON = "Imagenes.json";
            this.CargarListas();
        }

        private void MenuSu_Load(object sender, EventArgs e)
        {
            if (this.cargo == "Supervisor")
            {
                this.supervisor = manejadorSupervisor.LeerPorID(this.codigoUsuario);
                this.txtNombre.Text = $" {this.supervisor.Nombre} {this.supervisor.Apellido}";
                this.gboxUsuario.Text = "Supervisor";
                this.gboxUsuario.Enabled = false;
            }
            else
            {
                this.operario = manejadorOperario.LeerPorID(this.codigoUsuario);
                this.txtNombre.Text = $" {this.operario.Nombre} {this.operario.Apellido}";
                this.gboxUsuario.Text = "Operario";
                this.gboxUsuario.Enabled = false;
                this.BtnRegistro.Visible = false;
                this.BtnReStock.Visible = false;
            }
            this.CrearDirectorio();
            this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
            Image img = Image.FromFile(this.configJson.PathImagenCircuitoAzul);
            this.BackgroundImage = img;
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
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);

            if (this.cargo == "Supervisor")
            {
                mostrarInformacion($"{this.supervisor.MostrarTodosDatos()}", "Datos pesonales");
            }
            else
            {
                mostrarInformacion($"{this.operario.MostrarTodosDatos()}", "Datos pesonales");
            }
        }

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);

            if (this.cargo == "Supervisor")
            {
                mostrarInformacion($"Cargando.. <Registro Operarios>", "Ingresando");
                this.Hide();
                FrmDataGirdView frmDtgv = new FrmDataGirdView(this);
                frmDtgv.Show();
            }
        }

        private void BtnReStock_Click(object sender, EventArgs e)
        {
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);

            mostrarInformacion("Cargando ventana de <Stock>", "Ingresando");
            this.Hide();
            FrmReStockMateriales frmReStock = new FrmReStockMateriales(this);
            frmReStock.Show();
        }

        private void BtnVideoCard_Click(object sender, EventArgs e)
        {
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);

            this.tiposProdcuto = TiposProductos.VideoCard;
            this.numeroProducto = (int)this.tiposProdcuto;
            mostrarInformacion($"Ingresando a produccion - {TiposProductos.VideoCard} -", "Ingresando");
            this.Hide();
            FrmProductoFinal frmReStock = new FrmProductoFinal(this, this.numeroProducto);
            frmReStock.Show();
        }

        private void BtnMotherboard_Click(object sender, EventArgs e)
        {
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);

            this.tiposProdcuto = TiposProductos.Motherboard;
            this.numeroProducto = (int)this.tiposProdcuto;
            mostrarInformacion($"Ingresando a produccion - {TiposProductos.Motherboard} -", "Ingresando");
            this.Hide();
            FrmProductoFinal frmReStock = new FrmProductoFinal(this, this.numeroProducto);
            frmReStock.Show();
        }

        private void BtnRam_Click(object sender, EventArgs e)
        {
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);

            this.tiposProdcuto = TiposProductos.Ram;
            this.numeroProducto = (int)this.tiposProdcuto;
            mostrarInformacion($"Ingresando a produccion - {TiposProductos.Ram} -", "Ingresando");
            this.Hide();
            FrmProductoFinal frmReStock = new FrmProductoFinal(this, this.numeroProducto);
            frmReStock.Show();
        }

        private void BtnCabinet_Click(object sender, EventArgs e)
        {
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);

            this.tiposProdcuto = TiposProductos.Cabinet;
            this.numeroProducto = (int)this.tiposProdcuto;
            mostrarInformacion($"Ingresando a produccion - {TiposProductos.Cabinet} -", "Ingresando");
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
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);
            mostrarInformacion($"{videoCard.Mostrar()}", "Datos producto");
        }

        private void LblMoth_Click(object sender, EventArgs e)
        {
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);
            mostrarInformacion($"{motherboard.Mostrar()}", "Datos producto");
        }

        private void LblRam_Click(object sender, EventArgs e)
        {
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);
            mostrarInformacion($"{ram.Mostrar()}", "Datos producto");
        }

        private void LblCabinet_Click(object sender, EventArgs e)
        {
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);
            mostrarInformacion($"{cabinet.Mostrar()}", "Datos producto");
        }

        public void CrearDirectorio()
        {
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);
            
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
                mostrarInformacion(ex.Message, "Falta de permisos");
            }
            catch (PathTooLongException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("PathTooLongException", $"{ex.StackTrace}"));
                mostrarInformacion(ex.Message, "Error con la ruta");
            }
            catch (DirectoryNotFoundException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("DirectoryNotFoundException", $"{ex.StackTrace}"));
                mostrarInformacion(ex.Message, "La ruta no se encuentra");
            }
            catch (IOException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("IOException", $"{ex.StackTrace}"));
                mostrarInformacion(ex.Message, "Error al crear el directorio");
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                mostrarInformacion(ex.Message, "Error inesperado");
            }
        }

        public void ActualizarStockXML()
        {
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);
            string pathXML = "Stock.xml";

            try
            {
                if (Directory.Exists(this.path))
                {
                    this.instanciaListFormat = Stock.InstanciarListaFormateada();
                    //EscribirXML
                    if (!(this.gestorArchivos.EscribirArchivo(this.path + pathXML, this.instanciaListFormat)))
                    {
                        mostrarInformacion("No se pudo actualizar la carpeta xml", "Carpeta XML");
                    }
                }
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                mostrarInformacion(ex.Message, "Error inesperado");
            }
        }
    
    }
}
