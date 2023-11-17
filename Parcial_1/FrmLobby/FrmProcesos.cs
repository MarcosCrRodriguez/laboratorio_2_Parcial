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

namespace FrmLobby
{
    public partial class FrmProcesos : Form
    {
        //CancellationTokenSource cancellationTokenSource;
        private Configuracion configJson;
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
            this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
            Image img = Image.FromFile(this.configJson.PathImagenCircuitoRojo);
            this.BackgroundImage = img;

            IniciarHilos();
        }

        private void IniciarHilos()
        {
            List<Task> tasks = new List<Task>();

            Task primerTask = Task.Run(() => IniciarProceso(this.progressBarSoldado, this.lblSoldado, "Soldado de piezas"));
            Task segundoTask = Task.Run(() => IniciarProceso(this.progressBarEnsamblado, this.lblEnsamblado, "Ensamblado de piezas"));
            Task tercerTask = Task.Run(() => IniciarProceso(this.progressBarConectado, this.lblConectado, "Conexion de componentes"));

            tasks.Add(primerTask);
            tasks.Add(segundoTask);
            tasks.Add(tercerTask);

            Task.Run(() => Task.WaitAll(tasks.ToArray())).ContinueWith(_ =>
            {
                Task cuartoTask = Task.Run(() => IniciarProceso(this.progressBarEmpaquetado, this.lblProcesoFinal, "Empaquedato del producto"));
                Task.Run(() => Task.WaitAll(cuartoTask)).ContinueWith(_ =>
                {
                    MessageBox.Show("Procesos finalizados", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Asegurarse de cerrar el formulario en el hilo de la interfaz de usuario
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Close();
                    });
                });
            });
        }

        //private void IniciarHilos()
        //{
        //    this.cancellationTokenSource = new CancellationTokenSource();
        //    CancellationToken cancellationToken = this.cancellationTokenSource.Token;

        //    Task primerTask = new Task(() => IniciarProceso(this.progressBarSoldado, this.lblSoldado, "Soldado de piezas"));
        //    Task segundoTask = new Task(() => IniciarProceso(this.progressBarEnsamblado, this.lblEnsamblado, "Ensamblado de piezas"));
        //    Task tercerTask = new Task(() => IniciarProceso(this.progressBarConectado, this.lblConectado, "Conexion de componentes"));
        //    primerTask.Start();
        //    segundoTask.Start();
        //    tercerTask.Start();

        //    //Task.WaitAll(primerTask, segundoTask, tercerTask);

        //    Task cuartoTask = new Task(() => IniciarProceso(this.progressBarEmpaquetado, this.lblProcesoFinal, "Empaquedato del producto"), cancellationToken);
        //    cuartoTask.Start();

        //    //cuartoTask.Wait();

        //    //MessageBox.Show("Procesos finalizados", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //this.Close();
        //}

        public void IniciarProceso(ProgressBar progressBar, Label label, string proceso)
        {
            while (progressBar.Value < progressBar.Maximum)
            {
                Thread.Sleep(new Random().Next(this.cantidadFabricada / 2, this.cantidadFabricada));
                IncrementarBarraProgreso(progressBar, label, proceso);
            }
            FinalizarProceso(progressBar, label);
        }

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
                    label.Text = "PROCESO FINALIZADO";
                }
            }
        }

    }
}
