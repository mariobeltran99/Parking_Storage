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
    public partial class Espacios : Form
    {
        DialogResult result = new DialogResult();
        AAdvertencia advert = new AAdvertencia();
        AError error = new AError();
        AInfo info = new AInfo();
        Alerta1 aler = new Alerta1();
        Clases.Conexion con = new Clases.Conexion();
        Clases.Estacionamiento estacion = new Clases.Estacionamiento();
        List<Clases.Estacionamiento> lista_estacion = new List<Clases.Estacionamiento>();
        List<Clases.Estacionamiento> lista_actual = new List<Clases.Estacionamiento>();
        private int editar_indice = -1;
        private bool edicion = false;
        private int posicion = -1;
        public Espacios()
        {
            InitializeComponent();
            cargarcombos();
            toolmensaje.SetToolTip(btneditar, "Haga doble click para seleccionar un registro y poder realizar las acciones");
            toolmensaje.SetToolTip(btneliminar, "Haga doble click para seleccionar un registro y poder realizar las acciones");
            actualizarTabla();
        }
        private void cargarcombos()
        {
            try
            {
                con.inicioConnection();
                estacion.cargarTEstacion(cmbtespacio);
                estacion.cargarSeccion(cmbseccion);
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            con.inicioConnection();
            try
            {
                if (string.IsNullOrEmpty(txtcorrelativo.Text) || cmbseccion.SelectedItem.ToString() == "No hay datos" || cmbtespacio.SelectedItem.ToString() == "No hay datos" || string.IsNullOrWhiteSpace(txtcorrelativo.Text))
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
                        Clases.Estacionamiento st = lista_estacion[posicion];
                        st.Exid = Convert.ToString(st.obternerID(st.Correlativo.ToString()));
                        if (estacion.actualizar(txtcorrelativo.Text, st.Exid))
                        {
                            info.label2.Text = "Estacionamiento Modificado Correctamente";
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
                            info.label2.Text = "Ya existe este estacionamiento \nIngrese otro estacionamiento diferente";
                            result = info.ShowDialog();
                            info.pictureBox2.Image = Properties.Resources.info__1_;
                            if (result == DialogResult.OK)
                            {

                            }
                        }
                    }
                    else
                    {
                        Clases.Estacionamiento rt = new Clases.Estacionamiento();
                        Clases.Secciones_Estacionamiento sect = new Clases.Secciones_Estacionamiento();
                        Clases.Tipo_Estacionamiento typ = new Clases.Tipo_Estacionamiento();
                        rt.Correlativo = txtcorrelativo.Text.ToUpper();
                        rt.IdEstacion = cmbtespacio.SelectedItem.ToString();
                        rt.IdSeccion = cmbseccion.SelectedItem.ToString();
                        rt.Estado = "Disponible";
                        string idsec = Convert.ToString(sect.obternerID(rt.IdSeccion));
                        string idest = Convert.ToString(typ.obternerID(rt.IdEstacion));
                        int bus = estacion.existeEstacion(rt.Correlativo, idsec,idest);
                        if (bus == 0)
                        {
                            info.label2.Text = "Ya existe este estacionamiento, \nIngrese otro estacionamiento diferente";
                            info.pictureBox2.Image = Properties.Resources.info__1_;
                            result = info.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }
                            txtcorrelativo.Clear();
                            txtcorrelativo.Focus();
                        }
                        else
                        {
                            info.label2.Text = "Estacionamiento Registrado Correctamente";
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
            txtcorrelativo.Clear();
            cargarcombos();
            cmbtespacio.Focus();
        }
        private void actualizarTabla()
        {
            try
            {
                con.inicioConnection();
                dgvespacios.DataSource = null;
                lista_estacion = estacion.read();
                dgvespacios.DataSource = lista_estacion;
                dgvespacios.Columns["Exid"].Visible = false;
                dgvespacios.Columns["Id"].Visible = false;
                dgvespacios.Columns[1].HeaderText = "Correlativo";
                dgvespacios.Columns[2].HeaderText = "Sección de Estacionamiento";
                dgvespacios.Columns[3].HeaderText = "Tipo de Estacionamiento";
                dgvespacios.Columns[4].HeaderText = "Estado";
                dgvespacios.Columns[1].Width = 230;
                dgvespacios.Columns[2].Width = 230;
                dgvespacios.Columns[3].Width = 230;
                dgvespacios.Columns[4].Width = 230;
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
                dgvactual.Columns[1].HeaderText = "Correlativo";
                dgvactual.Columns[2].HeaderText = "Sección de Estacionamiento";
                dgvactual.Columns[3].HeaderText = "Tipo de Estacionamiento";
                dgvactual.Columns[4].HeaderText = "Estado";
                dgvactual.Columns[1].Width = 230;
                dgvactual.Columns[2].Width = 230;
                dgvactual.Columns[3].Width = 230;
                dgvactual.Columns[4].Width = 230;
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
            label5.Visible = true;
            label2.Visible = true;
            cmbseccion.Visible = true;
            cmbtespacio.Visible = true;
        }

        private void dgvespacios_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow seleccion = dgvespacios.SelectedRows[0];
            posicion = dgvespacios.Rows.IndexOf(seleccion);
            editar_indice = posicion;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (posicion != -1 && editar_indice != -1)
                {
                    Clases.Estacionamiento sta = lista_estacion[posicion];
                    con.inicioConnection();
                    aler.label2.Text = "¿Deseas editar este registro?";
                    aler.pictureBox2.Image = Properties.Resources.question;
                    result = aler.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if(sta.Estado == "Ocupado")
                        {
                            advert.label2.Text = "No se puede editar el registro\nDebido a que está en uso el estacionamiento";
                            result = advert.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }
                            devolver();
                        }
                        else
                        {
                            txtcorrelativo.Text = sta.Correlativo.ToString();
                            edicion = true;
                            label5.Visible = false;
                            label2.Visible = false;
                            cmbseccion.Visible = false;
                            cmbtespacio.Visible = false;
                            btnRegistrar.Text = "Modificar";
                            tabControl1.SelectedIndex = 0;
                        }            
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

            }       
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if(txtbuscar.Text == "")
            {
                actualizarTabla();
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
                    if (estacion.buscar(txtbuscar.Text.ToString()) != null)
                    {
                        Clases.Estacionamiento sat = new Clases.Estacionamiento();
                        dgvespacios.DataSource = null;
                        lista_estacion = sat.buscar(txtbuscar.Text);
                        dgvespacios.DataSource = lista_estacion;
                        dgvespacios.Columns["Exid"].Visible = false;
                        dgvespacios.Columns["Id"].Visible = false;
                        dgvespacios.Columns[1].HeaderText = "Correlativo";
                        dgvespacios.Columns[2].HeaderText = "Sección de Estacionamiento";
                        dgvespacios.Columns[3].HeaderText = "Tipo de Estacionamiento";
                        dgvespacios.Columns[4].HeaderText = "Estado";
                        dgvespacios.Columns[1].Width = 230;
                        dgvespacios.Columns[2].Width = 230;
                        dgvespacios.Columns[3].Width = 230;
                        dgvespacios.Columns[4].Width = 230;
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

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (posicion != -1 && editar_indice != -1)
                {
                    Clases.Estacionamiento us = lista_estacion[posicion];                  
                    aler.label2.Text = "¿Deseas eliminar este registro?\nTen en cuenta que no se podrá recuperar.";
                    aler.pictureBox2.Image = Properties.Resources.question;
                    result = aler.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if(us.Estado == "Ocupado")
                        {
                            advert.label2.Text = "No se puede eliminar el registro\nDebido a que está en uso el estacionamiento";
                            result = advert.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }
                            devolver();
                        }
                        else
                        {
                            Clases.Estacionamiento gh = new Clases.Estacionamiento();
                            con.inicioConnection();
                            gh.Id = estacion.idsx(us.Correlativo);
                            estacion.eliminar(gh.Id);
                            con.cerrarConnection();
                            info.label2.Text = " Estacionamiento Eliminado Correctamente";
                            info.pictureBox2.Image = Properties.Resources.check;
                            result = info.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }
                            actualizarTabla();
                            devolver();
                        }
                       
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        editar_indice = -1;
                        posicion = -1;
                    }
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

        private void conteos_Tick(object sender, EventArgs e)
        {
            cargarcombos();
        }
    }
}
