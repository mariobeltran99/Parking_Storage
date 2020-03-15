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

namespace EntradaParking
{
    public partial class Entrada : Form
    {
        Clases.Conexion con = new Clases.Conexion();
        Clases.Tickets tic = new Clases.Tickets();
        public Entrada()
        {
            InitializeComponent();
            cargarCombo();
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

                }
                else if (cmbselect.SelectedItem.ToString() == "No hay datos")
                {
                    label1.Text = "No hay datos para procesar en el sistema";
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
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            label1.Text = "*** Ya no hay estacionamientos disponibles ***";
                        }
                    }
                    else
                    {
                        label1.Text = "*** Ya no hay estacionamientos disponibles ***";
                    }
                }
                con.cerrarConnection();
            }
            catch (Exception)
            {
                label1.Text = "*** ERROR: Ocurrió un problema en la ejecución ***";
            }
            
        }
        private void limpiar()
        {
            label1.Visible = false;
        }
    }
}
