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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLobby
{
    public partial class FrmDataGirdView : Form
    {
        private MenuUsuario menuPrincipal;
        private Configuracion configJson;
        private List<Operario> listOperario;

        private string path;
        private string pathJSON;
        public FrmDataGirdView(MenuUsuario menuPrincipal)
        {
            InitializeComponent();
            this.menuPrincipal = menuPrincipal;
            this.listOperario = OperarioDAO<Operario>.LeerOperariosDatosCompletos("Operario");

            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
            this.pathJSON = "Imagenes.json";
        }

        /// <summary>
        /// Carga del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDataGirdView_Load(object sender, EventArgs e)
        {
            this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
            Image img = Image.FromFile(this.configJson.PathImagenCircuitoRojo);
            this.BackgroundImage = img;

            this.DtgvRegistro.DataSource = this.listOperario;
            this.DtgvRegistro.Refresh();
            this.DtgvRegistro.Update();
        }

        /// <summary>
        /// Boton para volver al formulario anterior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBackMenu_Click(object sender, EventArgs e)
        {
            this.menuPrincipal.Show();
            this.Close();
        }

        /// <summary>
        /// Boton que ingresa al formulario de registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            FormularioRegistro frmRegistro = new FormularioRegistro();
            frmRegistro.ShowDialog();
        }

        /// <summary>
        /// Boton que ingresa al formulario de modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            FrmModificar frmModificar = new FrmModificar();
            frmModificar.ShowDialog();
        }

        /// <summary>
        /// Boton que ingresa al formulario de eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            FrmEliminar frmEliminar = new FrmEliminar();
            frmEliminar.ShowDialog();
        }
    }
}
