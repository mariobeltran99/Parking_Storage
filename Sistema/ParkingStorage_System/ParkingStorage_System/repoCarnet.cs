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
    public partial class repoCarnet : Form
    {
        carnets objcarts = new carnets();
        public repoCarnet()
        {
            InitializeComponent();
        }
        public string idcarnet;
        public string codpark;
        int posY = 0;
        int posX = 0;
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
        private void close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            string user = Environment.UserName.ToString();
            string dir = @"C:\Users\" + user + @"\Documents\Parking_Storage\Carnets\";
            objcarts.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, dir+codpark+".pdf");
            this.Hide();
        }

        private void repoCarnet_Load(object sender, EventArgs e)
        {           
            objcarts.SetParameterValue("@numer",idcarnet);
            crystalReportViewer1.ReportSource = objcarts;
        }
    }
}
