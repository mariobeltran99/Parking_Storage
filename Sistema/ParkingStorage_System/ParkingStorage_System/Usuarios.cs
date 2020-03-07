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

namespace ParkingStorage_System
{
    public partial class Usuarios : Form
    {
        DialogResult result = new DialogResult();
        AAdvertencia advert = new AAdvertencia();
        AError error = new AError();
        AInfo info = new AInfo();
        Clases.Conexion con = new Clases.Conexion();
        Usuario users = new Usuario();
        List<Usuario> lista_usuario = new List<Usuario>();
        private int editar_indice = -1;
        private bool edicion = false;
        private bool ver = false;
        private bool ver1 = false;
        public Usuarios()
        {
            InitializeComponent();
            toolmensaje.SetToolTip(mostrar1, "Click para ver la contraseña");
            toolmensaje.SetToolTip(mostrar2, "Click para ver la contraseña");
            cmbtusuario.SelectedIndex = 0;
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) || char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
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

        private void mostrar1_Click(object sender, EventArgs e)
        {
            if (!ver)
            {
                ver = true;
                txtpassword.PasswordChar = '\0';
                
                mostrar1.Image = Properties.Resources.powup;
            }
            else
            {
                ver = false;
                txtpassword.PasswordChar = '*';
                mostrar1.Image = Properties.Resources.powoff;
            }
        }

        private void mostrar2_Click(object sender, EventArgs e)
        {
            if (!ver1)
            {
                ver1 = true;
                txtverificar.PasswordChar = '\0';              
                
                mostrar2.Image = Properties.Resources.powup;
            }
            else
            {
                ver1 = false;
                txtverificar.PasswordChar = '*';
                mostrar2.Image = Properties.Resources.powoff;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }
    }
}
