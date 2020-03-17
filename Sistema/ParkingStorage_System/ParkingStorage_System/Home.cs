using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingStorage_System
{
    public partial class Home : Form
    {
        Clases.Conexion con = new Clases.Conexion();
        public Home()
        {
            InitializeComponent();
            conteo();
        }
        //fecha y hora
        private void horario_Tick(object sender, EventArgs e)
        {
            label15.Text = DateTime.Now.ToString("HH:mm:ss");
            label16.Text = DateTime.Now.ToLongDateString();
            conteo();
        }
        private void conteo()
        {
            try
            {
                con.inicioConnection();
                Clases.Carnet car = new Clases.Carnet();
                Clases.Estacionamiento est = new Clases.Estacionamiento();
                Clases.Secciones_Estacionamiento sec = new Clases.Secciones_Estacionamiento();
                Clases.Ticket tic = new Clases.Ticket();
                Usuario user = new Usuario();
                label7.Text = car.conteoCar().ToString();
                label8.Text = user.conteoUs().ToString();
                label9.Text = sec.conteoZon().ToString();
                label10.Text = est.conteoEs().ToString();
                label11.Text = tic.conteoTic().ToString();
                label12.Text = tic.conteoTicexpi().ToString();
                con.cerrarConnection();
            }
            catch (Exception)
            {

            }
        }
    }
}
