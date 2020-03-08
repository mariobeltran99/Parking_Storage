﻿using System;
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
    public partial class Zonas : Form
    {
        DialogResult result = new DialogResult();
        AAdvertencia advert = new AAdvertencia();
        AError error = new AError();
        AInfo info = new AInfo();
        Alerta1 aler = new Alerta1();
        Clases.Conexion con = new Clases.Conexion();
        Clases.Secciones_Estacionamiento sec = new Clases.Secciones_Estacionamiento();
        List<Clases.Secciones_Estacionamiento> lista_secciones = new List<Clases.Secciones_Estacionamiento>();
        List<Clases.Secciones_Estacionamiento> lista_actual = new List<Clases.Secciones_Estacionamiento>();
        private int editar_indice = -1;
        private bool edicion = false;
        private int posicion = -1;
        public Zonas()
        {
            InitializeComponent();
            toolmensaje.SetToolTip(btneditar, "Haga doble click para seleccionar un registro y poder realizar las acciones");
            toolmensaje.SetToolTip(btneliminar, "Haga doble click para seleccionar un registro y poder realizar las acciones");
            actualizarTabla();
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            con.inicioConnection();
            try
            {
                if(string.IsNullOrEmpty(txtnombre.Text) || string.IsNullOrEmpty(txtdescripcion.Text))
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
                        Clases.Secciones_Estacionamiento st = lista_secciones[posicion];
                        st.Exid = Convert.ToString(st.obternerID(st.Nombre.ToString()));
                        if (sec.actualizar(txtnombre.Text.ToUpper(), txtdescripcion.Text, st.Exid))
                        {
                            info.label2.Text = "Zona Modificada Correctamente";
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
                            info.label2.Text = "Ya existe este zona \nIngrese otra zona";
                            result = info.ShowDialog();
                            info.pictureBox2.Image = Properties.Resources.info__1_;
                            if (result == DialogResult.OK)
                            {

                            }
                        }
                    }
                    else
                    {
                        sec.Nombre = txtnombre.Text.ToUpper();
                        sec.Descripcion = txtdescripcion.Text;
                        int bus = sec.existeZona(sec.Nombre, sec.Descripcion);
                        if (bus == 0)
                        {
                            info.label2.Text = "Ya existe esta zona, \nIngrese otra zona diferente";
                            result = info.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }
                            txtnombre.Clear();
                            txtnombre.Focus();
                        }
                        else
                        {
                            info.label2.Text = "Zona Registrada Correctamente";
                            info.pictureBox2.Image = Properties.Resources.check;
                            result = info.ShowDialog();
                            if (result == DialogResult.OK)
                            {

                            }
                            lista_actual.Add(sec);
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
            txtnombre.Clear();
            txtdescripcion.Clear();
            txtnombre.Focus();
        }
        private void actualizarTabla()
        {
            con.inicioConnection();
            dgvzonas.DataSource = null;           
            lista_secciones = sec.read();
            dgvzonas.DataSource = lista_secciones;
            dgvzonas.Columns["Exid"].Visible = false;
            dgvzonas.Columns["Id"].Visible = false;
            dgvzonas.Columns[1].HeaderText = "Nombre";
            dgvzonas.Columns[2].HeaderText = "Descripción";
            dgvzonas.Columns[1].Width = 230;
            dgvzonas.Columns[2].Width = 580;
            con.cerrarConnection();
        }
        private void mostraractualizaciones()
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

        private void dgvzonas_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow seleccion = dgvzonas.SelectedRows[0];
            posicion = dgvzonas.Rows.IndexOf(seleccion);
            editar_indice = posicion;
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (posicion != -1 && editar_indice != -1)
            {
                Clases.Secciones_Estacionamiento secc = lista_secciones[posicion];
                con.inicioConnection();
                aler.label2.Text = "¿Deseas editar este registro?";
                aler.pictureBox2.Image = Properties.Resources.question;
                result = aler.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtnombre.Text = secc.Nombre.ToString();
                    txtdescripcion.Text = secc.Descripcion.ToString();
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
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (posicion != -1 && editar_indice != -1)
            {
                Clases.Secciones_Estacionamiento us = lista_secciones[posicion];
                con.inicioConnection();
                aler.label2.Text = "¿Deseas eliminar este registro?\nTen en cuenta que no se podrá recuperar.";
                aler.pictureBox2.Image = Properties.Resources.question;
                result = aler.ShowDialog();
                if (result == DialogResult.OK)
                {
                    us.Exid = Convert.ToString(us.obternerID(us.Nombre.ToString()));
                    us.eliminar(us.Exid);
                    info.label2.Text = "Zona Eliminada Correctamente";
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

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if(txtbuscar.Text == "")
            {
                actualizarTabla();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            con.inicioConnection();
            try
            {
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
                    if (sec.buscar(txtbuscar.Text.ToString()) != null)
                    {
                        Clases.Secciones_Estacionamiento sat = new Clases.Secciones_Estacionamiento();
                        dgvzonas.DataSource = null;
                        lista_secciones = sat.buscar(txtbuscar.Text);
                        dgvzonas.DataSource = lista_secciones;
                        dgvzonas.Columns["Exid"].Visible = false;
                        dgvzonas.Columns["Id"].Visible = false;
                        dgvzonas.Columns[1].HeaderText = "Nombre";
                        dgvzonas.Columns[2].HeaderText = "Descripción";
                        dgvzonas.Columns[1].Width = 230;
                        dgvzonas.Columns[2].Width = 580;
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
    }
}
