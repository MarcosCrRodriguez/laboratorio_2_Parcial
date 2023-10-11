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
    public partial class FrmDataGirdView : Form
    {
        private MenuUsuario menuCargo;
        private List<Operario> listOperario;
        public FrmDataGirdView(MenuUsuario menuCargo, List<Operario> listOperario)
        {
            InitializeComponent();
            this.menuCargo = menuCargo;
            this.listOperario = listOperario;
        }

        private void FrmDataGirdView_Load(object sender, EventArgs e)
        {
            DtgvRegistro.DataSource = listOperario;
            DtgvRegistro.Refresh();
            DtgvRegistro.Update();
        }

        private void BtnBackMenu_Click(object sender, EventArgs e)
        {
            this.menuCargo.Show();
            this.Close();
        }


    }
}
