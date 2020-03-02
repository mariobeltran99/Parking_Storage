using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ParkingStorage_System
{
    public partial class Login : Form
    {
        DialogResult result = new DialogResult();
        AAdvertencia advert = new AAdvertencia();
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
        int posX = 0;
        int posY = 0;
        private void franja1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }
        //evento del texbox
        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void ISesion_Click(object sender, EventArgs e)
        {

            try
            {
                advert.label2.Text = "Hay campos vacíos";
                result = advert.ShowDialog();
               if(result == DialogResult.OK)
               {

               }
            }
            catch (Exception)
            {

            }
        }
    }
}
