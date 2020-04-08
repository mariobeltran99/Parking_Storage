using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PantallasExternas.Clases
{
    class Conexion
    {
        //cadena de conexion
        private string cadenaConecxion = PantallasExternas.Properties.Settings.Default.conec;
        public string CadenaConecxion { get => cadenaConecxion; set => cadenaConecxion = value; }
        public static SqlConnection connecSQL;
        //abrir conexion
        public bool inicioConnection()
        {
            try
            {
                connecSQL = new SqlConnection(this.cadenaConecxion);
                connecSQL.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //cerrar conexion
        public void cerrarConnection()
        {
            connecSQL.Close();
        }
        //estado de conexion
        public bool estadoConnection()
        {
            switch (connecSQL.State)
            {
                case ConnectionState.Broken:
                    return true;
                case ConnectionState.Open:
                    return true;
                default:
                    return false;
            }
        }
    }
}
