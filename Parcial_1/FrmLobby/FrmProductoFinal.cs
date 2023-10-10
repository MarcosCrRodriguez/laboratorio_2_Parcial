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
            this.videoCard = new VideoCard();
            this.motherboard = new Motherboard();
            this.ram = new Ram();
            this.cabinet = new Cabinet();
            this.producto = producto;
            this.dictProducto = new Dictionary<string, int>();
            this.listaTxtBox = new List<TextBox>();
            this.listaValores = new List<int>();
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

                //sobrecarga que reciba el decimal y lo caste a entero
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
            bool retFabricar;

            this.ActualizarLista();
            retorno = VerificarStock();

            if (retorno)
            {
                MessageBox.Show("Iniciando proceso...", "Fabricacion productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                retSoldar = Produccion.Elaborar(ProcesoProduccion.Soldar);
                retConectar = Produccion.Elaborar(ProcesoProduccion.Conectar);

                if (retSoldar && retConectar)
                {
                    MessageBox.Show("Soldando materiales...\nConectando cables...\nEnsamblado de piezas...", "Proceso metalúrgico - Conexión cables - Ensamblaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    if (this.producto == 0)
                    {
                        retFabricar = videoCard.FabricarProducto(valorNegativo, this.listaValores);
                        VideoCard.CantidadProducto += (int)numFabricar.Value;
                    }
                    else if (this.producto == 1)
                    {
                        retFabricar = motherboard.FabricarProducto(valorNegativo, this.listaValores);
                        Motherboard.CantidadProducto += (int)numFabricar.Value;
                    }
                    else if (this.producto == 2)
                    {
                        retFabricar = ram.FabricarProducto(valorNegativo, this.listaValores);
                        Ram.CantidadProducto += (int)numFabricar.Value;
                    }
                    else
                    {
                        retFabricar = cabinet.FabricarProducto(valorNegativo, this.listaValores);
                        Cabinet.CantidadProducto = (int)numFabricar.Value;
                    }

                    if (retFabricar)
                    {
                        MessageBox.Show("Procesos finalizados\nFabricación EXITOSA", "Fabricacion productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Actualizando datos...", "Actualización de información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmUsuario.CargaDatos();
                        this.frmUsuario.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron fabricar los productos", "Fabricacion productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            switch (this.producto)
            {
                case 0:
                    MessageBox.Show($"{(string)videoCard}", "Datos producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    MessageBox.Show($"{(string)motherboard}", "Datos producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show($"{(string)ram}", "Datos producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3:
                    MessageBox.Show($"{(string)cabinet}", "Datos producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show("No se pude mostrar producto", "Datos producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            switch (this.producto)
            {
                case 0:
                    this.listaValores = videoCard.PisarLista((int)numFabricar.Value);
                    break;
                case 1:
                    this.listaValores = motherboard.PisarLista((int)numFabricar.Value);
                    break;
                case 2:
                    this.listaValores = ram.PisarLista((int)numFabricar.Value);
                    break;
                case 3:
                    this.listaValores = cabinet.PisarLista((int)numFabricar.Value);
                    break;
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

            foreach (TextBox item in this.listaTxtBox)
            {
                item.Enabled = false;
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

            this.dictProducto = Stock.ModificarDiccionario(producto);

            if (Stock.VerificarStock(this.listaValores, this.dictProducto))
            {
                MessageBox.Show("Stock OK\nEn condiciones de producir la cantidad pedida", "Estado Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                retorno = true;
            }
            else
            {
                formatoStock = Stock.StockFaltante(this.listaValores, this.dictProducto);
                MessageBox.Show(formatoStock, "Estado Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BtnFabric.Visible = false;
            }

            return retorno;
        }
    }
}
