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
        private List<decimal> listaNum;
        private List<int> listaInt;
        public FrmReStockMateriales(MenuUsuario menuCargo)
        {
            InitializeComponent();
            this.menuCargo = menuCargo;
            this.listaNum = new List<decimal>();
            this.listaInt = new List<int>();    
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
            int sumaValor = 1500;

            numCircuitoElect.Value += sumaValor;
            numCircuitoElectAv.Value += sumaValor;
            numUnProcesamiento.Value += sumaValor;
            numCableVerde.Value += sumaValor;
            numCableRojo.Value += sumaValor;
            numBarraPlastica.Value += sumaValor;
            numBaraHierro.Value += sumaValor;
            numEngranajeHierro.Value += sumaValor;
            numFibraVidrio.Value += sumaValor;
            numCondensador.Value += sumaValor;
            numVentilador.Value += sumaValor;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            bool ret;
            this.listaInt = this.CargarListaNum();

            ret = Stock.ActualizarStock(this.listaInt);

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
            this.listaNum = new List<decimal>() {
                this.numCircuitoElect.Value,
                this.numCircuitoElectAv.Value,
                this.numUnProcesamiento.Value,
                this.numCableVerde.Value,
                this.numCableRojo.Value,
                this.numBarraPlastica.Value,
                this.numBaraHierro.Value,
                this.numEngranajeHierro.Value,
                this.numFibraVidrio.Value,
                this.numCondensador.Value,
                this.numVentilador.Value
                };

            this.listaInt = Stock.CasteoExplicitoLista(this.listaNum);

            return this.listaInt;
        }
    }
}
