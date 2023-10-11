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
        public FrmReStockMateriales(MenuUsuario menuCargo)
        {
            InitializeComponent();
            this.menuCargo = menuCargo;
            this.listaNum = new List<int>();
        }

        private void FrmReStockMateriales_Load(object sender, EventArgs e)
        {

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
            bool ret;
            this.listaNum = this.CargarListaNum();

            ret = Stock.ActualizarStock(this.listaNum);

            if (ret)
            {
                MessageBox.Show("Carga de materiales ha sido completada\nvolviendo al menu", "Carga materiales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"Actualizando datos...", "Actualización de información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                menuCargo.CargaDatos();
                this.menuCargo.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show($"No se pudieron cargar los materiales", "Error en carga de materiales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Lista instanciada con los valores de los controles num
        /// </summary>
        /// <returns>Retorna la lista con los datos cargados</returns>
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
