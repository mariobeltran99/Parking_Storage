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
    public partial class TiposEspacios : Form
    {
        DialogResult result = new DialogResult();
        AAdvertencia advert = new AAdvertencia();
        AError error = new AError();
        AInfo info = new AInfo();
        Alerta1 aler = new Alerta1();
        Clases.Conexion con = new Clases.Conexion();
        Clases.Tipo_Estacionamiento type = new Clases.Tipo_Estacionamiento();
        List<Clases.Tipo_Estacionamiento> lista_tipos = new List<Clases.Tipo_Estacionamiento>();
        List<Clases.Tipo_Estacionamiento> lista_actual = new List<Clases.Tipo_Estacionamiento>();
        private int editar_indice = -1;
        private bool edicion = false;
        private int posicion = -1;
        public TiposEspacios()
        {
            InitializeComponent();
            toolmensaje.SetToolTip(btneditar, "Haga doble click para seleccionar un registro y poder realizar las acciones");
            toolmensaje.SetToolTip(btneliminar, "Haga doble click para seleccionar un registro y poder realizar las acciones");
            actualizarTabla();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
           
            try
            {
                con.inicioConnection();
                if (string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtdescripcion.Text))
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
                        Clases.Tipo_Estacionamiento st = lista_tipos[posicion];
                        st.Exid = Convert.ToString(st.obternerID(st.Nombre.ToString()));
                        if (type.actualizar(txtnombre.Text.ToUpper(), txtdescripcion.Text, st.Exid))
                        {
                            info.label2.Text = "Tipo de Estacionamiento \nModificado Correctamente";
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
                            info.label2.Text = "Ya existe este tipo de estacionamiento \nIngrese otro tipo de estacionamiento";
                            result = info.ShowDialog();
                            info.pictureBox2.Image = Properties.Resources.info__1_;
                            if (result == DialogResult.OK)
                            {

                            }
                        }
                    }
                    else
                    {
                        Clases.Tipo_Estacionamiento rt = new Clases.Tipo_Estacionamiento();
                        rt.Nombre = txtnombre.Text.ToUpper();
                        rt.Descripcion = txtdescripcion.Text;
                        int bus = type.existetipo(rt.Nombre, rt.Descripcion);
                        if (bus == 0)
                        {
                            info.label2.Text = "Ya existe este tipo de estacionamiento, \nIngrese otro tipo de estacionamiento";
                            info.pictureBox2.Image = Properties.Resources.info__1_;
                            result = info.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }
                            txtnombre.Clear();
                            txtnombre.Focus();
                        }
                        else
                        {
                            info.label2.Text = "Tipo de Estacionamiento \nRegistrado Correctamente";
                            info.pictureBox2.Image = Properties.Resources.check;
                            result = info.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }
                            lista_actual.Add(rt);
                            mostraractualizaciones();
                            actualizarTabla();
                            limpiar();
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
                    devolver();
                }
            }
            
        }
        private void limpiar()
        {
            txtnombre.Clear();
            txtdescripcion.Clear();
            txtnombre.Focus();
        }
        private void actualizarTabla()
        {
            try
            {
                con.inicioConnection();
                dgvtipos.DataSource = null;
                lista_tipos = type.read();
                dgvtipos.DataSource = lista_tipos;
                dgvtipos.Columns["Exid"].Visible = false;
                dgvtipos.Columns["Id"].Visible = false;
                dgvtipos.Columns[1].HeaderText = "Nombre";
                dgvtipos.Columns[2].HeaderText = "Descripción";
                dgvtipos.Columns[1].Width = 230;
                dgvtipos.Columns[2].Width = 580;
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
                dgvactual.DataSource = null;
                dgvactual.DataSource = lista_actual;
                dgvactual.Columns["Exid"].Visible = false;
                dgvactual.Columns["Id"].Visible = false;
                dgvactual.Columns[1].HeaderText = "Nombre";
                dgvactual.Columns[2].HeaderText = "Descripción";
                dgvactual.Columns[1].Width = 230;
                dgvactual.Columns[2].Width = 580;
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

        private void dgvtipos_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow seleccion = dgvtipos.SelectedRows[0];
            posicion = dgvtipos.Rows.IndexOf(seleccion);
            editar_indice = posicion;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (posicion != -1 && editar_indice != -1)
                {
                    Clases.Tipo_Estacionamiento ty = lista_tipos[posicion];
                    con.inicioConnection();
                    aler.label2.Text = "¿Deseas editar este registro?";
                    aler.pictureBox2.Image = Properties.Resources.question;
                    result = aler.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        txtnombre.Text = ty.Nombre.ToString();
                        txtdescripcion.Text = ty.Descripcion.ToString();
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
            posicion = -1;
            editar_indice = -1;
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (posicion != -1 && editar_indice != -1)
                {
                    Clases.Tipo_Estacionamiento us = lista_tipos[posicion];
                    con.inicioConnection();
                    aler.label2.Text = "¿Deseas eliminar este registro?\nTen en cuenta que no se podrá recuperar.";
                    aler.pictureBox2.Image = Properties.Resources.question;
                    result = aler.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        us.Exid = Convert.ToString(us.obternerID(us.Nombre.ToString()));
                        us.eliminar(us.Exid);
                        info.label2.Text = "Tipo de Estacionamiento \nEliminada Correctamente";
                        info.pictureBox2.Image = Properties.Resources.check;
                        result = info.ShowDialog();
                        if (result == DialogResult.OK)
                        {

                        }
                        actualizarTabla();
                        devolver();
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
                    advert.label2.Text = "Seleccione una fila con doble click.\nPara realizar la eliminación del registro";
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

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtbuscar.Text == "")
            {
                actualizarTabla();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            
            try
            {
                con.inicioConnection();
                if (string.IsNullOrEmpty(txtbuscar.Text))
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
                    if (type.buscar(txtbuscar.Text.ToString()) != null)
                    {
                        Clases.Tipo_Estacionamiento sat = new Clases.Tipo_Estacionamiento();
                        dgvtipos.DataSource = null;
                        lista_tipos = sat.buscar(txtbuscar.Text);
                        dgvtipos.DataSource = lista_tipos;
                        dgvtipos.Columns["Exid"].Visible = false;
                        dgvtipos.Columns["Id"].Visible = false;
                        dgvtipos.Columns[1].HeaderText = "Nombre";
                        dgvtipos.Columns[2].HeaderText = "Descripción";
                        dgvtipos.Columns[1].Width = 230;
                        dgvtipos.Columns[2].Width = 580;
                    }
                    else
                    {
                        info.label2.Text = "No hay registros de su búsqueda";
                        info.pictureBox2.Image = Properties.Resources.info__1_;
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
    }
}
