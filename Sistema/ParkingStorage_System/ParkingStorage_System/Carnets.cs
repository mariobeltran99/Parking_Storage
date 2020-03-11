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
    public partial class Carnets : Form
    {
        DialogResult result = new DialogResult();
        AAdvertencia advert = new AAdvertencia();
        AError error = new AError();
        AInfo info = new AInfo();
        Alerta1 aler = new Alerta1();
        Clases.Conexion con = new Clases.Conexion();
        Clases.Carnet cart = new Clases.Carnet();
        List<Clases.Carnet> lista_carnet = new List<Clases.Carnet>();
        List<Clases.Carnet> lista_actual = new List<Clases.Carnet>();
        private int editar_indice = -1;
        private bool edicion = false;
        private int posicion = -1;
        public Carnets()
        {
            InitializeComponent();
            cmbttrabajador.SelectedIndex = 0;
            toolmensaje.SetToolTip(btneditar, "Haga doble click para seleccionar un registro y poder realizar las acciones");
            toolmensaje.SetToolTip(btndescactivar, "Haga doble click para seleccionar un registro y poder realizar las acciones");
            actualizarTabla();
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        private void txtapellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtdui_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            con.inicioConnection();
            try
            {
                if (string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtapellido.Text))
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
                        Clases.Carnet st = lista_carnet[posicion];
                        st.Exid = Convert.ToString(st.obternerID(st.Dui.ToString()));
                        if (cart.actualizar(txtnombre.Text,txtapellido.Text,cmbttrabajador.SelectedItem.ToString(), st.Exid))
                        {
                            info.label2.Text = "Carnet Modificado Correctamente";
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
                            error.label2.Text = "Se generó un error en\nla ejecución de la consulta";
                            result = error.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }
                        }
                    }
                    else
                    {
                        Clases.Validaciones val = new Clases.Validaciones();
                        Clases.Carnet carn = new Clases.Carnet();
                        if (string.IsNullOrEmpty(txtdui.Text))
                        {
                            advert.label2.Text = "Hay campos vacíos en el formulario,\npor favor rellene los campos";
                            result = advert.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }
                        }
                        else
                        {
                            if (val.validacionDUI(txtdui.Text))
                            {
                                carn.Nombre = txtnombre.Text;
                                carn.Apellido = txtapellido.Text;
                                carn.Dui = txtdui.Text;
                                carn.TipoTrabajador = cmbttrabajador.SelectedItem.ToString();
                                carn.FechaRegistro = DateTime.Now.ToString("dd/MM/yyyy");
                                carn.FechaVencimiento = cart.feVenc();
                                carn.CodigoParqueo = cart.CodCarnet(carn.Nombre, carn.Apellido, carn.TipoTrabajador);
                                carn.Estado = "Activo";
                                if (cart.CrearImg(carn.CodigoParqueo))
                                {
                                    carn.Imagen = cart.Imgreg(carn.CodigoParqueo);
                                    int vef = cart.existeCarnet(carn.Nombre,carn.Apellido,carn.Dui,carn.FechaRegistro,carn.FechaVencimiento,carn.CodigoParqueo,carn.TipoTrabajador,carn.Imagen);
                                    if(vef == 0)
                                    {
                                        info.label2.Text = "Ya existe este DUI, \nRecuerde que el DUI es único";
                                        info.pictureBox2.Image = Properties.Resources.info__1_;
                                        result = info.ShowDialog();
                                        if (result == DialogResult.OK)
                                        {

                                        }
                                        txtdui.Clear();
                                        txtdui.Focus();
                                    }
                                    else
                                    {
                                        info.label2.Text = "Carnet Registrado Correctamente";
                                        info.pictureBox2.Image = Properties.Resources.check;
                                        result = info.ShowDialog();
                                        if (result == DialogResult.OK)
                                        {

                                        }
                                        lista_actual.Add(carn);
                                        mostraractualizaciones();
                                        actualizarTabla();
                                        limpiar();
                                    }
                                }
                                else
                                {
                                    advert.label2.Text = "No se pudo crear la imagen con el codigo QR";
                                    result = advert.ShowDialog();
                                    if (result == DialogResult.OK)
                                    {

                                    }
                                }
                            }
                            else
                            {
                                advert.label2.Text = "El DUI ingresado no es válido,\nTiene formato 00000000-0";
                                result = advert.ShowDialog();
                                if (result == DialogResult.OK)
                                {

                                }
                            }
                        }
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
            con.cerrarConnection();
        }
        private void limpiar()
        {
            txtnombre.Clear();
            txtapellido.Clear();
            txtdui.Clear();
            cmbttrabajador.SelectedIndex = 0;
            txtnombre.Focus();
        }
        private void actualizarTabla()
        {
            con.inicioConnection();
            dgvcarnet.DataSource = null;
            lista_carnet = cart.read();
            dgvcarnet.DataSource = lista_carnet;
            dgvcarnet.Columns["Exid"].Visible = false;
            dgvcarnet.Columns["Id"].Visible = false;
            dgvcarnet.Columns["Imagen"].Visible = false;
            dgvcarnet.Columns[1].HeaderText = "Nombre";
            dgvcarnet.Columns[2].HeaderText = "Apellido";
            dgvcarnet.Columns[3].HeaderText = "DUI";
            dgvcarnet.Columns[4].HeaderText = "Fecha de Registro";
            dgvcarnet.Columns[5].HeaderText = "Fecha de Vencimiento";
            dgvcarnet.Columns[6].HeaderText = "Código de Carnet";
            dgvcarnet.Columns[7].HeaderText = "Tipo de Trabajador";
            dgvcarnet.Columns[8].HeaderText = "Estado";
            dgvcarnet.Columns[1].Width = 230;
            dgvcarnet.Columns[2].Width = 230;
            dgvcarnet.Columns[3].Width = 230;
            dgvcarnet.Columns[4].Width = 230;
            dgvcarnet.Columns[5].Width = 230;
            dgvcarnet.Columns[6].Width = 230;
            dgvcarnet.Columns[7].Width = 230;
            dgvcarnet.Columns[8].Width = 230;
            con.cerrarConnection();
        }
        private void mostraractualizaciones()
        {
            dgvactual.DataSource = null;
            dgvactual.DataSource = lista_actual;
            dgvactual.Columns["Exid"].Visible = false;
            dgvactual.Columns["Id"].Visible = false;
            dgvactual.Columns["Imagen"].Visible = false;
            dgvactual.Columns[1].HeaderText = "Nombre";
            dgvactual.Columns[2].HeaderText = "Apellido";
            dgvactual.Columns[3].HeaderText = "DUI";
            dgvactual.Columns[4].HeaderText = "Fecha de Registro";
            dgvactual.Columns[5].HeaderText = "Fecha de Vencimiento";
            dgvactual.Columns[6].HeaderText = "Código de Carnet";
            dgvactual.Columns[7].HeaderText = "Tipo de Trabajador";
            dgvactual.Columns[8].HeaderText = "Estado";
            dgvactual.Columns[1].Width = 230;
            dgvactual.Columns[2].Width = 230;
            dgvactual.Columns[3].Width = 230;
            dgvactual.Columns[4].Width = 230;
            dgvactual.Columns[5].Width = 230;
            dgvactual.Columns[6].Width = 230;
            dgvactual.Columns[7].Width = 230;
            dgvactual.Columns[8].Width = 230;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (posicion != -1 && editar_indice != -1)
            {
                Clases.Carnet sta = lista_carnet[posicion];
                con.inicioConnection();
                aler.label2.Text = "¿Deseas editar este registro?";
                aler.pictureBox2.Image = Properties.Resources.question;
                result = aler.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtnombre.Text = sta.Nombre.ToString();
                    txtapellido.Text = sta.Apellido.ToString();
                    if(sta.TipoTrabajador.ToString() == "Empleado")
                    {
                        cmbttrabajador.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbttrabajador.SelectedIndex = 1;
                    }
                    txtdui.Visible = false;
                    label4.Visible = false;
                    edicion = true;
                    btnRegistrar.Text = "Modificar";
                    tabControl1.SelectedIndex = 0;
                }
                else if (result == DialogResult.Cancel)
                {
                    editar_indice = -1;
                    posicion = -1;
                }
                con.cerrarConnection();
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
        private void devolver()
        {
            posicion = -1;
            editar_indice = -1;
            label4.Visible = true;
            txtdui.Visible = true;
        }

        private void dgvcarnet_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow seleccion = dgvcarnet.SelectedRows[0];
            posicion = dgvcarnet.Rows.IndexOf(seleccion);
            editar_indice = posicion;
        }
    }
}
