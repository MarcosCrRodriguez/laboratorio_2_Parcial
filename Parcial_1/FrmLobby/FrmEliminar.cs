﻿using Entidades;
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
    public partial class FrmEliminar : Form
    {
        public FrmEliminar()
        {
            InitializeComponent();
        }

        private void FrmEliminar_Load(object sender, EventArgs e)
        {

        }

        private void BtnDarBaja_Click(object sender, EventArgs e)
        {
            if (this.txtCodigoUsuario.Text == "" )
            {
                throw new ParametrosVaciosException("Alguno de los campos esta vacio - [ParametrosVaciosException]");
            }
            try
            {
                if (Operario.VerificarExisteID(OperarioDAO.LeerOperarios("Operario"), Convert.ToInt32(this.txtCodigoUsuario.Text)))
                {
                    DialogResult result = MessageBox.Show("¿Esta seguro que desea Dar De Baja a este Usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (SupervisorDAO.Eliminar(Convert.ToInt32(this.txtCodigoUsuario.Text), "Operario"))
                        {
                            MessageBox.Show("El Usuario se ha dado de baja correctamente", "Baja Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El Usuario no se encuentra en la DB\nO no puede dar de bajo ya que tiene un cargo igual o superior al suyo", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Usuario no se dio de baja", "Baja Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("El Usuario no se encuentra en la DB\nO no puede dar de bajo ya que tiene un cargo igual o superior al suyo", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBackMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
