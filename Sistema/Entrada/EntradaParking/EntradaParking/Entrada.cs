using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ZXing;
using AForge.Video.DirectShow;

namespace EntradaParking
{
    public partial class Entrada : Form
    {
        Clases.Conexion con = new Clases.Conexion();
        Clases.Tickets tic = new Clases.Tickets();
        private FilterInfoCollection dispositivos;
        //VARIABLE PARA FUENTE DE VIDEO
        private VideoCaptureDevice fuenteVideo;
        public Entrada()
        {
            InitializeComponent();
            cargarCombo();
            dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //CARGAR TODOS LOS DISPOSITIVOS AL COMBO
            foreach (FilterInfo x in dispositivos)
                cmbselectvi.Items.Add(x.Name);
            cmbselectvi.SelectedIndex = 0;
        }
        private void cargarCombo()
        {
            try
            {
                con.inicioConnection();
                tic.cargarTEstacion(cmbselect, label1);
                con.cerrarConnection();
            }
            catch (Exception)
            {

            }            
        }

        private void next_Click(object sender, EventArgs e)
        {
            try
            {
                con.inicioConnection();
                if (cmbselect.SelectedItem.ToString() == "EMPLEADOS")
                {
                    timer1.Enabled = true;
                    timer1.Start();
                    //ESTABLECER EL DISPOSITIVO SELECCIONADO COMO FUENTE DE VIDEO
                    fuenteVideo = new VideoCaptureDevice(dispositivos[cmbselectvi.SelectedIndex].MonikerString);
                    //INICIALIZAR EL CONTROL
                    videoSourcePlayer1.VideoSource = fuenteVideo;
                    videoSourcePlayer1.Visible = true;
                    //INICIAR RECEPCION DE IMAGENES
                    videoSourcePlayer1.Start();
                    cmbselect.Visible = false;
                    next.Visible = false;
                    label2.Text = "Coloque el código QR cerca del lector, por favor";
                }
                else if (cmbselect.SelectedItem.ToString() == "No hay datos")
                {
                    label1.Text = "No hay datos para procesar en el sistema";
                    timer2.Enabled = true;
                }
                else if (cmbselect.SelectedItem.ToString() != "EMPLEADOS")
                {
                    Clases.Tickets ti = new Clases.Tickets();
                    string tipo = cmbselect.SelectedItem.ToString();
                    ti.Fecha = DateTime.Now.ToString("dd/MM/yyyy");
                    string seccion = tic.ObtenerSeccionDis(tipo);
                    if (seccion != null)
                    {
                        string ids = tic.ObtenerIDEs(tipo, seccion);
                        string secuencia = tic.ObtenerCorrel(tipo, seccion, ids);
                        if (ids != null && secuencia != null)
                        {
                            ti.HoraEntrada = DateTime.Now.ToString("HH:mm:ss");
                            ti.IdEstacion = ids;
                            ti.CodigoQR = tic.generarCOD(tipo, seccion);
                            if (tic.CrearImg(ti.CodigoQR))
                            {
                                ti.Imagen = tic.Imgreg(ti.CodigoQR);
                                tic.ocupar(ti.IdEstacion, false);
                                tic.crearTicket(ti.CodigoQR, ti.Fecha, ti.HoraEntrada, ti.IdEstacion, ti.Imagen);
                                ti.Id = tic.obternerID(ti.CodigoQR);
                                TicketsRep tickets = new TicketsRep();
                                tickets.SetParameterValue("@num", ti.Id);
                                string user = Environment.UserName.ToString();
                                string dir = @"C:\Users\" + user + @"\Documents\Parking_Storage\Tickets\";
                                if (!Directory.Exists(dir))
                                {
                                    Directory.CreateDirectory(dir);
                                }
                                tickets.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, dir + ti.CodigoQR + ".pdf");
                                label2.Text = "Ticket Generado Correctamente";
                                label3.Visible = true;
                                label3.Text = "Bienvenido, entre al parqueo";
                                cmbselect.Visible = false;
                                next.Visible = false;
                                timer2.Enabled = true;
                            }
                            else
                            {
                                timer2.Enabled = true;
                            }
                        }
                        else
                        {
                            label1.Text = "*** Ya no hay estacionamientos disponibles ***";
                            timer2.Enabled = true;
                        }
                    }
                    else
                    {
                        label1.Text = "*** Ya no hay estacionamientos disponibles ***";
                        timer2.Enabled = true;
                    }
                }
                con.cerrarConnection();
            }
            catch (Exception)
            {
                label1.Text = "*** ERROR: Ocurrió un problema en la ejecución ***";
                timer2.Enabled = true;
            }
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
            {
                //OBTENER IMAGEN DE LA WEBCAM
                Bitmap img = new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
                //UTILIZAR LA LIBRERIA Y LEER EL CÓDIGO
                BarcodeReader br = new BarcodeReader() { AutoRotate = true };
                Result resultados = br.Decode(img); ;
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
                        int idd = tic.ObtenerComp1(codemp);
                        if (idd != 0)
                        {
                            label2.Text = "Su carnet está inactivo\no puede acceder al parqueo";
                            timer2.Enabled = true;
                        }
                        else
                        {
                            int iddem = tic.ObtenerComp2(codemp);
                            if(iddem != 0)
                            {
                                //DETENER RECEPCION DE IMAGENES
                                Clases.Tickets ticd = new Clases.Tickets();
                                ticd.CodigoEmpleado = codemp;
                                string idem = tic.ObtenerIDEmple(ticd.CodigoEmpleado);
                                string tipo = cmbselect.SelectedItem.ToString();
                                ticd.Fecha = DateTime.Now.ToString("dd/MM/yyyy");
                                string seccion = tic.ObtenerSeccionDis(tipo);
                                if (seccion != null)
                                {
                                    string ids = tic.ObtenerIDEs(tipo, seccion);
                                    string secuencia = tic.ObtenerCorrel(tipo, seccion, ids);
                                    if (ids != null && secuencia != null)
                                    {
                                        ticd.HoraEntrada = DateTime.Now.ToString("HH:mm:ss");
                                        ticd.IdEstacion = ids;
                                        ticd.CodigoQR = tic.generarCOD(tipo, seccion);
                                        if (tic.CrearImg(ticd.CodigoQR))
                                        {
                                            ticd.Imagen = tic.Imgreg(ticd.CodigoQR);
                                            tic.ocupar(ticd.IdEstacion, false);
                                            tic.crearTicket(ticd.CodigoQR, ticd.Fecha, ticd.HoraEntrada, ticd.IdEstacion, ticd.Imagen);
                                            ticd.Id = tic.obternerID(ticd.CodigoQR);
                                            tic.crearDetalle(idem, Convert.ToString(ticd.Id));
                                            TicketsRep tickets = new TicketsRep();
                                            tickets.SetParameterValue("@num", ticd.Id);
                                            string user = Environment.UserName.ToString();
                                            string dir = @"C:\Users\" + user + @"\Documents\Parking_Storage\Tickets\";
                                            if (!Directory.Exists(dir))
                                            {
                                                Directory.CreateDirectory(dir);
                                            }
                                            tickets.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, dir + ticd.CodigoQR + ".pdf");
                                            label2.Text = "Ticket Generado Correctamente";
                                            label3.Visible = true;
                                            label3.Text = "Bienvenido, entre al parqueo";
                                            timer2.Enabled = true;
                                        }
                                        else
                                        {
                                            timer2.Enabled = true;
                                        }
                                    }
                                    else
                                    {
                                        label1.Text = "*** Ya no hay estacionamientos disponibles ***";
                                        timer2.Enabled = true;
                                    }
                                }
                                else
                                {
                                    label1.Text = "*** Ya no hay estacionamientos disponibles ***";
                                    timer2.Enabled = true;
                                }
                            }
                            else
                            {
                                label2.Text = "No existe ese carnet en el sistema\nNo puede acceder al parqueo";
                                timer2.Enabled = true;
                            }
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
                regresar();
                cargarCombo();
            }
        }
        private void regresar()
        {
            next.Visible = true;
            label3.Visible = false;
            cmbselect.Visible = true;
            label1.Text = "";
            label2.Text = "Seleccione el Tipo de Estacionamiento";
        }
    }
}
