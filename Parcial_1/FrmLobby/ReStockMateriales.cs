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
        //private List<string> listaHardcodeada;
        private Dictionary<string, int> dictStock;
        public FrmReStockMateriales(MenuUsuario menuCargo)
        {
            InitializeComponent();
            this.menuCargo = menuCargo;
            //this.listaHardcodeada = new List<string>();
        }

        private void FrmReStockMateriales_Load(object sender, EventArgs e)
        {
            //this.listaHardcodeada = Stock.ListaHarcodeadaStock();
        }

        private void BtnBackWindow_Click(object sender, EventArgs e)
        {
            this.menuCargo.Show();
            this.Close();
        }

        private void BtnHardcodeo_Click(object sender, EventArgs e)
        {
            numCircuitoElect.Value += 1500;
            numCircuitoElectAv.Value += 1500;
            numUnProcesamiento.Value += 1500;
            numCableVerde.Value += 1500;
            numCableRojo.Value += 1500;
            numBarraPlastica.Value += 1500;
            numBaraHierro.Value += 1500;
            numEngranajeHierro.Value += 1500;
            numFibraVidrio.Value += 1500;
            numCondensador.Value += 1500;
            numVentilador.Value += 1500;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            this.listaNum = this.CargarListaNum();

            Stock.ActualizarStock(this.listaNum);

            MessageBox.Show("Carga de materiales ha sido completada\nvolviendo al menu", "Iniciando sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show($"Actualizando datos...", "Actualización de información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            menuCargo.CargaDatos();
            this.menuCargo.Show();
            this.Close();
        }

        private List<int> CargarListaNum()
        {
            this.listaNum = new List<int>() {
                (int)this.numCircuitoElect.Value,
                (int)this.numCircuitoElectAv.Value,
                (int)this.numUnProcesamiento.Value,
                (int)this.numCableVerde.Value,
                (int)this.numCableRojo.Value,
                (int)this.numBarraPlastica.Value,
                (int)this.numBaraHierro.Value,
                (int)this.numEngranajeHierro.Value,
                (int)this.numFibraVidrio.Value,
                (int)this.numCondensador.Value,
                (int)this.numVentilador.Value
                };

            return this.listaNum;
        }
    }
}
