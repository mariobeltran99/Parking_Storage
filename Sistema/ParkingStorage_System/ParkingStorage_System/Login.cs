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
        AError error = new AError();
        AInfo info = new AInfo();       
        private bool ver = false;
        public Login()
        {
            InitializeComponent();
            toolmensaje.SetToolTip(mostrar1, "Click para ver la contraseña");
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
            Clases.Conexion con = new Clases.Conexion();
            Usuario users = new Usuario();
            Usuario aux = new Usuario();      
            con.inicioConnection();
            try
            {
                if(string.IsNullOrEmpty(username.Text) || string.IsNullOrEmpty(pass.Text))
                {
                    con.cerrarConnection();
                    advert.label2.Text = "Hay campos vacíos en el formulario, \npor favor rellene los campos solicitados";
                    result = advert.ShowDialog();
                    if (result == DialogResult.OK)
                    {

                    }                    
                }
                else
                {
                    if(users.loguear(username.Text, pass.Text) == true)
                    {
                        aux = users.ObtenerUsuario(int.Parse(users.Id));
                        if(aux.Estado == "True")
                        {
                            con.cerrarConnection();
                            info.label2.Text = "Usuario Correcto, Bienvenido " + username.Text;
                            result = info.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                Administrador admin = new Administrador();                            
                                
                                if (users != null)
                                {
                                    admin.lbladmin.Text = aux.Nombre;
                                }
                                else
                                {
                                    admin.lbladmin.Text = "";
                                }
                                admin.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            con.cerrarConnection();
                            info.label2.Text = "El usuario está desactivado,\nlo sentimos no puede acceder al sistema.\n Consulte con su Administrador de TI";                      
                            result = info.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }                          
                        }                       
                    }
                    else
                    {
                        con.cerrarConnection();
                        info.label2.Text = "Usuario Incorrecto, inténtelo de nuevo";
                        result = info.ShowDialog();
                        if(result == DialogResult.OK)
                        {

                        }                           
                    }
                }
            }
            catch (Exception)
            {
                con.cerrarConnection();
                error.label2.Text = "Ocurrió un error en la ejecución,\nvuelva a inténtarlo más tarde";
                result = error.ShowDialog();
                if (result == DialogResult.OK)
                {

                }              
            }
        }
        //mostrar contraseña
        private void mostrar1_Click(object sender, EventArgs e)
        {
            if (!ver)
            {
                ver = true;
                pass.PasswordChar = '\0';
                mostrar1.Image = Properties.Resources.powup;
            }
            else
            {
                ver = false;
                pass.PasswordChar = '*';
                mostrar1.Image = Properties.Resources.powoff;
            }
        }
    }
}
