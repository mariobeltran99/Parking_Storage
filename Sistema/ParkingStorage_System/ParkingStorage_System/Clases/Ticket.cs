using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ParkingStorage_System.Clases
{
    class Ticket
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

        //conteo de tickets totales
        public int conteoTic()
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT COUNT(cod_QR) as dato FROM Ticket";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                lectura = comando.ExecuteReader();
                if (lectura.Read())
                {
                    int a = Convert.ToInt32(lectura["dato"]);
                    lectura.Close();
                    return a;
                }
                else
                {
                    lectura.Close();
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }

}
