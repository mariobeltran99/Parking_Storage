using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PantallasExternas
{
    public partial class Form1 : Form
    {
        Clases.Conexion con = new Clases.Conexion();
        public Form1()
        {
            InitializeComponent();
            conteodisponible();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                conteodisponible();
            }
            catch (Exception)
            {
                label3.Text = "Error no se puede visualizar correctamente el dato";
            }
        }
        private void conteodisponible()
        {
            Clases.Estacionamiento est = new Clases.Estacionamiento();
            con.inicioConnection();
            int dat = est.conteoEs();
            con.cerrarConnection();
            if (dat == 0)
            {
                label2.Text = dat.ToString();
                label3.Text = "El parqueo está lleno";
            }
            else if (dat <= 10)
            {
                label2.Text = dat.ToString();
                label3.Text = "Hay pocos espacios disponibles";
            }
            else if (dat > 10)
            {
                label2.Text = dat.ToString();
                label3.Text = "Disponibles";
            }
        }
    }
}
