using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntradaParking
{
    public partial class Entrada : Form
    {
        Clases.Conexion con = new Clases.Conexion();
        Clases.Tickets tic = new Clases.Tickets();
        public Entrada()
        {
            InitializeComponent();
            cargarCombo();
        }
        private void cargarCombo()
        {
            try
            {
                con.inicioConnection();
                tic.cargarTEstacion(cmbselect, label1);
                con.cerrarConnection();
            }
            catch (Exception)
            {

            }            
        }

        private void next_Click(object sender, EventArgs e)
        {
            if(cmbselect.SelectedItem.ToString() == "EMPLEADOS")
            {

            }
            else if(cmbselect.SelectedItem.ToString() == "No hay datos")
            {
                label1.Visible = true;
                label1.Text = "No hay datos para procesar en el sistema";
            }
            else if(cmbselect.SelectedItem.ToString() != "EMPLEADOS")
            {
                Clases.Tickets ti = new Clases.Tickets();

            }
        }
        private void limpiar()
        {
            label1.Visible = false;
        }
    }
}
