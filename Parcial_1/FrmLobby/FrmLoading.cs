using Archivos;
using Entidades;
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
    public partial class FrmLoading : Form
    {
        private List<Task> tasks;
        private Configuracion configJson;

        private string path;
        private string pathJSON;
        public FrmLoading()
        {
            InitializeComponent();
            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
            this.pathJSON = "Imagenes.json";
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {
            this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
            Image img = Image.FromFile(this.configJson.PathGifLoading);
            pictureBox1.Image = img;
            this.tasks = new List<Task>();
            IniciarHilos();
        }

        /// <summary>
        /// Iniciamos el hilo 
        /// </summary>
        public void IniciarHilos()
        {
            Task primerTask = Task.Run(() => IniciarProceso());
            this.tasks.Add(primerTask);

            Task.Run(() => Task.WaitAll(this.tasks.ToArray())).ContinueWith(_ =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });
            });
        }

        /// <summary>
        /// Pausamos la ejecución del programa el tiempo que valga la variable "tiempo"
        /// </summary>
        public void IniciarProceso()
        {
            int tiempo = 2000;
            Thread.Sleep(tiempo);
        }
    }
}
