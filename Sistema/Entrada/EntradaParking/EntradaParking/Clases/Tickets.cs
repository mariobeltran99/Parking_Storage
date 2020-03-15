using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ZXing;
using System.Drawing;
using System.IO;

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
        private byte[] imagen;
        public int Id { get => id; set => id = value; }
        public string NombreEmpleado { get => nombreEmpleado; set => nombreEmpleado = value; }
        public string CodigoEmpleado { get => codigoEmpleado; set => codigoEmpleado = value; }
        public string CodigoQR { get => codigoQR; set => codigoQR = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public string HoraSalida { get => horaSalida; set => horaSalida = value; }
        public string IdEstacion { get => idEstacion; set => idEstacion = value; }
        public string Estado { get => estado; set => estado = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }

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
                lb.Text = "*** No hay una conexión con el sistema ***";
                throw;
            }
        }
        //generar codigo
        public string generarCOD(string tipo, string sect)
        {
            Random num = new Random();
            string primerCarac = tipo.Substring(0,1).ToUpper();
            string secundCarac = sect.Substring(0,1).ToUpper();
            int correlativo = num.Next(10000000,99999999);
            string codigo = primerCarac + secundCarac + Convert.ToString(correlativo);
            return codigo;
        }
        //obtener las seccion del espacio disponible
        public string ObtenerSeccionDis(string tipo)
        {
            
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT TOP (1)  sec.nombre as 'seccion' FROM Estacion es INNER JOIN Secciones_estacion sec ON es.id_seccion = sec.id INNER JOIN Tipo_estacionamiento est ON es.id_tipo_estacion = est.id WHERE est.nombre = @p1 AND es.estado = 1";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", tipo);
                lector = comando.ExecuteReader();
                if(lector.Read())
                {
                    string nombsecc = lector["seccion"].ToString();
                    lector.Close();
                    return nombsecc;
                }
                else
                {
                    lector.Close();
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        //obtener el id 
        public string ObtenerIDEs(string tipo, string seccion)
        {

            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT TOP (1) es.id FROM Estacion es INNER JOIN Secciones_estacion sec ON es.id_seccion = sec.id INNER JOIN Tipo_estacionamiento est ON es.id_tipo_estacion = est.id WHERE est.nombre = @p1 AND es.estado = 1 AND sec.nombre = @p2";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", tipo);
                comando.Parameters.AddWithValue("@p2", seccion);
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    string dato;
                    dato = lector["id"].ToString();
                    lector.Close();
                    return dato;
                }
                else
                {
                    lector.Close();
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        //obtener el correlativo
        public string ObtenerCorrel(string tipo, string seccion,string ids)
        {

            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT TOP (1) es.correlativo FROM Estacion es INNER JOIN Secciones_estacion sec ON es.id_seccion = sec.id INNER JOIN Tipo_estacionamiento est ON es.id_tipo_estacion = est.id WHERE est.nombre = @p1 AND es.estado = 1 AND sec.nombre = @p2 AND es.id = @p3";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", tipo);
                comando.Parameters.AddWithValue("@p2", seccion);
                comando.Parameters.AddWithValue("@p3", ids);
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    string dato;
                    dato = lector["correlativo"].ToString();
                    lector.Close();
                    return dato;
                }
                else
                {
                    lector.Close();
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        //crear la imagen QR
        public bool CrearImg(string codec)
        {
            try
            {
                BarcodeWriter br = new BarcodeWriter();
                br.Format = BarcodeFormat.QR_CODE;
                Bitmap bm = new Bitmap(br.Write(codec), 300, 300);
                string dir = @"C:\Parking_Storage\TicketsQR\";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string dirimagen = @"C:\Parking_Storage\TicketsQR\" + codec + ".png";
                if (!File.Exists(dirimagen))
                {
                    bm.Save(dirimagen);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        //de imagen a bytes
        public byte[] Imgreg(string codtr)
        {
            string dirimagen = @"C:\Parking_Storage\TicketsQR\" + codtr + ".png";
            byte[] imgbyte = File.ReadAllBytes(dirimagen);
            return imgbyte;
        }
        //poner ocupado el estacionamiento
        public int ocupar(string idx, bool activar)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "UPDATE Estacion SET estado = @p1 WHERE id = @p2";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", activar);
                comando.Parameters.AddWithValue("@p2", idx);
                return comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        //ingresar el ticket
        public int crearTicket(string code, string fech, string horaen, string ide, byte[] img)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "INSERT INTO Ticket (cod_QR,fecha,hora_entrada,hora_salida,id_estacion,estado,img_QR) values (@p1,@p2,@p3,null,@p4,1,@p5)";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", code);
                comando.Parameters.AddWithValue("@p2", fech);
                comando.Parameters.AddWithValue("@p3", horaen);
                comando.Parameters.AddWithValue("@p4", ide);
                comando.Parameters.AddWithValue("@p5", img);
                return comando.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        //obtener id del carnet
        public int obternerID(string cod)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Ticket WHERE cod_QR = @p1";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", cod);
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
