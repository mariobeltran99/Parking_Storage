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
    public partial class Home2 : Form
    {
        Clases.Conexion con = new Clases.Conexion();
        public Home2()
        {
            InitializeComponent();
            conteoCarnet();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            label15.Text = DateTime.Now.ToString("HH:mm:ss");
            label16.Text = DateTime.Now.ToLongDateString();
            conteoCarnet();
        }
        private void conteoCarnet()
        {
            try
            {
                con.inicioConnection();
                Clases.Carnet car = new Clases.Carnet();
                label7.Text = car.conteoCar().ToString();
                con.cerrarConnection();
            }
            catch (Exception)
            {

            }          
        } 
    }
}
