using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using AForge.Video.DirectShow;

namespace EntradaParking
{
    public partial class Salida : Form
    {
        Clases.Conexion con = new Clases.Conexion();
        Clases.Tickets tic = new Clases.Tickets();
        private FilterInfoCollection dispositivos;
        //VARIABLE PARA FUENTE DE VIDEO
        private VideoCaptureDevice fuenteVideo;
        public Salida()
        {
            InitializeComponent();
            dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //CARGAR TODOS LOS DISPOSITIVOS AL COMBO
            foreach (FilterInfo x in dispositivos)
                cmbselectvi.Items.Add(x.Name);
            cmbselectvi.SelectedIndex = 0;
            fuenteVideo = new VideoCaptureDevice(dispositivos[cmbselectvi.SelectedIndex].MonikerString);
            //INICIALIZAR EL CONTROL
            videoSourcePlayer1.VideoSource = fuenteVideo;
            //INICIAR RECEPCION DE IMAGENES
            videoSourcePlayer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
            {
                //OBTENER IMAGEN DE LA WEBCAM
                Bitmap img = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                //UTILIZAR LA LIBRERIA Y LEER EL CÓDIGO
                BarcodeReader br = new BarcodeReader() { AutoRotate = true };
                Result resultados = br.Decode(img);
                //QUITAR LA IMAGEN DE MEMORIA
                img.Dispose();
                //OBTENER LAS LECTURAS CUANDO SE LEA ALGO
                if (resultados != null)
                {
                    try
                    {
                        con.inicioConnection();
                        string codemp = "";
                        codemp = resultados.ToString().Trim();
                        videoSourcePlayer1.SignalToStop();
                        timer1.Enabled = false;
                        videoSourcePlayer1.Visible = false;
                        int idst = tic.ObtenerComp4(codemp);
                        if (idst == 0)
                        {
                            int tsd = tic.ObtenerComp5(codemp);
                            if(tsd != 0)
                            {
                                
                            }
                            else
                            {
                                label1.Text = "*** El Código no existe ***";
                                timer2.Enabled = true;
                            }
                        }
                        else
                        {
                            label1.Text = "*** El Ticket ya expiró ***";
                            timer2.Enabled = true;
                        }
                        con.cerrarConnection();
                    }
                    catch (Exception)
                    {
                        label1.Text = "*** ERROR: Ocurrió un problema en la ejecución ***";
                        timer2.Enabled = true;
                    }
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer2.Stop();
                limpiar();
            }
        }
        private void limpiar()
        {
            label1.Text = "";
            label2.Text = "Coloque el código QR en el lector, por favor";
            videoSourcePlayer1.Visible = true;
            timer1.Enabled = true;
        }
    }
}
