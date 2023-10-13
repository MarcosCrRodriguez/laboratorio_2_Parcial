using Entidades;
using System;
using System.Collections;
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
        private List<Operario> listOperario;
        public FrmDataGirdView(List<Operario> listOperario)
        {
            InitializeComponent();
            this.listOperario = listOperario;
        }

        private void FrmDataGirdView_Load(object sender, EventArgs e)
        {
            this.DtgvRegistro.DataSource = listOperario;
            this.DtgvRegistro.Refresh();
            this.DtgvRegistro.Update();
        }

        private void BtnBackMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
