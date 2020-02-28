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
        public Home()
        {
            InitializeComponent();
        }
        //fecha y hora
        private void horario_Tick(object sender, EventArgs e)
        {
            label15.Text = DateTime.Now.ToString("HH:mm:ss");
            label16.Text = DateTime.Now.ToLongDateString();
        }
    }
}
