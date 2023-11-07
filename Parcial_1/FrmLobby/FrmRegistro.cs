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
        public FormularioRegistro()
        {
            InitializeComponent();
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
                if (this.txtBoxNombre.Text == "" || this.txtBoxApellido.Text == "" || this.txtBoxEdad.Text == "" || this.txtBoxEmail.Text == "" || this.txtBoxTelefono.Text == "" || this.txtBoxDNI.Text == "" || this.txtBoxDireccion.Text == "" || this.cboxCargo.Text == "")
                {
                    throw new ParametrosVaciosException("Alguno de los campos esta vacio - [ParametrosVaciosException]");
                }
                if (this.cboxCargo.Text == "Operario")
                {
                    Operario operario = new Operario(this.txtBoxNombre.Text, this.txtBoxApellido.Text, 0, this.cboxCargo.Text, Operario.CasteoLong(this.txtBoxDNI.Text), this.txtBoxEmail.Text, Operario.CasteoInt(this.txtBoxEdad.Text), this.monthCalendar.SelectionStart, this.txtBoxDireccion.Text, this.txtBoxTelefono.Text);
                    if (!(operario.VerificarExisteOperario(OperarioDAO.LeerOperarios("Operario"), operario)))
                    {
                        if (OperarioDAO.GuardarRegistro(operario))
                        {
                            operario = OperarioDAO.LeerPorDNI(operario.DNI);
                            if (operario != null)
                            {
                                MessageBox.Show($"Código de Usuario generado >{operario.ID}<", "Código Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MessageBox.Show("Se registro el Operario con Exito", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                throw new ObjetoNullException("No se pudieron cargar los datos al Usuario, no se puede trabajar con un dato tipo null - [ObjetoNullException]");
                            }
                        }
                    }
                }
                else if (this.cboxCargo.Text == "Supervisor")
                {
                    Supervisor supervisor = new Supervisor(this.txtBoxNombre.Text, this.txtBoxApellido.Text, 0, this.cboxCargo.Text, Operario.CasteoLong(this.txtBoxDNI.Text), this.txtBoxEmail.Text, Operario.CasteoInt(this.txtBoxEdad.Text), this.monthCalendar.SelectionStart, this.txtBoxDireccion.Text, this.txtBoxTelefono.Text);
                    if (!(supervisor.VerificarExisteSupervisor(SupervisorDAO.LeerSupervisores("Supervisor"), supervisor)))
                    {
                        if (SupervisorDAO.GuardarRegistro(supervisor))
                        {
                            supervisor = SupervisorDAO.LeerPorDNI(supervisor.DNI);
                            if (supervisor != null)
                            {
                                MessageBox.Show($"Código de Usuario generado >{supervisor.ID}<", "Código Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MessageBox.Show("Se registro el Supervisor con Exito", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                throw new ObjetoNullException("No se pudieron cargar los datos al Usuario, no se puede trabajar con un dato tipo null - [ObjetoNullException]");
                            }
                        }
                    }
                }
            }
            catch (ParametrosVaciosException ex)
            {
                MessageBox.Show(ex.Message, "Parametros Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Tipo de dato Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlExceptionDuplicateUserDB ex)
            {
                MessageBox.Show(ex.Message, "Problemas con la Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DataBasesException ex)
            {
                MessageBox.Show(ex.Message, "Parametros Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ObjetoNullException ex)
            {
                MessageBox.Show(ex.Message, "Objeto Null", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBackToLobby_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnHardcodear_Click(object sender, EventArgs e)
        {
            this.txtBoxNombre.Text = "Juan";
            this.txtBoxApellido.Text = "Carlos";
            this.txtBoxEdad.Text = new Random().Next(18, 60).ToString();
            this.txtBoxEmail.Text = "juancarlos@gmail.com";
            this.txtBoxTelefono.Text = $"{new Random().Next(1000, 9999)}-{new Random().Next(1000, 9999)}";
            this.txtBoxDNI.Text = new Random().Next(15000000, 45000000).ToString();
            this.monthCalendar.SelectionStart = DateTime.Now;
            this.txtBoxDireccion.Text = $"Calle None {new Random().Next(100, 7777)}";
            this.cboxCargo.Text = "Operario";
        }
    }
}
