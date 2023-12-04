using Archivos;
using Entidades;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace FrmLobby
{
    public partial class FrmProcesos : Form
    {
        CancellationTokenSource cancellationTokenSource;
        private Configuracion configJson;
        private List<Task> tasks;

        private int cantidadFabricada;
        private string path;
        private string pathJSON;
        public FrmProcesos(int cantidadFabricada)
        {
            InitializeComponent();
            this.cantidadFabricada = cantidadFabricada;
            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
            this.pathJSON = "Imagenes.json";
        }

        private void FrmProcesos_Load(object sender, EventArgs e)
        {
            this.btnCerrar.Visible = false;
            this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
            Image img = Image.FromFile(this.configJson.PathImagenCircuitoRojo);
            this.BackgroundImage = img;
            this.lblMessage.Text = "Trabajando en los procesos del producto...";
            this.lblMessage.ForeColor = Color.White;

            this.tasks = new List<Task>();
            IniciarHilos();
        }

        /// <summary>
        /// Iniciamos los hilos
        /// </summary>
        private void IniciarHilos()
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = this.cancellationTokenSource.Token;

            Task primerTask = Task.Run(() => IniciarProceso(this.progressBarSoldado, this.lblSoldado, "Soldado de piezas"), cancellationToken);
            Task segundoTask = Task.Run(() => IniciarProceso(this.progressBarEnsamblado, this.lblEnsamblado, "Ensamblado de piezas"), cancellationToken);
            Task tercerTask = Task.Run(() => IniciarProceso(this.progressBarConectado, this.lblConectado, "Conexion de componentes"), cancellationToken);

            this.tasks.Add(primerTask);
            this.tasks.Add(segundoTask);
            this.tasks.Add(tercerTask);

            Task.Run(() => Task.WaitAll(this.tasks.ToArray())).ContinueWith(_ =>
            {
                if (!cancellationTokenSource.IsCancellationRequested)
                {
                    Task cuartoTask = Task.Run(() => IniciarProceso(this.progressBarEmpaquetado, this.lblProcesoFinal, "Empaquedato del producto"), cancellationToken);
                    Task.Run(() => Task.WaitAll(cuartoTask)).ContinueWith(_ =>
                    {
                        MessageBox.Show("Procesos finalizados", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Asegurarse de cerrar el formulario en el hilo de la interfaz de usuario
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.Close();
                        });
                    });
                }
            });
        }

        /// <summary>
        /// Proceso en el que esta trabajando
        /// </summary>
        /// <param name="progressBar">Barra de progreso, porcentaje del progreso de proceso</param>
        /// <param name="label">Label donde se mostrara el proceso</param>
        /// <param name="proceso">Proceso que esta trabajando</param>
        public void IniciarProceso(ProgressBar progressBar, Label label, string proceso)
        {
            while (progressBar.Value < progressBar.Maximum
                && !cancellationTokenSource.IsCancellationRequested)
            {
                Thread.Sleep(new Random().Next(this.cantidadFabricada / 2, this.cantidadFabricada));
                IncrementarBarraProgreso(progressBar, label, proceso);
            }
            FinalizarProceso(progressBar, label);
        }

        /// <summary>
        /// Ingremento de la barra de progreso
        /// </summary>
        /// <param name="progressBar">Barra de progreso, porcentaje del progreso de proceso</param>
        /// <param name="label">Label donde se mostrara el proceso</param>
        /// <param name="proceso">Proceso que esta trabajando</param>
        private void IncrementarBarraProgreso(ProgressBar progressBar, Label label, string proceso)
        {
            if (InvokeRequired)
            {
                Action<ProgressBar, Label, string> delegado = IncrementarBarraProgreso;
                object[] parametros = new object[] { progressBar, label, proceso };
                Invoke(delegado, parametros);
            }
            else
            {
                label.Text = $"{proceso} - {progressBar.Value}%";
                progressBar.Increment(1);
            }
        }

        /// <summary>
        /// Cuando la barra de progreso llega hasta el límite
        /// </summary>
        /// <param name="progressBar">Barra finalizada / completada</param>
        /// <param name="label">Label donde muestra un mensaje</param>
        private void FinalizarProceso(ProgressBar progressBar, Label label)
        {
            if (InvokeRequired)
            {
                Action<ProgressBar, Label> delegado = FinalizarProceso;
                object[] parametros = new object[] { progressBar, label };
                Invoke(delegado, parametros);
            }
            else
            {
                if (progressBar.Value == progressBar.Maximum)
                {
                    label.Text = "FINALIZADO";
                }
                else
                {
                    label.Text = "CANCELADO";
                }
            }
        }

        /// <summary>
        /// Boton para cancelar el proceso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            this.btnCerrar.Visible = true;
            this.lblMessage.Text = "Procesos cancelados";
        }

        /// <summary>
        /// Boton para cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
