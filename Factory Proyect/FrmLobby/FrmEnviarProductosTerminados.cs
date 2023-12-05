using Archivos;
using Entidades;
using ExcepcionesPropias;
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
    public partial class FrmEnviarProductosTerminados : Form
    {
        public delegate void Mostrar(string texto, string titulo);
        public delegate void ManejadorEventos(int cantidadAgregar);
        public event ManejadorEventos manejadorEventos;

        private IArchivos<string> manejadorArchivosTXT;
        private IMateriales gestorMateriales;
        private List<string> listaProductos;
        private List<TextBox> listaTxtBox;
        private Configuracion configJson;
        private MenuUsuario menuUsuario;
        private string path;
        private string pathTXT;
        private string pathJSON;
        public FrmEnviarProductosTerminados(MenuUsuario menuUsuario)
        {
            InitializeComponent();
            this.listaTxtBox = new List<TextBox>();
            this.menuUsuario = menuUsuario;
            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
            this.pathTXT = "Log_Excepciones.txt";
            this.pathJSON = "Imagenes.json";

            this.lblHelp.Click += new EventHandler(EventHandlerDinamico);
        }

        private void FrmEnviarProductosTerminados_Load(object sender, EventArgs e)
        {
            this.manejadorArchivosTXT = new ArchivosTXT<string>();
            this.gestorMateriales = new ProductosDAO();
            this.listaProductos = ProductosDAO.LeerProductosPorID(1329);
            this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
            Image img = Image.FromFile(this.configJson.PathImagenCircuitoAzul);
            this.BackgroundImage = img;

            this.CargarListaNum();
            this.txtMaterialSet.Enabled = false;

            this.manejadorEventos += EnvioCantidad;
        }

        private void CargarListaNum()
        {
            this.listaTxtBox.Add(this.txtVideoCard);
            this.listaTxtBox.Add(this.txtMotherboard);
            this.listaTxtBox.Add(this.txtRam);
            this.listaTxtBox.Add(this.txtCabinet);

            for (int i = 0; i < this.listaTxtBox.Count; i++)
            {
                this.listaTxtBox[i].Text = this.listaProductos[i];
            }

            foreach (TextBox item in this.listaTxtBox)
            {
                item.Enabled = false;
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            int cantidadEnviar;

            try
            {
                if (this.txtIDProducto.Text == "" || this.txtMaterialSet.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio\n-> [ParametrosVaciosException]");
                }
                cantidadEnviar = Producto.VerificarPosibilidadEnvio(Convert.ToInt32(this.numCantAgregar.Value), Convert.ToInt32(this.txtIDProducto.Text), this.txtMaterialSet.Text);
                if (cantidadEnviar != -1)
                {
                    if (this.manejadorEventos is not null)
                    {
                        this.manejadorEventos.Invoke(cantidadEnviar);
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

            catch (NegativeValueException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("NegativeValueException", $"{ex.StackTrace}"));
                CargarLblError(ex.Message);
                this.numCantAgregar.Value = 0;
            }
            catch (DataBasesException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("DataBasesException", $"{ex.StackTrace}"));
                CargarLblError(ex.Message);
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                CargarLblError("Error Inesperado");
            }
        }

        private void BtnBackWindow_Click(object sender, EventArgs e)
        {
            this.menuUsuario.Show();
            this.Close();
        }

        private void lblVideoCard_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "VIDEO_CARD";
        }

        private void lblMotherboard_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "MOTHERBOARD";
        }

        private void lblRam_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "RAM";
        }

        private void lblCabinet_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "CABINET";
        }

        public void EnvioCantidad(int cantidadEnviar)
        {
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);

            if (this.gestorMateriales.Modificar(this.txtMaterialSet.Text, cantidadEnviar, Stock.CasteoExplicito(this.txtIDProducto.Text)))
            {
                FrmGIF frmLoading = new FrmGIF("send");
                frmLoading.ShowDialog();

                CargarLblInformacion($"Se ha enviado {this.txtMaterialSet.Text}\ncon éxito");
                mostrarInformacion("Los Productos fueron enviados exitosamente\nActualizando datos...", "Actualización de información");

                this.menuUsuario.CargaDatos();
                this.menuUsuario.Show();
                this.Close();
            }
            else
            {
                CargarLblError("No se pudo modificar los datos \ndel material ingresado");
            }
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

        /// <summary>
        /// Muestra un mensaje por pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EventHandlerDinamico(object sender, EventArgs e)
        {
            MessageBox.Show("- ID Producto - usted ingresara un password que le permitirá el acceso a modificar los Productos mediante el envio.\n" +
                "- Materiales a enviar - necesita interactuar con algun label de los materiales para poder seleccionar el Producto que desea enviar.\n" +
                "- Cantidad a enviar - son las cantidades que desea enviar del Producto seleccionado.\n" +
                "ID Producto: [1329]",
                "Help Box",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
