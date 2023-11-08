using Entidades;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLobby
{
    public partial class FrmModificar : Form
    {
        private Operario? operario;
        public FrmModificar()
        {
            InitializeComponent();
        }

        private void FrmModificar_Load(object sender, EventArgs e)
        {
            this.BtnModificar.Visible = false;
            this.txtBoxNombre.ReadOnly = true;
            this.txtBoxApellido.ReadOnly = true;
            this.txtBoxEdad.ReadOnly = true;
            this.txtBoxEmail.ReadOnly = true;
            this.txtBoxDireccion.ReadOnly = true;
            this.txtBoxTelefono.ReadOnly = true;
            this.monthCalendar.Enabled = false;
            this.txtBoxDireccion.ReadOnly = true;
            this.txtBoxCargo.ReadOnly = true;
        }

        private void BtnBackToLobby_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtBoxNombre.Text == "" || this.txtBoxApellido.Text == "" || this.txtBoxEdad.Text == "" || this.txtBoxEmail.Text == "" || this.txtBoxTelefono.Text == "" || this.txtBoxDNI.Text == "" || this.txtBoxDireccion.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio - [ParametrosVaciosException]");
                }
                Operario operario = new Operario(this.txtBoxNombre.Text, this.txtBoxApellido.Text, Operario.CasteoInt(this.txtCodigoUsuario.Text), this.txtBoxCargo.Text, Operario.CasteoLong(this.txtBoxDNI.Text), this.txtBoxEmail.Text, Operario.CasteoInt(this.txtBoxEdad.Text), this.monthCalendar.SelectionStart, this.txtBoxDireccion.Text, this.txtBoxTelefono.Text);
                if (SupervisorDAO.Modificar(operario))
                {
                    MessageBox.Show("Se modifico el Operario correctamente", "Modificación de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (EmptyParametersException ex)
            {
                MessageBox.Show(ex.Message, "Parametros Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Tipo de dato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DataBasesException ex)
            {
                MessageBox.Show(ex.Message, "Error con DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIngresarID_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtCodigoUsuario.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio - [ParametrosVaciosException]");
                }
                if (Operario.VerificarExisteID(OperarioDAO.LeerOperariosDatosCompletos("Operario"), Operario.CasteoInt(this.txtCodigoUsuario.Text)))
                {
                    this.operario = OperarioDAO.LeerPorID(Operario.CasteoInt(this.txtCodigoUsuario.Text));
                    if (this.operario != null)
                    {
                        this.txtBoxNombre.Text = operario.Nombre;
                        this.txtBoxApellido.Text = operario.Apellido;
                        this.txtBoxEdad.Text = operario.Edad.ToString();
                        this.txtBoxEmail.Text = operario.Email;
                        this.txtBoxTelefono.Text = operario.Telefono;
                        this.txtBoxDNI.Text = operario.DNI.ToString();
                        this.monthCalendar.SelectionStart = operario.FechaIngreso;
                        this.txtBoxDireccion.Text = operario.Direccion;
                        this.txtBoxCargo.Text = operario.Puesto;

                        this.txtCodigoUsuario.ReadOnly = true;
                        this.txtBoxNombre.ReadOnly = false;
                        this.txtBoxApellido.ReadOnly = false;
                        this.txtBoxEdad.ReadOnly = false;
                        this.txtBoxEmail.ReadOnly = false;
                        this.txtBoxDireccion.ReadOnly = false;
                        this.txtBoxTelefono.ReadOnly = false;
                        this.monthCalendar.Enabled = true;
                        this.txtBoxDireccion.ReadOnly = false;
                        this.BtnModificar.Visible = true;
                        this.BtnIngresarID.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("El Usuario no se encuentra en la base de datos\nO no puede dar de bajo ya que tiene un cargo igual o superior al suyo", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (EmptyParametersException ex)
            {
                MessageBox.Show(ex.Message, "Parametros Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Tipo de dato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DataBasesException ex)
            {
                MessageBox.Show(ex.Message, "Error con DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
