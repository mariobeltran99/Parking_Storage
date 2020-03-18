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
        
        DialogResult result = new DialogResult();
        AAdvertencia advert = new AAdvertencia();
        AError error = new AError();
        AInfo info = new AInfo();
        Alerta1 aler = new Alerta1();
        repoCarnet rep = new repoCarnet();
        Clases.Conexion con = new Clases.Conexion();
        Clases.Ticket tick = new Clases.Ticket();
        List<Clases.Ticket> lista_all = new List<Clases.Ticket>();
        List<Clases.Ticket> lista_vig = new List<Clases.Ticket>();
        List<Clases.Ticket> lista_exp = new List<Clases.Ticket>();
        List<Clases.Ticket> lista_empvig = new List<Clases.Ticket>();
        List<Clases.Ticket> lista_empexp = new List<Clases.Ticket>();
        public Tickets()
        {
            InitializeComponent();
            cmbfilter.SelectedIndex = 0;
        }
        private void cmbfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbfilter.SelectedIndex == 0)
            {
                label3.Text = "Búsqueda por sección, tipo de estacionamiento, código de ticket y fecha";
                actualizarALL();
            }else if(cmbfilter.SelectedIndex == 1)
            {
                label3.Text = "Búsqueda por sección, tipo de estacionamiento, código de ticket y fecha";
                actualizarActivos();
            }else if(cmbfilter.SelectedIndex == 2)
            {
                label3.Text = "Búsqueda por sección, tipo de estacionamiento, código de ticket y fecha";
                actualizarExpirados();
            }else if(cmbfilter.SelectedIndex == 3)
            {
                label3.Text = "Búsqueda por nombre completo, fecha, código de empleado o ticket";
                actualizarActivosEmpleados();
            }else if(cmbfilter.SelectedIndex == 4)
            {
                label3.Text = "Búsqueda por nombre completo, fecha, código de empleado o ticket";
                actualizarExpiradosEmpleados();
            }
        }
        private void actualizarALL()
        {
            try
            {
                con.inicioConnection();
                dgvtickets.DataSource = null;
                lista_all = tick.readall();
                dgvtickets.DataSource = lista_all;
                dgvtickets.Columns["Id"].Visible = false;
                dgvtickets.Columns["NombreEmpleado"].Visible = false;
                dgvtickets.Columns["CodigoEmpleado"].Visible = false;
                dgvtickets.Columns[3].HeaderText = "Código de Ticket";
                dgvtickets.Columns[4].HeaderText = "Fecha";
                dgvtickets.Columns[5].HeaderText = "Hora de Entrada";
                dgvtickets.Columns[6].HeaderText = "Hora de Salida";
                dgvtickets.Columns[7].HeaderText = "Estado de Ticket";
                dgvtickets.Columns[8].HeaderText = "Estacionamiento";
                dgvtickets.Columns[9].HeaderText = "Tipo de Estacionamiento";
                dgvtickets.Columns[10].HeaderText = "Sección de Estacionamiento";
                dgvtickets.Columns[1].Width = 230;
                dgvtickets.Columns[2].Width = 230;
                dgvtickets.Columns[3].Width = 230;
                dgvtickets.Columns[4].Width = 230;
                dgvtickets.Columns[5].Width = 230;
                dgvtickets.Columns[6].Width = 230;
                dgvtickets.Columns[7].Width = 230;
                dgvtickets.Columns[8].Width = 230;
                dgvtickets.Columns[9].Width = 230;
                dgvtickets.Columns[10].Width = 230;
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
        private void actualizarActivos()
        {
            try
            {
                con.inicioConnection();
                dgvtickets.DataSource = null;
                lista_all = tick.readactivos();
                dgvtickets.DataSource = lista_all;
                dgvtickets.Columns["Id"].Visible = false;
                dgvtickets.Columns["NombreEmpleado"].Visible = false;
                dgvtickets.Columns["CodigoEmpleado"].Visible = false;
                dgvtickets.Columns[3].HeaderText = "Código de Ticket";
                dgvtickets.Columns[4].HeaderText = "Fecha";
                dgvtickets.Columns[5].HeaderText = "Hora de Entrada";
                dgvtickets.Columns[6].HeaderText = "Hora de Salida";
                dgvtickets.Columns[7].HeaderText = "Estado de Ticket";
                dgvtickets.Columns[8].HeaderText = "Estacionamiento";
                dgvtickets.Columns[9].HeaderText = "Tipo de Estacionamiento";
                dgvtickets.Columns[10].HeaderText = "Sección de Estacionamiento";
                dgvtickets.Columns[1].Width = 230;
                dgvtickets.Columns[2].Width = 230;
                dgvtickets.Columns[3].Width = 230;
                dgvtickets.Columns[4].Width = 230;
                dgvtickets.Columns[5].Width = 230;
                dgvtickets.Columns[6].Width = 230;
                dgvtickets.Columns[7].Width = 230;
                dgvtickets.Columns[8].Width = 230;
                dgvtickets.Columns[9].Width = 230;
                dgvtickets.Columns[10].Width = 230;
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
        private void actualizarExpirados()
        {
            try
            {
                con.inicioConnection();
                dgvtickets.DataSource = null;
                lista_all = tick.readexpi();
                dgvtickets.DataSource = lista_all;
                dgvtickets.Columns["Id"].Visible = false;
                dgvtickets.Columns["NombreEmpleado"].Visible = false;
                dgvtickets.Columns["CodigoEmpleado"].Visible = false;
                dgvtickets.Columns[3].HeaderText = "Código de Ticket";
                dgvtickets.Columns[4].HeaderText = "Fecha";
                dgvtickets.Columns[5].HeaderText = "Hora de Entrada";
                dgvtickets.Columns[6].HeaderText = "Hora de Salida";
                dgvtickets.Columns[7].HeaderText = "Estado de Ticket";
                dgvtickets.Columns[8].HeaderText = "Estacionamiento";
                dgvtickets.Columns[9].HeaderText = "Tipo de Estacionamiento";
                dgvtickets.Columns[10].HeaderText = "Sección de Estacionamiento";
                dgvtickets.Columns[1].Width = 230;
                dgvtickets.Columns[2].Width = 230;
                dgvtickets.Columns[3].Width = 230;
                dgvtickets.Columns[4].Width = 230;
                dgvtickets.Columns[5].Width = 230;
                dgvtickets.Columns[6].Width = 230;
                dgvtickets.Columns[7].Width = 230;
                dgvtickets.Columns[8].Width = 230;
                dgvtickets.Columns[9].Width = 230;
                dgvtickets.Columns[10].Width = 230;
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
        private void actualizarActivosEmpleados()
        {
            try
            {
                con.inicioConnection();
                dgvtickets.DataSource = null;
                lista_all = tick.readactivosEmp();
                dgvtickets.DataSource = lista_all;
                dgvtickets.Columns["Id"].Visible = false;
                dgvtickets.Columns[1].HeaderText = "Nombre Completo del Empleado";
                dgvtickets.Columns[2].HeaderText = "Código de Carnet de Empleado";
                dgvtickets.Columns[3].HeaderText = "Código de Ticket";
                dgvtickets.Columns[4].HeaderText = "Fecha";
                dgvtickets.Columns[5].HeaderText = "Hora de Entrada";
                dgvtickets.Columns[6].HeaderText = "Hora de Salida";
                dgvtickets.Columns[7].HeaderText = "Estado de Ticket";
                dgvtickets.Columns[8].HeaderText = "Estacionamiento";
                dgvtickets.Columns[9].HeaderText = "Tipo de Estacionamiento";
                dgvtickets.Columns[10].HeaderText = "Sección de Estacionamiento";
                dgvtickets.Columns[1].Width = 230;
                dgvtickets.Columns[2].Width = 230;
                dgvtickets.Columns[3].Width = 230;
                dgvtickets.Columns[4].Width = 230;
                dgvtickets.Columns[5].Width = 230;
                dgvtickets.Columns[6].Width = 230;
                dgvtickets.Columns[7].Width = 230;
                dgvtickets.Columns[8].Width = 230;
                dgvtickets.Columns[9].Width = 230;
                dgvtickets.Columns[10].Width = 230;
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
        private void actualizarExpiradosEmpleados()
        {
            try
            {
                con.inicioConnection();
                dgvtickets.DataSource = null;
                lista_all = tick.readexpiEmp();
                dgvtickets.DataSource = lista_all;
                dgvtickets.Columns["Id"].Visible = false;
                dgvtickets.Columns[1].HeaderText = "Nombre Completo del Empleado";
                dgvtickets.Columns[2].HeaderText = "Código de Carnet de Empleado";
                dgvtickets.Columns[3].HeaderText = "Código de Ticket";
                dgvtickets.Columns[4].HeaderText = "Fecha";
                dgvtickets.Columns[5].HeaderText = "Hora de Entrada";
                dgvtickets.Columns[6].HeaderText = "Hora de Salida";
                dgvtickets.Columns[7].HeaderText = "Estado de Ticket";
                dgvtickets.Columns[8].HeaderText = "Estacionamiento";
                dgvtickets.Columns[9].HeaderText = "Tipo de Estacionamiento";
                dgvtickets.Columns[10].HeaderText = "Sección de Estacionamiento";
                dgvtickets.Columns[1].Width = 230;
                dgvtickets.Columns[2].Width = 230;
                dgvtickets.Columns[3].Width = 230;
                dgvtickets.Columns[4].Width = 230;
                dgvtickets.Columns[5].Width = 230;
                dgvtickets.Columns[6].Width = 230;
                dgvtickets.Columns[7].Width = 230;
                dgvtickets.Columns[8].Width = 230;
                dgvtickets.Columns[9].Width = 230;
                dgvtickets.Columns[10].Width = 230;
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

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtbuscar.Text) || string.IsNullOrWhiteSpace(txtbuscar.Text))
            {
                advert.label2.Text = "Hay campos vacíos en la búsqueda";
                result = advert.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
            }
            else
            {
                if (cmbfilter.SelectedIndex == 0)
                {
                    actualizarALLBuscar(txtbuscar.Text);
                }
                else if (cmbfilter.SelectedIndex == 1)
                {
                    actualizarActivosBuscar(txtbuscar.Text);
                }
                else if (cmbfilter.SelectedIndex == 2)
                {
                    actualizarExpiradosBuscar(txtbuscar.Text);
                }
            }       
        }
        private void actualizarALLBuscar(string busqueda)
        {
            try
            {
                con.inicioConnection();
                dgvtickets.DataSource = null;
                lista_all = tick.readallbuscar(busqueda);
                dgvtickets.DataSource = lista_all;
                dgvtickets.Columns["Id"].Visible = false;
                dgvtickets.Columns["NombreEmpleado"].Visible = false;
                dgvtickets.Columns["CodigoEmpleado"].Visible = false;
                dgvtickets.Columns[3].HeaderText = "Código de Ticket";
                dgvtickets.Columns[4].HeaderText = "Fecha";
                dgvtickets.Columns[5].HeaderText = "Hora de Entrada";
                dgvtickets.Columns[6].HeaderText = "Hora de Salida";
                dgvtickets.Columns[7].HeaderText = "Estado de Ticket";
                dgvtickets.Columns[8].HeaderText = "Estacionamiento";
                dgvtickets.Columns[9].HeaderText = "Tipo de Estacionamiento";
                dgvtickets.Columns[10].HeaderText = "Sección de Estacionamiento";
                dgvtickets.Columns[1].Width = 230;
                dgvtickets.Columns[2].Width = 230;
                dgvtickets.Columns[3].Width = 230;
                dgvtickets.Columns[4].Width = 230;
                dgvtickets.Columns[5].Width = 230;
                dgvtickets.Columns[6].Width = 230;
                dgvtickets.Columns[7].Width = 230;
                dgvtickets.Columns[8].Width = 230;
                dgvtickets.Columns[9].Width = 230;
                dgvtickets.Columns[10].Width = 230;
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
        private void actualizarActivosBuscar(string busqueda)
        {
            try
            {
                con.inicioConnection();
                dgvtickets.DataSource = null;
                lista_all = tick.readactivosbuscar(busqueda);
                dgvtickets.DataSource = lista_all;
                dgvtickets.Columns["Id"].Visible = false;
                dgvtickets.Columns["NombreEmpleado"].Visible = false;
                dgvtickets.Columns["CodigoEmpleado"].Visible = false;
                dgvtickets.Columns[3].HeaderText = "Código de Ticket";
                dgvtickets.Columns[4].HeaderText = "Fecha";
                dgvtickets.Columns[5].HeaderText = "Hora de Entrada";
                dgvtickets.Columns[6].HeaderText = "Hora de Salida";
                dgvtickets.Columns[7].HeaderText = "Estado de Ticket";
                dgvtickets.Columns[8].HeaderText = "Estacionamiento";
                dgvtickets.Columns[9].HeaderText = "Tipo de Estacionamiento";
                dgvtickets.Columns[10].HeaderText = "Sección de Estacionamiento";
                dgvtickets.Columns[1].Width = 230;
                dgvtickets.Columns[2].Width = 230;
                dgvtickets.Columns[3].Width = 230;
                dgvtickets.Columns[4].Width = 230;
                dgvtickets.Columns[5].Width = 230;
                dgvtickets.Columns[6].Width = 230;
                dgvtickets.Columns[7].Width = 230;
                dgvtickets.Columns[8].Width = 230;
                dgvtickets.Columns[9].Width = 230;
                dgvtickets.Columns[10].Width = 230;
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
        private void actualizarExpiradosBuscar(string busqueda)
        {
            try
            {
                con.inicioConnection();
                dgvtickets.DataSource = null;
                lista_all = tick.readexpibuscar(busqueda);
                dgvtickets.DataSource = lista_all;
                dgvtickets.Columns["Id"].Visible = false;
                dgvtickets.Columns["NombreEmpleado"].Visible = false;
                dgvtickets.Columns["CodigoEmpleado"].Visible = false;
                dgvtickets.Columns[3].HeaderText = "Código de Ticket";
                dgvtickets.Columns[4].HeaderText = "Fecha";
                dgvtickets.Columns[5].HeaderText = "Hora de Entrada";
                dgvtickets.Columns[6].HeaderText = "Hora de Salida";
                dgvtickets.Columns[7].HeaderText = "Estado de Ticket";
                dgvtickets.Columns[8].HeaderText = "Estacionamiento";
                dgvtickets.Columns[9].HeaderText = "Tipo de Estacionamiento";
                dgvtickets.Columns[10].HeaderText = "Sección de Estacionamiento";
                dgvtickets.Columns[1].Width = 230;
                dgvtickets.Columns[2].Width = 230;
                dgvtickets.Columns[3].Width = 230;
                dgvtickets.Columns[4].Width = 230;
                dgvtickets.Columns[5].Width = 230;
                dgvtickets.Columns[6].Width = 230;
                dgvtickets.Columns[7].Width = 230;
                dgvtickets.Columns[8].Width = 230;
                dgvtickets.Columns[9].Width = 230;
                dgvtickets.Columns[10].Width = 230;
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
                if(cmbfilter.SelectedIndex == 0)
                {
                    actualizarALL();
                }else if(cmbfilter.SelectedIndex == 1)
                {
                    actualizarActivos();
                }else if(cmbfilter.SelectedIndex == 2)
                {
                    actualizarExpirados();
                }
            }
        }
    }
}
