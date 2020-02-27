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
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }
        int posX = 0;
        int posY = 0;
        private void franja1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
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

        private void minize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            Alerta1 aler = new Alerta1();
            resultado = aler.ShowDialog();
            if(resultado == DialogResult.OK)
            {
                Login log = new Login();
                log.Show();
                this.Hide();             
            }
            else
            {
              
            }
        }
        private void closesesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            Alerta1 aler = new Alerta1();
            resultado = aler.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            else
            {

            }
        }
        private void AbrirFormenPanel<formulario>() where formulario : Form, new()
        {
            Form formulariohijo;
            formulariohijo = panelcontenedor.Controls.OfType<formulario>().FirstOrDefault();
            if(formulariohijo == null)
            {
                formulariohijo = new formulario();
                formulariohijo.TopLevel = false;
                formulariohijo.Dock = DockStyle.Fill;
                this.panelcontenedor.Controls.Add(formulariohijo);
                this.panelcontenedor.Tag = formulariohijo;
                formulariohijo.Show();
            }
            else
            {
                formulariohijo.BringToFront();
            }            
        }
        private void carnet_Click(object sender, EventArgs e)
        {
            AbrirFormenPanel<Carnets>();
        }

        private void users_Click(object sender, EventArgs e)
        {
            AbrirFormenPanel<Usuarios>();
        }

        private void space_Click(object sender, EventArgs e)
        {
            AbrirFormenPanel<Espacios>();
        }

        private void zone_Click(object sender, EventArgs e)
        {
            AbrirFormenPanel<Zonas>();
        }
    }
}
