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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FrmLobby
{
    public partial class FrmProductoFinal : Form
    {
        public delegate void Mostrar(string texto, string titulo);
        public delegate void ManejadorEventos(int cantidadAgregar);
        public event ManejadorEventos manejadorEventos;

        private IArchivos<string> manejadorArchivosTXT;
        private IMateriales manejadorProductos;

        private int valorInt;
        private string productoDB;
        private MenuUsuario frmUsuario;
        private VideoCard videoCard;
        private Motherboard motherboard;
        private Ram ram;
        private Cabinet cabinet;
        private Configuracion configJson;

        private int producto;
        private List<TextBox> listaTxtBox;
        private List<int> listaValores;
        private Dictionary<string, int> dictProducto;

        private string path;
        private string pathTXT;
        private string pathJSON;

        public FrmProductoFinal(MenuUsuario frmUsuario, int producto)
        {
            InitializeComponent();
            this.manejadorArchivosTXT = new ArchivosTXT<string>();
            this.manejadorProductos = new ProductosDAO();

            this.frmUsuario = frmUsuario;
            this.videoCard = new VideoCard();
            this.motherboard = new Motherboard();
            this.ram = new Ram();
            this.cabinet = new Cabinet();
            this.producto = producto;
            this.listaTxtBox = new List<TextBox>();
            this.listaValores = new List<int>();
            this.dictProducto = new Dictionary<string, int>();

            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
            this.pathTXT = "Log_Excepciones.txt";
            this.pathJSON = "Imagenes.json";

            lblHelp.Click += new EventHandler(EventHandlerDinamico);
        }

        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmVideoCard_Load(object sender, EventArgs e)
        {
            this.valorInt = Stock.CasteoExplicito(numFabricar.Value);

            this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
            Image img = Image.FromFile(this.configJson.PathImagenCircuitoRojo);
            this.BackgroundImage = img;

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
                this.productoDB = "VIDEO_CARD";

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
                this.productoDB = "MOTHERBOARD";

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
                this.productoDB = "RAM";

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
                this.productoDB = "CABINET";

                this.listaValores = cabinet.CrearLista(this.valorInt);
            }
            this.CrearListaTxtBox();
            this.CargaDatos();

            manejadorEventos += ModificarCantidad;
        }

        /// <summary>
        /// Boton para volver al formulario anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackMenu_Click(object sender, EventArgs e)
        {
            this.frmUsuario.Show();
            this.Close();
        }

        /// <summary>
        /// Boton que muestra una ventana con los materiales necesarios para los datos ingresados en la seccion de cantidades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Boton para fabricar la cantidad de productos ingresada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFabric_Click(object sender, EventArgs e)
        {
            Mostrar mostrarError = new Mostrar(FrmLobby.MostrarError);
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);

            int valorNegativo = -1;
            bool retorno;
            bool retFabricar;
            int cantidadAgregar;

            try
            {
                if (this.numFabricar.Value == 0)
                {
                    throw new EmptyParametersException("No se puede fabricar [0] productos\nIntreduce una cantidad valida - [ParametrosVaciosException]");
                }
                else if (this.txtIDProducto.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio - [ParametrosVaciosException]");
                }
                else if (Stock.CasteoExplicito(this.txtIDProducto.Text) != 1329)
                {
                    throw new InvalidPasswordException("El ID es incorrecto - [InvalidPasswordException]");
                }

                this.valorInt = Stock.CasteoExplicito(numFabricar.Value);
                this.ActualizarLista(this.valorInt);
                retorno = VerificarStock();

                if (retorno)
                {
                    if (this.producto == 0)
                    {
                        retFabricar = videoCard.FabricarProducto(valorNegativo, this.listaValores);
                    }
                    else if (this.producto == 1)
                    {
                        retFabricar = motherboard.FabricarProducto(valorNegativo, this.listaValores);
                    }
                    else if (this.producto == 2)
                    {
                        retFabricar = ram.FabricarProducto(valorNegativo, this.listaValores);
                    }
                    else
                    {
                        retFabricar = cabinet.FabricarProducto(valorNegativo, this.listaValores);
                    }

                    if (retFabricar)
                    {
                        cantidadAgregar = Producto.VerificarValorPositivo(Stock.CasteoExplicito(this.numFabricar.Value), Stock.CasteoExplicito(this.txtIDProducto.Text), this.productoDB);
                        if (cantidadAgregar != -1)
                        {
                            if (this.manejadorEventos is not null)
                            {
                                this.manejadorEventos.Invoke(cantidadAgregar);
                            }
                        }
                        else
                        {
                            mostrarError("No se pudo cargar los materiales cargados en el formulario", "Error de carga");
                        }

                        mostrarInformacion($"Actualizando datos...", "Actualización de información");
                        frmUsuario.CargaDatos();
                        this.frmUsuario.Show();
                        this.Close();
                    }
                    else
                    {
                        mostrarError("No se pudieron fabricar los productos", "Fabricacion productos");
                    }
                }
            }
            catch (EmptyParametersException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("EmptyParametersException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Parametros Vacios");
            }
            catch (FormatException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("FormatException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Tipo de dato Incorrecto");
            }
            catch (InvalidPasswordException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("InvalidPasswordException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "ID incorrecto");
            }
            catch (DataBasesException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("DataBasesException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Error con DB");
            }
            catch (NegativeValueException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("NegativeValueException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "El valor en Stock no puede ser menor que 0");
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Error Inesperado");
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
            Mostrar mostrarError = new Mostrar(FrmLobby.MostrarError);
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion);

            string formatoStock;
            bool retorno = false;

            this.dictProducto = Stock.ModificarDiccionario(producto);

            if (Stock.VerificarStock(this.listaValores, this.dictProducto))
            {
                mostrarInformacion("Stock OK\nEn condiciones de producir la cantidad pedida", "Estado Stock");
                retorno = true;
            }
            else
            {
                formatoStock = Stock.StockFaltante(this.listaValores, this.dictProducto);
                mostrarError(formatoStock, "Estado Stock");
                mostrarError("Deberá fabricar una menor cantidad de materiales, o pedir a un supervisor que encargue mas materiales de los faltantes", "Estado Stock");
            }

            return retorno;
        }

        /// <summary>
        /// Muestra un mensaje por pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EventHandlerDinamico(object sender, EventArgs e)
        {
            MessageBox.Show("- ID Stock - usted ingresara un password que le permitirá el acceso a modificar el Producto que esta queriendo fabricar.\n" +
                $"- {this.productoDB} cantidad a agregar - la cantidad de preductos que desea fabricar.\n" +
                "ID Stock: [1329]",
                "Help Box", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Invocamos el evento para modificar la cantidad de materiales en la DB
        /// </summary>
        /// <param name="cantidadAgregar">Cantidad a modificar</param>
        public void ModificarCantidad(int cantidadAgregar)
        {
            Mostrar mostrarError = new Mostrar(FrmLobby.MostrarError);

            if (this.manejadorProductos.Modificar(this.productoDB, cantidadAgregar, Stock.CasteoExplicito(this.txtIDProducto.Text)))
            {
                FrmProcesos frmProcesos = new FrmProcesos((int)this.numFabricar.Value);
                frmProcesos.Show();
            }
            else
            {
                mostrarError("No se pudo modificar los datos del material ingresado", "Error de carga");
            }
        }
    }
}
