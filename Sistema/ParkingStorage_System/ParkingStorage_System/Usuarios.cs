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
        Alerta1 aler = new Alerta1();
        Clases.Conexion con = new Clases.Conexion();
        Usuario users = new Usuario();
        List<Usuario> lista_usuario = new List<Usuario>();
        List<Usuario> lista_actual = new List<Usuario>();
        private int editar_indice = -1;
        private bool edicion = false;
        private bool ver = false;
        private bool ver1 = false;
        private bool passw = false;
        private int posicion = -1;
        public Usuarios()
        {
            InitializeComponent();
            toolmensaje.SetToolTip(mostrar1, "Click para ver la contraseña");
            toolmensaje.SetToolTip(mostrar2, "Click para ver la contraseña");
            toolmensaje.SetToolTip(btneditar, "Haga doble click para seleccionar un registro y poder realizar las acciones");
            toolmensaje.SetToolTip(btndesactivar, "Haga doble click para seleccionar un registro y poder realizar las acciones");
            cmbtusuario.SelectedIndex = 0;
            actualizarTabla();
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
        private void limpiar()
        {
            txtnombre.Clear();
            txtusuario.Clear();
            txtpassword.Clear();
            txtverificar.Clear();
            txtnombre.Focus();
            cmbtusuario.SelectedIndex = 0;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            try
            {
                con.inicioConnection();
                if (string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtusuario.Text) || string.IsNullOrWhiteSpace(txtnombre.Text) || string.IsNullOrWhiteSpace(txtusuario.Text))
                {
                    advert.label2.Text = "Hay campos vacíos en el formulario,\npor favor rellene los campos";
                    result = advert.ShowDialog();
                    if (result == DialogResult.OK)
                    {

                    }
                }
                else
                {
                    if (edicion)
                    {
                        if (passw)
                        {
                            if(string.IsNullOrEmpty(txtpassword.Text) || string.IsNullOrEmpty(txtverificar.Text) || string.IsNullOrWhiteSpace(txtpassword.Text) || string.IsNullOrWhiteSpace(txtverificar.Text))
                            {
                                advert.label2.Text = "Hay campos vacíos en el formulario,\npor favor rellene los campos";
                                result = advert.ShowDialog();
                                if (result == DialogResult.OK)
                                {

                                }
                            }
                            else
                            {
                                if (txtpassword.Text == txtverificar.Text)
                                {
                                    Usuario st = lista_usuario[posicion];
                                    st.Exid = Convert.ToString(st.obternerID(st.NombreUsuario.ToString()));
                                    if (cmbtusuario.SelectedIndex == 0)
                                    {
                                        users.TipoUsuario = "A";
                                    }
                                    else
                                    {
                                        users.TipoUsuario = "S";
                                    }
                                    if (users.actualizar1(txtnombre.Text, txtusuario.Text, txtpassword.Text, users.TipoUsuario, st.Exid))
                                    {
                                        info.label2.Text = "Usuario Modificado Correctamente";
                                        info.pictureBox2.Image = Properties.Resources.check;
                                        result = info.ShowDialog();
                                        if (result == DialogResult.OK)
                                        {

                                        }
                                        btnRegistrar.Text = "Registrar";
                                        edicion = false;
                                        devolver();
                                        actualizarTabla();
                                        limpiar();
                                    }
                                    else
                                    {
                                        info.label2.Text = "Ya existe este usuario \nIngrese otro nombre de usuario";
                                        result = info.ShowDialog();
                                        info.pictureBox2.Image = Properties.Resources.info__1_;
                                        if (result == DialogResult.OK)
                                        {

                                        }
                                    }
                                }
                                else
                                {
                                    advert.label2.Text = "Las contraseñas no coinciden. \nVuelva a inténtarlo";
                                    result = advert.ShowDialog();
                                    if (result == DialogResult.OK)
                                    {

                                    }
                                    txtpassword.Clear();
                                    txtverificar.Clear();
                                    txtpassword.Focus();
                                }
                            }
                            
                        }
                        else
                        {
                            Usuario at = lista_usuario[posicion];
                            at.Exid = Convert.ToString(at.obternerID(at.NombreUsuario.ToString()));
                            if (cmbtusuario.SelectedIndex == 0)
                            {
                                users.TipoUsuario = "A";
                            }
                            else
                            {
                                users.TipoUsuario = "S";
                            }
                            if (users.actualizar2(txtnombre.Text, txtusuario.Text, users.TipoUsuario, at.Exid))
                            {
                                info.label2.Text = "Usuario Modificado Correctamente";
                                info.pictureBox2.Image = Properties.Resources.check;
                                result = info.ShowDialog();
                                if (result == DialogResult.OK)
                                {

                                }
                                btnRegistrar.Text = "Registrar";
                                edicion = false;
                                devolver();
                                actualizarTabla();
                                limpiar();
                            }
                            else
                            {
                                info.label2.Text = "Ya existe este usuario \nIngrese otro nombre de usuario";
                                result = info.ShowDialog();
                                info.pictureBox2.Image = Properties.Resources.info__1_;
                                if (result == DialogResult.OK)
                                {

                                }
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtpassword.Text) || string.IsNullOrEmpty(txtverificar.Text) || string.IsNullOrWhiteSpace(txtpassword.Text)|| string.IsNullOrWhiteSpace(txtverificar.Text))
                        {
                            advert.label2.Text = "Hay campos vacíos en el formulario,\npor favor rellene los campos";
                            result = advert.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }
                        }
                        else
                        {
                            if (txtpassword.Text == txtverificar.Text)
                            {
                                Usuario uster = new Usuario();
                                uster.Nombre = txtnombre.Text;
                                uster.NombreUsuario = txtusuario.Text;
                                uster.Contra = txtpassword.Text;
                                if (cmbtusuario.SelectedIndex == 0)
                                {
                                    uster.TipoUsuario = "A";
                                }
                                else
                                {
                                    uster.TipoUsuario = "S";
                                }
                                int busq = users.existeUsuario(uster.Nombre, uster.NombreUsuario, uster.Contra, uster.TipoUsuario);
                                //dato de la consulta
                                if (busq == 0)
                                {
                                    info.label2.Text = "Ya existe este usuario, \nIngrese otro nombre de usuario";
                                    result = info.ShowDialog();
                                    if (result == DialogResult.OK)
                                    {

                                    }
                                    txtusuario.Clear();
                                    txtusuario.Focus();
                                }
                                else
                                {
                                    info.label2.Text = "Usuario Registrado Correctamente";
                                    info.pictureBox2.Image = Properties.Resources.check;
                                    result = info.ShowDialog();
                                    if (result == DialogResult.OK)
                                    {

                                    }
                                    if (uster.TipoUsuario == "A")
                                    {
                                        uster.TipoUsuario = "Administrador";
                                    }
                                    else
                                    {
                                        uster.TipoUsuario = "Secretaria";
                                    }
                                    uster.Estado = "Activo";
                                    lista_actual.Add(uster);
                                    mostraractualizaciones();
                                    actualizarTabla();
                                    limpiar();
                                }
                            }
                            else
                            {
                                advert.label2.Text = "Las contraseñas no coinciden. \nVuelva a inténtarlo";
                                result = advert.ShowDialog();
                                if (result == DialogResult.OK)
                                {

                                }
                                txtpassword.Clear();
                                txtverificar.Clear();
                                txtpassword.Focus();
                            }
                        }                      
                    }
                }
                con.cerrarConnection();
            }
            catch (Exception)
            {
                error.label2.Text = "Ocurrió un error en la ejecución,\nvuelva a inténtarlo más tarde";
                result = error.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
            }       
        }
        private void mostraractualizaciones()
        {
            try
            {
                dgvactualizacion.DataSource = null;
                dgvactualizacion.DataSource = lista_actual;
                dgvactualizacion.Columns["Contra"].Visible = false;
                dgvactualizacion.Columns["Exid"].Visible = false;
                dgvactualizacion.Columns["Id"].Visible = false;
                dgvactualizacion.Columns[0].HeaderText = "Nombre";
                dgvactualizacion.Columns[1].HeaderText = "Nombre de Usuario";
                dgvactualizacion.Columns[3].HeaderText = "Tipo de Usuario";
                dgvactualizacion.Columns[4].HeaderText = "Estado";
                dgvactualizacion.Columns[0].Width = 230;
                dgvactualizacion.Columns[1].Width = 230;
                dgvactualizacion.Columns[3].Width = 230;
                dgvactualizacion.Columns[4].Width = 230;
            }
            catch (Exception)
            {
                error.label2.Text = "Ocurrió un error en la ejecución,\nvuelva a inténtarlo más tarde";
                result = error.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
            }          
        }
        private void actualizarTabla()
        {
            try
            {
                dgvusuarios.DataSource = null;
                con.inicioConnection();
                lista_usuario = users.read();
                dgvusuarios.DataSource = lista_usuario;
                dgvusuarios.Columns["Contra"].Visible = false;
                dgvusuarios.Columns["Exid"].Visible = false;
                dgvusuarios.Columns["Id"].Visible = false;
                dgvusuarios.Columns[0].HeaderText = "Nombre";
                dgvusuarios.Columns[1].HeaderText = "Nombre de Usuario";
                dgvusuarios.Columns[3].HeaderText = "Tipo de Usuario";
                dgvusuarios.Columns[4].HeaderText = "Estado";
                dgvusuarios.Columns[0].Width = 230;
                dgvusuarios.Columns[1].Width = 230;
                dgvusuarios.Columns[3].Width = 230;
                dgvusuarios.Columns[4].Width = 230;
                con.cerrarConnection();
            }
            catch (Exception)
            {
                error.label2.Text = "Ocurrió un error en la ejecución,\nvuelva a inténtarlo más tarde";
                result = error.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
            }
            
        }
        
        private void dgvusuarios_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow seleccion = dgvusuarios.SelectedRows[0];
            posicion = dgvusuarios.Rows.IndexOf(seleccion);
            editar_indice = posicion;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (posicion != -1 && editar_indice != -1)
                {
                    Usuario us = lista_usuario[posicion];
                    con.inicioConnection();
                    aler.label2.Text = "¿Deseas editar este registro?";
                    aler.pictureBox2.Image = Properties.Resources.question;
                    result = aler.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        aler.label2.Text = "¿Deseas cambia la contraseña?";
                        aler.pictureBox2.Image = Properties.Resources.question;
                        result = aler.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            txtnombre.Text = us.Nombre.ToString();
                            txtusuario.Text = us.NombreUsuario.ToString();
                            switch (us.TipoUsuario)
                            {
                                case "Administrador":
                                    cmbtusuario.SelectedIndex = 0;
                                    break;
                                case "Secretaria":
                                    cmbtusuario.SelectedIndex = 1;
                                    break;
                                default:
                                    break;
                            }

                            passw = true;
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            label4.Visible = false;
                            label7.Visible = false;
                            txtpassword.Visible = false;
                            txtverificar.Visible = false;
                            mostrar1.Visible = false;
                            mostrar2.Visible = false;
                            txtnombre.Text = us.Nombre.ToString();
                            txtusuario.Text = us.NombreUsuario.ToString();
                            switch (us.TipoUsuario)
                            {
                                case "Administrador":
                                    cmbtusuario.SelectedIndex = 0;
                                    break;
                                case "Secretaria":
                                    cmbtusuario.SelectedIndex = 1;
                                    break;
                                default:
                                    break;
                            }
                            passw = false;
                        }
                        edicion = true;
                        btnRegistrar.Text = "Modificar";
                        tabControl1.SelectedIndex = 0;
                        con.cerrarConnection();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        editar_indice = -1;
                        posicion = -1;
                    }
                }
                else
                {
                    advert.label2.Text = "Seleccione una fila con doble click.\nPara realizar la edición del registro";
                    result = advert.ShowDialog();
                    if (result == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception)
            {
                error.label2.Text = "Ocurrió un error en la ejecución,\nvuelva a inténtarlo más tarde";
                result = error.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
            }                
        }
        private void devolver()
        {
            label4.Visible = true;
            label7.Visible = true;
            txtpassword.Visible = true;
            txtverificar.Visible = true;
            mostrar1.Visible = true;
            mostrar2.Visible = true;
            info.pictureBox2.Image = Properties.Resources.info__1_;
            editar_indice = -1;
            posicion = -1;
        }

        private void btndesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (posicion != -1 && editar_indice != -1)
                {
                    Usuario us = lista_usuario[posicion];
                    con.inicioConnection();
                    if (us.Estado == "Activo")
                    {
                        aler.label2.Text = "¿Deseas desactivar este usuario?\nTen en cuenta que la siguiente sesión no se\npodrá acceder al sistema este usuario.";
                        aler.pictureBox2.Image = Properties.Resources.question;
                        result = aler.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            us.Id = Convert.ToString(users.obternerID(us.NombreUsuario.ToString()));
                            users.baja(us.Id, false);
                            info.label2.Text = "Usuario Desactivado Correctamente";
                            info.pictureBox2.Image = Properties.Resources.check;
                            result = info.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }
                            actualizarTabla();
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            editar_indice = -1;
                            posicion = -1;
                        }
                    }
                    else
                    {
                        aler.label2.Text = "¿Deseas activar este usuario?\nTen en cuenta que la siguiente sesión se\npodrá acceder al sistema este usuario.";
                        aler.pictureBox2.Image = Properties.Resources.question;
                        result = aler.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            us.Id = Convert.ToString(users.obternerID(us.NombreUsuario.ToString()));
                            users.baja(us.Id, true);
                            info.label2.Text = "Usuario Activado Correctamente";
                            info.pictureBox2.Image = Properties.Resources.check;
                            result = info.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }
                            actualizarTabla();
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            editar_indice = -1;
                            posicion = -1;
                        }
                    }
                    con.cerrarConnection();
                }
                else
                {
                    advert.label2.Text = "Seleccione una fila con doble click.\nPara realizar el cambio de estado del registro";
                    result = advert.ShowDialog();
                    if (result == DialogResult.OK)
                    {

                    }
                }
            }
            catch (Exception)
            {
                error.label2.Text = "Ocurrió un error en la ejecución,\nvuelva a inténtarlo más tarde";
                result = error.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
            }         
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            
            try
            {
                con.inicioConnection();
                if (string.IsNullOrEmpty(txtbuscar.Text) || string.IsNullOrWhiteSpace(txtbuscar.Text))
                {
                    advert.label2.Text = "Hay campos vacíos en la búsqueda";
                    result = advert.ShowDialog();
                    if (result == DialogResult.OK)
                    {

                    }
                    actualizarTabla();
                }
                else
                {
                    if (users.buscar(txtbuscar.Text.ToString()) != null)
                    {
                        Usuario sat = new Usuario();
                        dgvusuarios.DataSource = null;
                        lista_usuario = sat.buscar(txtbuscar.Text.ToString());
                        dgvusuarios.DataSource = lista_usuario;
                        dgvusuarios.Columns["Contra"].Visible = false;
                        dgvusuarios.Columns["Exid"].Visible = false;
                        dgvusuarios.Columns["Id"].Visible = false;
                        dgvusuarios.Columns[0].HeaderText = "Nombre";
                        dgvusuarios.Columns[1].HeaderText = "Nombre de Usuario";
                        dgvusuarios.Columns[3].HeaderText = "Tipo de Usuario";
                        dgvusuarios.Columns[4].HeaderText = "Estado";
                        dgvusuarios.Columns[0].Width = 230;
                        dgvusuarios.Columns[1].Width = 230;
                        dgvusuarios.Columns[3].Width = 230;
                        dgvusuarios.Columns[4].Width = 230;
                    }
                    else
                    {
                        info.label2.Text = "No hay registros de su búsqueda";
                        result = info.ShowDialog();
                        if (result == DialogResult.OK)
                        {

                        }
                        actualizarTabla();
                    }
                }
                con.cerrarConnection();
            }
            catch (Exception)
            {
                error.label2.Text = "Ocurrió un error en la ejecución,\nvuelva a inténtarlo más tarde";
                result = error.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
            }    
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if(txtbuscar.Text == "")
            {
                actualizarTabla();
            }              
        }
    }
}
