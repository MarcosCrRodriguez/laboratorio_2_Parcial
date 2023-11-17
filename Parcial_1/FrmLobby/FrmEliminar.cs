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
        public delegate void Mostrar(string texto, string titulo);

        private IArchivos<string> manejadorArchivosTXT;
        private Configuracion configJson;

        private string path;
        private string pathTXT;
        private string pathJSON;
        public FrmEliminar()
        {
            InitializeComponent();
            this.manejadorArchivosTXT = new ArchivosTXT<string>();

            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
            this.pathTXT = "Log_Excepciones.txt";
            this.pathJSON = "Imagenes.json";
        }

        private void FrmEliminar_Load(object sender, EventArgs e)
        {
            this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
            Image img = Image.FromFile(this.configJson.PathImagenCircuitoRojo);
            this.BackgroundImage = img;
        }

        private void BtnDarBaja_Click(object sender, EventArgs e)
        {
            Mostrar mostrarError = new Mostrar(FrmLobby.MostrarError);
            Mostrar mostrarInformacion = new Mostrar(FrmLobby.MostrarInformacion); 

            try
            {
                if (this.txtCodigoUsuario.Text == "")
                {
                    throw new EmptyParametersException("Alguno de los campos esta vacio - [ParametrosVaciosException]");
                }
                if (Operario.VerificarExisteID(OperarioDAO<Operario>.LeerOperarios("Operario"), Convert.ToInt32(this.txtCodigoUsuario.Text)))
                {
                    DialogResult result = MessageBox.Show("¿Esta seguro que desea Dar De Baja a este Usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        //evento1 += //metodo (Convert.ToInt32(this.txtCodigoUsuario.Text), "Operario"))
                        //evento1 += DB.Log(int, string)

                        if (SupervisorDAO<Supervisor>.Eliminar(Convert.ToInt32(this.txtCodigoUsuario.Text), "Operario"))
                        {
                            mostrarInformacion("El Usuario se ha dado de baja correctamente", "Baja Confirmada");
                            this.Close();
                        }
                        else
                        {
                            mostrarError("El Usuario no se encuentra en la base de datos\nO no puede dar de bajo ya que tiene un cargo igual o superior al suyo", "Usuario no encontrado");
                        }
                    }
                    else
                    {
                        mostrarInformacion("El Usuario no se dio de baja", "Baja Cancelada");
                    }
                }
                else
                {
                    mostrarError("El Usuario no se encuentra en la base de datos\nO no puede dar de bajo ya que tiene un cargo igual o superior al suyo", "Usuario no encontrado");
                }
            }
            catch (EmptyParametersException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("EmptyParametersException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Parametros Vacios");
            }
            catch (FormatException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("FormatException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Tipo de dato Incorrecto");
            }
            catch (DataBasesException ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("DataBasesException", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Error con DB");
            }
            catch (Exception ex)
            {
                this.manejadorArchivosTXT.EscribirArchivo(this.path + this.pathTXT, LogFormat.CrearFormatoExcepcion("Exception", $"{ex.StackTrace}"));
                mostrarError(ex.Message, "Error inesperado");
            }
        }

        private void BtnBackMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //metodo EliminarUsuario(int ID, string cargo)
        //{
        //  
        //}

    
    }
}
