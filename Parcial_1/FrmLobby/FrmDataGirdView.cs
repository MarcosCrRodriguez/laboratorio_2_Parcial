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
        private MenuUsuario menuPrincipal;
        private List<Operario> listOperario;
        public FrmDataGirdView(MenuUsuario menuPrincipal)
        {
            InitializeComponent();
            this.menuPrincipal = menuPrincipal;
            this.listOperario = OperarioDAO.LeerOperariosDatosCompletos("Operario");
        }

        private void FrmDataGirdView_Load(object sender, EventArgs e)
        {
            this.DtgvRegistro.DataSource = this.listOperario;
            this.DtgvRegistro.Refresh();
            this.DtgvRegistro.Update();
        }

        private void BtnBackMenu_Click(object sender, EventArgs e)
        {
            this.menuPrincipal.Show();
            this.Close();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            FormularioRegistro frmRegistro = new FormularioRegistro();
            frmRegistro.ShowDialog();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {  
            FrmModificar frmModificar = new FrmModificar();
            frmModificar.ShowDialog();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            FrmEliminar frmEliminar = new FrmEliminar();
            frmEliminar.ShowDialog();
        }
    }
}
