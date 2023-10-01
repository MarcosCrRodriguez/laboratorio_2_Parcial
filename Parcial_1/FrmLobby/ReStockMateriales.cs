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
        public FrmReStockMateriales(MenuUsuario menuCargo)
        {
            InitializeComponent();
            this.menuCargo = menuCargo;
        }

        private void FrmReStockMateriales_Load(object sender, EventArgs e)
        {

        }

        private void btnBackWindow_Click(object sender, EventArgs e)
        {
            this.menuCargo.Show();
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Stock.CantCircuitosElectronicos = (int)numCircuitoElect.Value;
            Stock.CantCircuitosElectronicosAvanzados = (int)numCircuitoElectAv.Value;
            Stock.CantUnidadProcesamiento = (int)numUnProcesamiento.Value;
            Stock.CantBarraPlastico = (int)numBarraPlastica.Value;
            Stock.CantCableVerde = (int)numCableVerde.Value;
            Stock.CantCableRojo = (int)numCableRojo.Value;
            Stock.CantBaraHierro = (int)numBaraHierro.Value;
            Stock.CantEngranajeHierro = (int)numEngranajeHierro.Value;
            Stock.CantFibrasVidrio = (int)numFibraVidrio.Value;
            Stock.CantCondensador = (int)numCondensador.Value;
            Stock.CantVentilador = (int)numVentilador.Value;

            MessageBox.Show("Carga de materiales ha sido completada\nvolviendo al menu", "Iniciando sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show($"Actualizando datos...", "Actualización de información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            menuCargo.CargaDatos();
            this.menuCargo.Show();
            this.Close();
        }
    }
}
