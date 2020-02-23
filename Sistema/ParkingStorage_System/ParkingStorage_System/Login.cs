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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //minimizar
        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //acerca de 
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {        
            Informacion info = new Informacion();
            info.Show();
            this.Hide();
        }
        //cerrar
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
