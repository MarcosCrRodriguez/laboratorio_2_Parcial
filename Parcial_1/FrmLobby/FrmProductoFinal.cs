using Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLobby
{
    public partial class FrmProductoFinal : Form
    {
        private MenuUsuario frmUsuario;
        private VideoCard videoCard;
        private Motherboard motherboard;
        private Ram ram;
        private Cabinet cabinet;
        private int producto;

        private Dictionary<string, int> dictProducto;
        private List<TextBox> listaTxtBox;
        private List<int> listaValores;

        public FrmProductoFinal(MenuUsuario frmUsuario, int producto)
        {
            InitializeComponent();
            this.frmUsuario = frmUsuario;
            this.videoCard = new VideoCard("Factory.IO", "16-56433112-2", 78864278);
            this.motherboard = new Motherboard("Factory.IO", "27-36777903-5", 44131364);
            this.ram = new Ram("Factory.IO", "28-42227079-9", 45667578);
            this.cabinet = new Cabinet("Factory.IO", "36-37984545-8", 25788642);
            this.listaValores = new List<int>();
            this.producto = producto;
        }

        private void FrmVideoCard_Load(object sender, EventArgs e)
        {
            if (this.producto == 0)
            {
                this.groupBox1.Text = "Produccion Video Cards";
                this.label1.Text = "Cantidad de Video Cards";
                this.label3.Text = "U Procesamiento";
                this.label4.Text = "Cable Verde";
                this.label5.Text = "Barra Plástico";
                this.label6.Text = "Bara Hierro";
                this.label7.Text = "Engranaje Hierro";
                this.label8.Text = "Fibra Vidrio";
                this.label9.Text = "Condensador";
                this.label10.Text = "Ventilador";

                this.listaValores = videoCard.CrearLista((int)numFabricar.Value);
            }
            else if (this.producto == 1)
            {
                this.groupBox1.Text = "Produccion Motherboards";
                this.label1.Text = "Cantidad de Motherboards";
                this.label3.Text = "Circuito Elect Av";
                this.label4.Text = "Cable Rojo";
                this.label5.Text = "Barra Plástico";
                this.label6.Text = "Bara Hierro";
                this.label7.Text = "Engranaje Hierro";
                this.label8.Text = "Fibra Vidrio";
                this.label9.Text = "Condensador";
                this.label10.Text = "Ventilador";

                this.listaValores = motherboard.CrearLista((int)numFabricar.Value);
            }
            else if (this.producto == 2)
            {
                this.groupBox1.Text = "Produccion Ram";
                this.label1.Text = "Cantidad de Ram";
                this.label3.Text = "Circuito Elect";
                this.label4.Text = "Barrra Plástico";
                this.label5.Text = "Bara Hierro";
                this.label6.Text = "Engranaje Hierro";
                this.label7.Visible = false;
                this.label8.Visible = false;
                this.label9.Visible = false;
                this.label10.Visible = false;
                this.txtQuintoBox.Visible = false;
                this.txtSextoBox.Visible = false;
                this.txtSeptimoBox.Visible = false;
                this.txtOctavoBox.Visible = false;

                this.listaValores = ram.CrearLista((int)numFabricar.Value);
            }
            else
            {
                this.groupBox1.Text = "Produccion Cabinet";
                this.label1.Text = "Cantidad de Cabinet";
                this.label3.Text = "Cable Rojo";
                this.label4.Text = "Barrra Plástico";
                this.label5.Text = "Bara Hierro";
                this.label6.Text = "Engranaje Hierro";
                this.label7.Text = "Ventilador";
                this.label8.Visible = false;
                this.label9.Visible = false;
                this.label10.Visible = false;
                this.txtSextoBox.Visible = false;
                this.txtSeptimoBox.Visible = false;
                this.txtOctavoBox.Visible = false;

                this.listaValores = cabinet.CrearLista((int)numFabricar.Value);
            }

            this.CrearListaTxtBox();
            this.CargaDatos();
            this.BtnFabric.Visible = false;
        }

        private void BtnBackMenu_Click(object sender, EventArgs e)
        {
            this.frmUsuario.Show();
            this.Close();
        }

        private void BtnMaterialesNecesarios_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Materiales necesarios\npara la producción -> su cantidad {this.numFabricar.Value}\n");

            int i = 0;

            this.ActualizarLista();
            this.dictProducto = Stock.ModificarDiccionario(this.producto);

            foreach (KeyValuePair<string, int> item in this.dictProducto)
            {
                sb.AppendLine($"{item.Key}: {this.listaValores[i]}");
                i++;
            }

            MessageBox.Show(sb.ToString(), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (this.numFabricar.Value > 0)
            {
                this.BtnFabric.Visible = true;
            }
            else
            {
                this.BtnFabric.Visible = false;
            }
        }

        private void BtnFabric_Click(object sender, EventArgs e)
        {
            int valorNegativo = -1;
            bool retorno;
            bool retSoldar;
            bool retConectar;

            retorno = VerificarStock();

            if (retorno)
            {
                MessageBox.Show("Iniciando proceso...", "Fabricacion productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                retSoldar = Produccion.Elaborar(ProcesoProduccion.Soldar);
                retConectar = Produccion.Elaborar(ProcesoProduccion.Conectar);

                if (retSoldar && retConectar)
                {
                    MessageBox.Show("Soldando materiales...", "Proceso metalúrgico", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Conectando cables...", "Conección cables", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (this.producto == 0)
                    {
                        Stock.CantUnidadProcesamiento = valorNegativo * this.listaValores[0];
                        Stock.CantCableVerde = valorNegativo * this.listaValores[1];
                        Stock.CantBarraPlastico = valorNegativo * this.listaValores[2];
                        Stock.CantBaraHierro = valorNegativo * this.listaValores[3];
                        Stock.CantEngranajeHierro = valorNegativo * this.listaValores[4];
                        Stock.CantFibrasVidrio = valorNegativo * this.listaValores[5];
                        Stock.CantCondensador = valorNegativo * this.listaValores[6];
                        Stock.CantVentilador = valorNegativo * this.listaValores[7];
                        VideoCard.CantidadProducto = (int)numFabricar.Value;
                    }
                    else if (this.producto == 1)
                    {
                        Stock.CantCircuitosElectronicosAvanzados = valorNegativo * this.listaValores[0];
                        Stock.CantCableRojo = valorNegativo * this.listaValores[1];
                        Stock.CantBarraPlastico = valorNegativo * this.listaValores[2];
                        Stock.CantBaraHierro = valorNegativo * this.listaValores[3];
                        Stock.CantEngranajeHierro = valorNegativo * this.listaValores[4];
                        Stock.CantFibrasVidrio = valorNegativo * this.listaValores[5];
                        Stock.CantCondensador = valorNegativo * this.listaValores[6];
                        Stock.CantVentilador = valorNegativo * this.listaValores[7];
                        Motherboard.CantidadProducto = (int)numFabricar.Value;
                    }
                    else if (this.producto == 2)
                    {
                        Stock.CantCircuitosElectronicos = valorNegativo * this.listaValores[0];
                        Stock.CantBarraPlastico = valorNegativo * this.listaValores[1];
                        Stock.CantBaraHierro = valorNegativo * this.listaValores[2];
                        Stock.CantEngranajeHierro = valorNegativo * this.listaValores[3];
                        Ram.CantidadProducto = (int)numFabricar.Value;
                    }
                    else
                    {
                        Stock.CantCableRojo = valorNegativo * this.listaValores[0];
                        Stock.CantBarraPlastico = valorNegativo * this.listaValores[1];
                        Stock.CantBaraHierro = valorNegativo * this.listaValores[2];
                        Stock.CantEngranajeHierro = valorNegativo * this.listaValores[3];
                        Stock.CantVentilador = valorNegativo * this.listaValores[4];
                        Cabinet.CantidadProducto = (int)numFabricar.Value;
                    }
                    MessageBox.Show("Procesos finalizados\nFabricación EXITOSA", "Fabricacion productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show($"Actualizando datos...", "Actualización de información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmUsuario.CargaDatos();
                    this.frmUsuario.Show();
                    this.Close();
                }
            }
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            switch (this.producto)
            {
                case 0:
                    MessageBox.Show($"{(string)videoCard}", "Fabricacion productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    MessageBox.Show($"{motherboard.Mostrar()}", "Fabricacion productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show($"{ram.Mostrar()}", "Fabricacion productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3:
                    MessageBox.Show($"{cabinet.Mostrar()}", "Fabricacion productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show("No se pudo fabricar ningun producto\nNo se pudo ingresar al sector", "Fabricacion productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        /// <summary>
        /// Cargo datos en un text box, dependiendo con que producto este trabajando
        /// variaran los datos y cantidades
        /// </summary>
        private void CargaDatos()
        {
            int i = 0;

            this.dictProducto = Stock.ModificarDiccionario(this.producto);

            foreach (KeyValuePair<string, int> item in this.dictProducto)
            {
                this.listaTxtBox[i].Text = item.Value.ToString();
                i++;
            }
        }

        /// <summary>
        /// Dependiendo con que producto estemos trabajando se actualizaran cada vez q llamemos a este metodo
        /// los datos que posiblemente utilizaremos para la fabricacion del producto terminado 
        /// </summary>
        private void ActualizarLista()
        {
            if (this.producto == 0)
            {
                // probar de hacer un indexador para ingresarle y pisar su valor por otro
                this.listaValores = videoCard.PisarLista((int)numFabricar.Value);
            }
            else if (this.producto == 1)
            {
                this.listaValores = motherboard.PisarLista((int)numFabricar.Value);
            }
            else if (this.producto == 2)
            {
                this.listaValores = ram.PisarLista((int)numFabricar.Value);
            }
            else
            {
                this.listaValores = cabinet.PisarLista((int)numFabricar.Value);
            }
        }

        /// <summary>
        /// Dependiendo con que producto estemos trabajando crearemos una lista de txtBox
        /// </summary>
        private void CrearListaTxtBox()
        {
            if (this.producto == 0)
            {
                this.listaTxtBox = new List<TextBox> {
                    this.txtPrimerBox,
                    this.txtSegundoBox,
                    this.txtTercerBox,
                    this.txtCuartoBox,
                    this.txtQuintoBox,
                    this.txtSextoBox,
                    this.txtSeptimoBox,
                    this.txtOctavoBox
                    };
            }
            else if (this.producto == 1)
            {
                this.listaTxtBox = new List<TextBox> {
                    this.txtPrimerBox,
                    this.txtSegundoBox,
                    this.txtTercerBox,
                    this.txtCuartoBox,
                    this.txtQuintoBox,
                    this.txtSextoBox,
                    this.txtSeptimoBox,
                    this.txtOctavoBox
                    };
            }
            else if (this.producto == 2)
            {
                this.listaTxtBox = new List<TextBox> {
                    this.txtPrimerBox,
                    this.txtSegundoBox,
                    this.txtTercerBox,
                    this.txtCuartoBox
                    };
            }
            else
            {
                this.listaTxtBox = new List<TextBox> {
                    this.txtPrimerBox,
                    this.txtSegundoBox,
                    this.txtTercerBox,
                    this.txtCuartoBox,
                    this.txtQuintoBox
                    };
            }
        }

        /// <summary>
        /// Verificaremos que con el producto con el que estamso trabajando tengamos stock de los
        /// materiales pedidos para producir el producto final
        /// </summary>
        /// <returns>Retornaremos un booleano dependiendo de si se puede fabricar o faltan materiales para el producto final</returns>
        private bool VerificarStock()
        {
            string formatoStock;
            bool retorno = false;

            if (retorno = Stock.VerificarStock(listaValores, this.dictProducto, this.producto))
            {
                MessageBox.Show("Stock OK\nEn condiciones de producir la cantidad pedida", "Actualización de información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                retorno = true;
            }
            else
            {
                formatoStock = Stock.ConstruccionStock(listaValores, this.dictProducto, this.producto);
                MessageBox.Show(formatoStock, "Actualización de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BtnFabric.Visible = false;
            }

            return retorno;
        }
    }
}
