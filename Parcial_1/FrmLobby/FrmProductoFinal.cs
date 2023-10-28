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
        private int valorInt;
        private MenuUsuario frmUsuario;
        private VideoCard videoCard;
        private Motherboard motherboard;
        private Ram ram;
        private Cabinet cabinet;
        private int producto;
        private List<TextBox> listaTxtBox;
        private List<int> listaValores;
        private Dictionary<string, int> dictProducto;

        public FrmProductoFinal(MenuUsuario frmUsuario, int producto)
        {
            InitializeComponent();
            this.frmUsuario = frmUsuario;
            this.videoCard = new VideoCard();
            this.motherboard = new Motherboard();
            this.ram = new Ram();
            this.cabinet = new Cabinet();
            this.producto = producto;
            this.listaTxtBox = new List<TextBox>();
            this.listaValores = new List<int>();
            this.dictProducto = new Dictionary<string, int>();
        }

        private void FrmVideoCard_Load(object sender, EventArgs e)
        {
            this.valorInt = Stock.CasteoExplicito(numFabricar.Value);

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

                this.listaValores = videoCard.CrearLista(this.valorInt);
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

                this.listaValores = motherboard.CrearLista(this.valorInt);
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

                this.listaValores = ram.CrearLista(this.valorInt);
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

                this.listaValores = cabinet.CrearLista(this.valorInt);
            }

            this.CrearListaTxtBox();
            this.CargaDatos();
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

            this.valorInt = Stock.CasteoExplicito(numFabricar.Value);
            this.ActualizarLista(this.valorInt);
            this.dictProducto = Stock.ModificarDiccionario(this.producto);

            foreach (KeyValuePair<string, int> item in this.dictProducto)
            {
                sb.AppendLine($"{item.Key}: {this.listaValores[i]}");
                i++;
            }

            MessageBox.Show(sb.ToString(), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnFabric_Click(object sender, EventArgs e)
        {
            int valorNegativo = -1;
            bool retorno;
            bool retSoldar;
            bool retConectar;
            bool retEnsamblar;
            bool retEmpaquetar;
            bool retFabricar;

            this.valorInt = Stock.CasteoExplicito(numFabricar.Value);
            this.ActualizarLista(this.valorInt);
            retorno = VerificarStock();

            if (retorno)
            {
                MessageBox.Show("Iniciando proceso...", "Fabricacion productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                retSoldar = Produccion.Elaborar(ProcesoProduccion.Soldar);
                retConectar = Produccion.Elaborar(ProcesoProduccion.Conectar);
                retEnsamblar = Produccion.Elaborar(ProcesoProduccion.Ensamblar);
                retEmpaquetar = Produccion.Elaborar(ProcesoProduccion.Empaquetar);

                if (retSoldar && retConectar && retEnsamblar && retEmpaquetar)
                {
                    MessageBox.Show("Soldando materiales...\nConectando cables...\nEnsamblado de piezas...", "Proceso metalúrgico - Conexión cables - Ensamblaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    if (this.producto == 0)
                    {
                        retFabricar = videoCard.FabricarProducto(valorNegativo, this.listaValores);
                        VideoCard.CantidadProducto += this.valorInt;
                    }
                    else if (this.producto == 1)
                    {
                        retFabricar = motherboard.FabricarProducto(valorNegativo, this.listaValores);
                        Motherboard.CantidadProducto += this.valorInt;
                    }
                    else if (this.producto == 2)
                    {
                        retFabricar = ram.FabricarProducto(valorNegativo, this.listaValores);
                        Ram.CantidadProducto += this.valorInt;
                    }
                    else
                    {
                        retFabricar = cabinet.FabricarProducto(valorNegativo, this.listaValores);
                        Cabinet.CantidadProducto = this.valorInt;
                    }

                    if (retFabricar)
                    {
                        MessageBox.Show($"Fabricación EXITOSA\nEmpaquetando productos\n\nProductos fabricados: {this.valorInt}", "Procesos finalizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void ActualizarLista(int valor)
        {
            switch (this.producto)
            {
                case 0:
                    this.listaValores = videoCard.PisarLista(valor);
                    break;
                case 1:
                    this.listaValores = motherboard.PisarLista(valor);
                    break;
                case 2:
                    this.listaValores = ram.PisarLista(valor);
                    break;
                case 3:
                    this.listaValores = cabinet.PisarLista(valor);
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
                // podria probar de hacer mi propia excepcion aca -> interesante :D
                MessageBox.Show(formatoStock, "Estado Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Deberá fabricar una menor cantidad de materiales, o pedir a un supervisor que encargue mas materiales de los faltantes", "Estado Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retorno;
        }
    }
}
