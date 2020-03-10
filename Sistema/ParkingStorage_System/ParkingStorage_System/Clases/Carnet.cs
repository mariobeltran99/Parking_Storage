using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ParkingStorage_System.Clases
{
    class Carnet
    {
        private int id;
        private string nombre;
        private string apellido;
        private string dui;
        private string fechaRegistro;
        private string fechaVencimiento;
        private string codigoParqueo;
        private string tipoTrabajador;
        private string estado;
        private byte[] imagen;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Dui { get => dui; set => dui = value; }
        public string FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public string FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public string CodigoParqueo { get => codigoParqueo; set => codigoParqueo = value; }
        public string TipoTrabajador { get => tipoTrabajador; set => tipoTrabajador = value; }
        public string Estado { get => estado; set => estado = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        //existe este carnet trabajador
        public int existeCarnet(string name, string ape, string duis,string fechaR,string fechaVe,string codpar,string tipot, byte[] img)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "INSERT INTO Carnet_trabajadores (nombre,apellido,dui,fecha_registro,fecha_vencimiento,cod_parqueo,tipo_trabajador,estado,imagen_cod) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,1,@p8)";
            comando.Connection = Clases.Conexion.connecSQL;
            if (obternerID(duis) != 0)
            {
                return 0;
            }
            try
            {
                comando.Parameters.AddWithValue("@p1", name);
                comando.Parameters.AddWithValue("@p2", ape);
                comando.Parameters.AddWithValue("@p3", duis);
                comando.Parameters.AddWithValue("@p4", fechaR);
                comando.Parameters.AddWithValue("@p5", fechaVe);
                comando.Parameters.AddWithValue("@p6", codpar);
                comando.Parameters.AddWithValue("@p7", tipot);
                comando.Parameters.AddWithValue("@p8", img);
                comando.ExecuteNonQuery();
                return obternerID(duis);
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        //obtener id carnet
        public int obternerID(string du)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Carnet_trabajadores WHERE dui = @p1";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", du);
                lectura = comando.ExecuteReader();
                if (lectura.Read())
                {
                    int a = Convert.ToInt32(lectura["id"]);
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
