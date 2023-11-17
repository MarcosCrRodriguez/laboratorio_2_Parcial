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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLobby
{
    public partial class FrmProcesos : Form
    {
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
            Queue<Task> tasks = new Queue<Task>();

            Task primerTask = new Task(() => IniciarProceso(this.progressBarSoldado, this.lblSoldado));
            Task segundoTask = new Task(() => IniciarProceso(this.progressBarEnsamblado, this.lblEnsamblado));
            Task tercerTask = new Task(() => IniciarProceso(this.progressBarConectado, this.lblConectado));
            Task cuartoTask = new Task(() => IniciarProceso(this.progressBarEmpaquetado, this.lblProcesoFinal));

            tasks.Enqueue(primerTask);
            tasks.Enqueue(segundoTask);
            tasks.Enqueue(tercerTask);
            tasks.Enqueue(cuartoTask);

            //Task.WaitAll(primerTask, segundoTask, tercerTask);

            foreach (Task item in tasks)
            {
                item.Start();
            }

            //Task primerTask = new Task(() => IniciarProceso(this.progressBarSoldado, this.lblSoldado));
            //Task segundoTask = new Task(() => IniciarProceso(this.progressBarEnsamblado, this.lblEnsamblado));
            //Task tercerTask = new Task(() => IniciarProceso(this.progressBarConectado, this.lblConectado));
            //primerTask.Start();
            //segundoTask.Start();
            //tercerTask.Start();

            //Task.WaitAll(primerTask, segundoTask, tercerTask);

            //Task cuartoTask = new Task(() => IniciarProceso(this.progressBarEmpaquetado, this.lblProcesoFinal));
            //cuartoTask.Start();

            //cuartoTask.Wait();

            //MessageBox.Show("Procesos finalizados", "Finish", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Close();
        }

        public void IniciarProceso(ProgressBar progressBar, Label label)
        {
            while (progressBar.Value < progressBar.Maximum)
            {
                Thread.Sleep(new Random().Next(this.cantidadFabricada / 2, this.cantidadFabricada));
                IncrementarBarraProgreso(progressBar, label, Task.CurrentId.Value);
            }
            FinalizarProceso(progressBar, label);
        }

        private void IncrementarBarraProgreso(ProgressBar progressBar, Label label, int IDHilo)
        {
            if (InvokeRequired)
            {
                Action<ProgressBar, Label, int> delegado = IncrementarBarraProgreso;
                object[] parametros = new object[] { progressBar, label, IDHilo };
                Invoke(delegado, parametros);
            }
            else
            {
                label.Text = $"Hilo N° {IDHilo} - {progressBar.Value}%";
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
                    label.Text = "FINALIZADO"; 
                }
            }
        }

    }
}
