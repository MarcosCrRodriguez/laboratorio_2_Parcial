using Entidades;
using ExcepcionesPropias;
using Archivos;
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
    public partial class FrmReStockMateriales : Form
    {
        private IArchivos<string> manejadorArchivosTXT;
        private IMateriales gestorMateriales;

        private MenuUsuario menuCargo;
        private List<string> listaStock;
        private List<TextBox> listaTxtBox;

        private string path;
        private string pathTXT;
        public FrmReStockMateriales(MenuUsuario menuCargo)
        {
            InitializeComponent();
            this.manejadorArchivosTXT = new ArchivosTXT<string>();
            this.gestorMateriales = new StockDAO();

            this.menuCargo = menuCargo;
            this.listaStock = new List<string>();
            this.listaTxtBox = new List<TextBox>();

            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
            this.pathTXT = "Log_Excepciones.txt";
        }

        private void FrmReStockMateriales_Load(object sender, EventArgs e)
        {
            this.listaStock = StockDAO.LeerStockPorID(1077);
            this.CargarListaNum();
            this.txtMaterialSet.Enabled = false;
        }

        private void BtnBackWindow_Click(object sender, EventArgs e)
        {
            this.menuCargo.Show();
            this.Close();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            int cantidadAgregar;
            try
            {
                if (this.txtIDSotck.Text == "" || this.txtMaterialSet.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio - [ParametrosVaciosException]");
                }
                cantidadAgregar = Stock.VerificarValorPositivo(Stock.CasteoExplicito(this.numCantAgregar.Value), Stock.CasteoExplicito(this.txtIDSotck.Text), this.txtMaterialSet.Text);
                if (cantidadAgregar != -1)
                {
                    if (this.gestorMateriales.Modificar(this.txtMaterialSet.Text, cantidadAgregar, Stock.CasteoExplicito(this.txtIDSotck.Text)))
                    {
                        MessageBox.Show($"Se ha modificado el material {this.txtMaterialSet.Text} con éxito", "Carga materiales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show($"Actualizando datos...", "Actualización de información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        menuCargo.CargaDatos();
                        this.menuCargo.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo modificar los datos del material ingresado", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo cargar los materiales cargados en el formulario", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (EmptyParametersException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("EmptyParametersException", $"{ex.StackTrace}"));
                MessageBox.Show(ex.Message, "Parametros Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("FormatException", $"{ex.StackTrace}"));
                MessageBox.Show(ex.Message, "Tipo de dato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (NegativeValueException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("NegativeValueException", $"{ex.StackTrace}"));
                MessageBox.Show(ex.Message, "El valor en Stock no puede ser menor que 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                MessageBox.Show(ex.Message, "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Lista instanciada con los valores de los controles num
        /// </summary>
        /// <returns>Retorna la lista con los datos cargados</returns>
        private void CargarListaNum()
        {
            this.listaTxtBox.Add(this.txtCircuitoElect);
            this.listaTxtBox.Add(this.txtCircuitoElectAv);
            this.listaTxtBox.Add(this.txtUnidadProcesamiento);
            this.listaTxtBox.Add(this.txtBarraPlastica);
            this.listaTxtBox.Add(this.txtCableV);
            this.listaTxtBox.Add(this.txtCableR);
            this.listaTxtBox.Add(this.txtBaraHierro);
            this.listaTxtBox.Add(this.txtEngranajeHierro);
            this.listaTxtBox.Add(this.txtFibraVidrio);
            this.listaTxtBox.Add(this.txtCondensador);
            this.listaTxtBox.Add(this.txtVentilador);

            for (int i = 0; i < this.listaTxtBox.Count; i++)
            {
                this.listaTxtBox[i].Text = this.listaStock[i];
            }

            foreach (TextBox item in this.listaTxtBox)
            {
                item.Enabled = false;
            }
        }

        private void lblCircuitoElect_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "CIRCUITO_ELECTRONICO";
        }

        private void lblCircuitoElectAv_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "CIRCUITO_ELECTRONICO_AVANZADO";
        }

        private void lblUnidadProcesamiento_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "UNIDAD_PROCESAMIENTO";
        }

        private void lblBarraPlastica_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "BARRA_PLASTICA";
        }

        private void lblCableV_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "CABLE_VERDE";
        }

        private void lblCableR_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "CABLE_ROJO";
        }

        private void lblBaraHierro_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "BARA_HIERRO";
        }

        private void lblEngranajeHierro_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "ENGRANAJE_HIERRO";
        }

        private void lblFibraVidrio_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "FIBRAS_VIDRIO";
        }

        private void lblCondensador_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "CONDENSADOR";
        }

        private void lblVentilador_Click(object sender, EventArgs e)
        {
            this.txtMaterialSet.Text = "VENTILADOR";
        }

        private void lblHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("- ID Stock - usted ingresara un password que le permitirá el acceso a modificar el Stock.\n" +
                "- Materiales a modificar - necesita interactuar con algun label de los materiales para poder seleccionar el producto que desea modificar.\n" +
                "- Cantidad a agregar - son las cantidades que desea agregar o quitar del Stock, del material que haya seleccionado.\n" +
                "ID Stock: [1077]",
                "Help Box",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }
    }
}
