using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ZXing;

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
        private string exid;

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
        public string Exid { get => exid; set => exid = value; }

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
            comando.CommandText = "SELECT id FROM Carnet_trabajadores WHERE dui = @p1";
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
        //generar codigo de carnet
        public string CodCarnet(string nomb, string ape, string tipo)
        {
            string PrimerCarac = nomb.Substring(0, 1).ToUpper();
            string SegundCarac = ape.Substring(0, 1).ToUpper();
            string TercerCarac = tipo.Substring(0, 1).ToUpper();
            Random numer = new Random();
            int correlat = numer.Next(100000, 999999);
            string codigo = PrimerCarac + SegundCarac + TercerCarac + Convert.ToString(correlat);
            return codigo;
        }
        //generar la img con el cod
        public bool CrearImg(string codec)
        {
            try
            {
                BarcodeWriter br = new BarcodeWriter();
                br.Format = BarcodeFormat.QR_CODE;
                Bitmap bm = new Bitmap(br.Write(codec), 300, 300);
                string dir = @"C:\Parking_Storage\CarnetQR\";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string dirimagen = @"C:\Parking_Storage\CarnetQR\" + codec + ".png";
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
        //pasar la imagen a bytes
        public byte[] Imgreg(string codtr)
        {
            string dirimagen = @"C:\Parking_Storage\CarnetQR\" + codtr + ".png";
            byte[] imgbyte = File.ReadAllBytes(dirimagen);
            return imgbyte;           
        }
        //obtener fecha vencimiento
        public string feVenc()
        {
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string year = Convert.ToString((DateTime.Now.Year) + 1);
            return dia + "/" + mes + "/" + year;
        }
        //mostrar datos
        public List<Clases.Carnet> read()
        {
            List<Clases.Carnet> lista = new List<Clases.Carnet>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT id,nombre,apellido,dui,fecha_registro,fecha_vencimiento,cod_parqueo,tipo_trabajador,estado FROM Carnet_trabajadores";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Carnet aux = new Clases.Carnet();
                    aux.exid = lector["id"].ToString();
                    aux.nombre = lector["nombre"].ToString();
                    aux.apellido = lector["apellido"].ToString();
                    aux.dui = lector["dui"].ToString();
                    aux.fechaRegistro = lector["fecha_registro"].ToString();
                    aux.fechaVencimiento = lector["fecha_vencimiento"].ToString();
                    aux.codigoParqueo = lector["cod_parqueo"].ToString();
                    aux.tipoTrabajador = lector["tipo_trabajador"].ToString();
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Activo";
                    }
                    else
                    {
                        aux.estado = "Inactivo";
                    }
                    lista.Add(aux);
                }
                lector.Close();
                return lista;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        //actualizar el carnet
        public bool actualizar(string nomb, string ape, string tipo, string idx)
        {
                String query = "UPDATE Carnet_trabajadores SET nombre = @p1, apellido = @p2, tipo_trabajador = @p3 WHERE id = @p4";
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;
                comando.Connection = Clases.Conexion.connecSQL;
                try
                {
                    comando.Parameters.AddWithValue("@p1", nomb);
                    comando.Parameters.AddWithValue("@p2", ape);
                    comando.Parameters.AddWithValue("@p3", tipo);
                    comando.Parameters.AddWithValue("@p4", idx);
                    comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
        }
        //activar o desactivar carnet
        public int baja(string idx, bool activar)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "UPDATE Carnet_trabajadores SET estado = @p1 WHERE id = @p2";
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
        //buscar datos
        public List<Clases.Carnet> buscar(string datos)
        {
            List<Clases.Carnet> lista = new List<Clases.Carnet>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT id,nombre,apellido,dui,fecha_registro,fecha_vencimiento,cod_parqueo,tipo_trabajador,estado FROM Carnet_trabajadores WHERE nombre LIKE '%' + @p1 + '%' OR apellido LIKE '%' + @p1 + '%' OR cod_parqueo LIKE '%' + @p1 + '%'";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", datos);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Carnet aux = new Clases.Carnet();
                    aux.exid = lector["id"].ToString();
                    aux.nombre = lector["nombre"].ToString();
                    aux.apellido = lector["apellido"].ToString();
                    aux.dui = lector["dui"].ToString();
                    aux.fechaRegistro = lector["fecha_registro"].ToString();
                    aux.fechaVencimiento = lector["fecha_vencimiento"].ToString();
                    aux.codigoParqueo = lector["cod_parqueo"].ToString();
                    aux.tipoTrabajador = lector["tipo_trabajador"].ToString();
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Activo";
                    }
                    else
                    {
                        aux.estado = "Inactivo";
                    }
                    lista.Add(aux);
                }
                lector.Close();
                if (lista.Count == 0)
                {
                    return null;
                }
                else
                {
                    return lista;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
        //conteo de datos
        public int conteoCar()
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT COUNT(nombre) as dato FROM Carnet_trabajadores";
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
