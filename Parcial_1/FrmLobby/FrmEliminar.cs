using Entidades;
using ExcepcionesPropias;
using Archivos;
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
    public partial class FrmEliminar : Form
    {
        private string path;
        public FrmEliminar()
        {
            InitializeComponent();
            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
        }

        private void FrmEliminar_Load(object sender, EventArgs e)
        {

        }

        private void BtnDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCodigoUsuario.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio - [ParametrosVaciosException]");
                }
                if (Operario.VerificarExisteID(OperarioDAO.LeerOperarios("Operario"), Convert.ToInt32(this.txtCodigoUsuario.Text)))
                {
                    DialogResult result = MessageBox.Show("¿Esta seguro que desea Dar De Baja a este Usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        
                        if (SupervisorDAO.Eliminar(Convert.ToInt32(this.txtCodigoUsuario.Text), "Operario"))
                        {
                            MessageBox.Show("El Usuario se ha dado de baja correctamente", "Baja Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El Usuario no se encuentra en la base de datos\nO no puede dar de bajo ya que tiene un cargo igual o superior al suyo", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Usuario no se dio de baja", "Baja Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("El Usuario no se encuentra en la base de datos\nO no puede dar de bajo ya que tiene un cargo igual o superior al suyo", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (EmptyParametersException ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "EmptyParametersException", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "Parametros Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "FormatException", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "Tipo de dato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DataBasesException ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "DataBasesException", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "Error con DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ArchivosTXT<string>.CargarExcepcionEnArchivo(this.path, "Exception", $"{ex.StackTrace}");
                MessageBox.Show(ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBackMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
