using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EntradaParking.Clases
{
    class Tickets
    {
        private int id;
        private string nombreEmpleado;
        private string codigoEmpleado;
        private string codigoQR;
        private string fecha;
        private string horaEntrada;
        private string horaSalida;
        private string idEstacion;
        private string estado;
        private string imagen;
        public int Id { get => id; set => id = value; }
        public string NombreEmpleado { get => nombreEmpleado; set => nombreEmpleado = value; }
        public string CodigoEmpleado { get => codigoEmpleado; set => codigoEmpleado = value; }
        public string CodigoQR { get => codigoQR; set => codigoQR = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public string HoraSalida { get => horaSalida; set => horaSalida = value; }
        public string IdEstacion { get => idEstacion; set => idEstacion = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Imagen { get => imagen; set => imagen = value; }

        //para cargar el cmb de tipo estacionamiento
        public void cargarTEstacion(ComboBox cb, Label lb)
        {
            cb.Items.Clear();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Tipo_estacionamiento";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    cb.Items.Add(lector[1].ToString());
                }
                lector.Close();
                if (cb.Items.Count == 0)
                {
                    cb.Items.Insert(0, "No hay datos");
                    cb.SelectedIndex = 0;
                }
                else
                {
                    cb.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                lb.Visible = true;
                lb.Text = "*** No hay una conexión con el sistema ***";
                throw;
            }
        }
        public string generarCOD(string tipo, string sect)
        {
            Random num = new Random();
            string primerCarac = tipo.Substring(0,1).ToUpper();
            string secundCarac = sect.Substring(0,1).ToUpper();
            int correlativo = num.Next(10000000,99999999);
            string codigo = primerCarac + secundCarac + Convert.ToString(correlativo);
            return codigo;
        }


    }
}
