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
    public partial class FrmReStockMateriales : Form
    {
        private MenuUsuario menuCargo;
        private List<int> listaNum;
        private List<string> listaHardcodeada;
        private Dictionary<string, int> dictStock;
        public FrmReStockMateriales(MenuUsuario menuCargo)
        {
            InitializeComponent();
            this.menuCargo = menuCargo;
            this.listaNum = new List<int>();
            this.listaHardcodeada = new List<string>(); 
        }

        private void FrmReStockMateriales_Load(object sender, EventArgs e)
        {
            this.listaHardcodeada = Stock.ListaHarcodeadaStock();
        }

        private void btnBackWindow_Click(object sender, EventArgs e)
        {
            this.menuCargo.Show();
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // si logro poder realizar la logica de abajo, condicionar que si tengo valores por debajo del
            // 0 al modificar los atributos no los modifique

            //this.dictStock = Stock.DiccionarioDelStock();
            //this.listaNum = this.CargarListaNum();

            //// falta una vuelta de rosca por aca
            //int i = 0;

            //foreach (KeyValuePair<string, int> item in this.dictStock)
            //{
            //    this.dictStock.TryGetValue(this.listaHardcodeada[i], out int value); 
            //    i++;
            //}

            Stock.CantCircuitosElectronicos = (int)numCircuitoElect.Value;
            Stock.CantCircuitosElectronicosAvanzados = (int)numCircuitoElectAv.Value;
            Stock.CantUnidadProcesamiento = (int)numUnProcesamiento.Value;
            Stock.CantCableVerde = (int)numCableVerde.Value;
            Stock.CantCableRojo = (int)numCableRojo.Value;
            Stock.CantBarraPlastico = (int)numBarraPlastica.Value;
            Stock.CantBaraHierro = (int)numBaraHierro.Value;
            Stock.CantEngranajeHierro = (int)numEngranajeHierro.Value;
            Stock.CantFibrasVidrio = (int)numFibraVidrio.Value;
            Stock.CantCondensador = (int)numCondensador.Value;
            Stock.CantVentilador = (int)numVentilador.Value;

            //investigar que es singleton

            MessageBox.Show("Carga de materiales ha sido completada\nvolviendo al menu", "Iniciando sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show($"Actualizando datos...", "Actualización de información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            menuCargo.CargaDatos();
            this.menuCargo.Show();
            this.Close();
        }

        private List<int> CargarListaNum()
        {
            this.listaNum.Add((int)numCircuitoElect.Value);
            this.listaNum.Add((int)numCircuitoElectAv.Value);
            this.listaNum.Add((int)numUnProcesamiento.Value);
            this.listaNum.Add((int)numCableVerde.Value);
            this.listaNum.Add((int)numCableRojo.Value);
            this.listaNum.Add((int)numBarraPlastica.Value);
            this.listaNum.Add((int)numBaraHierro.Value);
            this.listaNum.Add((int)numEngranajeHierro.Value);
            this.listaNum.Add((int)numFibraVidrio.Value);
            this.listaNum.Add((int)numCondensador.Value);
            this.listaNum.Add((int)numVentilador.Value);

            return this.listaNum;
        }
    }
}
