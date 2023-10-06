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
            this.listaNum.Add((int)this.numCircuitoElect.Value);
            this.listaNum.Add((int)this.numCircuitoElectAv.Value);
            this.listaNum.Add((int)this.numUnProcesamiento.Value);
            this.listaNum.Add((int)this.numCableVerde.Value);
            this.listaNum.Add((int)this.numCableRojo.Value);
            this.listaNum.Add((int)this.numBarraPlastica.Value);
            this.listaNum.Add((int)this.numBaraHierro.Value);
            this.listaNum.Add((int)this.numEngranajeHierro.Value);
            this.listaNum.Add((int)this.numFibraVidrio.Value);
            this.listaNum.Add((int)this.numCondensador.Value);
            this.listaNum.Add((int)this.numVentilador.Value);

            return this.listaNum;
        }
    }
}
