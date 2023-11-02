using Entidades;
using ExcepcionesPropias;
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
    public partial class FormularioRegistro : Form
    {
        private FrmLobby lobby;
        public FormularioRegistro(FrmLobby lobby)
        {
            InitializeComponent();
            this.lobby = lobby;
        }

        private void FormularioRegistro_Load(object sender, EventArgs e)
        {
            this.cboxCargo.Items.Add("Operario");
            this.cboxCargo.Items.Add("Supervisor");
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtBoxNombre.Text == "" || this.txtBoxApellido.Text == "" || this.txtBoxEdad.Text == "" || this.txtBoxEmail.Text == "" || this.txtBoxTelefono.Text == "" || this.txtBoxDNI.Text == "" || this.txtBoxDireccion.Text == "" || this.cboxCargo.Text == "" || this.numDia.Value == 0 || this.numMes.Value == 0 || this.numAnio.Value == 0)
                {
                    throw new ParametrosVaciosException("Alguno de los campos esta vacio");
                }
                if (this.cboxCargo.Text == "Operario")
                {
                    Operario operario = new Operario(this.txtBoxNombre.Text, this.txtBoxApellido.Text, 0, this.cboxCargo.Text, Operario.CasteoLong(this.txtBoxDNI.Text), this.txtBoxEmail.Text, Operario.CasteoInt(this.txtBoxEdad.Text), DateTime.Now, this.txtBoxDireccion.Text, this.txtBoxTelefono.Text);
                    if (!(operario.VerificarExisteOperario(OperarioDAO.LeerOperarios(), operario)))
                    {
                        if (OperarioDAO.GuardarRegistro(operario))
                        {
                            // podria probar de hacer una excepcion con un dato null
                            operario = OperarioDAO.LeerPorDNI(operario.DNI);
                            if (operario != null)
                            {
                                MessageBox.Show($"Código de Usuario generado: [{operario.ID}]", "Código Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MessageBox.Show("Se registro el Operario con Exito", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.lobby.Show();
                                this.Close();
                            }
                            else
                            {
                                throw new ObjetoNullException("Alguno de los campos esta vacio");
                            }
                        }
                    }
                }
                else if (this.cboxCargo.Text == "Supervisor")
                {
                    Supervisor supervisor = new Supervisor(this.txtBoxNombre.Text, this.txtBoxApellido.Text, 0, this.cboxCargo.Text, Operario.CasteoLong(this.txtBoxDNI.Text), this.txtBoxEmail.Text, Operario.CasteoInt(this.txtBoxEdad.Text), DateTime.Now, this.txtBoxDireccion.Text, this.txtBoxTelefono.Text);
                    if (!(supervisor.VerificarExisteSupervisor(SupervisorDAO.LeerSupervisores(), supervisor)))
                    {
                        if (SupervisorDAO.GuardarRegistro(supervisor))
                        {
                            // podria probar de hacer una excepcion con un dato null
                            supervisor = SupervisorDAO.LeerPorDNI(supervisor.DNI);
                            if (supervisor != null)
                            {
                                MessageBox.Show($"Código de Usuario generado: [{supervisor.ID}]", "Código Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MessageBox.Show("Se registro el Supervisor con Exito", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.lobby.Show();
                                this.Close();
                            }
                            else
                            {
                                throw new ObjetoNullException("Alguno de los campos esta vacio");
                            }
                        }
                    }
                }
            }
            catch (ParametrosVaciosException ex)
            {
                MessageBox.Show(ex.Message, "Parametros Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ObjetoNullException ex)
            {
                MessageBox.Show(ex.Message, "Objeto Null", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Tipo de dato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBackToLobby_Click(object sender, EventArgs e)
        {
            this.lobby.Show();
            this.Close();
        }

        private void BtnHardcodear_Click(object sender, EventArgs e)
        {

        }
    }
}
