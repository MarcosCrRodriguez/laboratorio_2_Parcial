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
    public partial class FrmGIF : Form
    {
        private List<Task> tasks;
        private Configuracion configJson;
        private string tipoGif;

        private string path;
        private string pathJSON;
        public FrmGIF(string tipoGif)
        {
            InitializeComponent();
            this.path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}";
            this.path += @"\Archivos\";
            this.pathJSON = "Imagenes.json";
            this.tipoGif = tipoGif;
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {
            this.CargaImagen();
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

        public void CargaImagen()
        {
            if (this.tipoGif == "loading")
            {
                this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
                Image img = Image.FromFile(this.configJson.PathGifLoading);
                this.pictureBox1.Image = img;
                this.Text = "Loading";

            }
            else if (this.tipoGif == "send")
            {
                this.configJson = ArchivosJSON<Configuracion>.LeerArchivo(this.path + this.pathJSON);
                Image img = Image.FromFile(this.configJson.PathGifEnviar);
                this.pictureBox1.Image = img;
                this.Text = "Send Materials";
            }
        }
    }
}
