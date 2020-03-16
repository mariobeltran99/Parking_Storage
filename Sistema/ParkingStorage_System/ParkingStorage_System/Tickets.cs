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
    public partial class Tickets : Form
    {

        public Tickets()
        {
            InitializeComponent();
            cmbfilter.SelectedIndex = 0;
        }

        private void cmbfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbfilter.SelectedIndex == 0)
            {
                label3.Text = "Búsqueda por sección y código de Ticket";
            }else if(cmbfilter.SelectedIndex == 1)
            {
                label3.Text = "Búsqueda por fecha y código de Ticket";
            }else if(cmbfilter.SelectedIndex == 2)
            {
                label3.Text = "Búsqueda por fecha y código de Ticket";
            }else if(cmbfilter.SelectedIndex == 3)
            {
                label3.Text = "Búsqueda por nombre, apellido, fecha, código de empleado o ticket";
            }else if(cmbfilter.SelectedIndex == 4)
            {
                label3.Text = "Búsqueda por nombre, apellido, fecha, código de empleado o ticket";
            }
        }

    }
}
