using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ParkingStorage_System.Clases
{
    class Secciones_Estacionamiento
    {
        private string id;
        private string nombre;
        private string descripcion;
        private string exid;
        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Exid { get => exid; set => exid = value; }
        //existe esa zona
        public int existeZona(string nombre, string descrip)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "INSERT INTO Secciones_estacion (nombre,descripcion) values (@p1,@p2)";
            comando.Connection = Clases.Conexion.connecSQL;
            if (obternerID(nombre) != 0)
            {
                return 0;
            }
            try
            {
                comando.Parameters.AddWithValue("@p1", nombre);
                comando.Parameters.AddWithValue("@p2", descrip);
                comando.ExecuteNonQuery();
                return obternerID(nombre);
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        //obtener id de la zona
        public int obternerID(string name)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Secciones_estacion WHERE nombre = @p1";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", name);
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
        //mostrar datos
        public List<Clases.Secciones_Estacionamiento> read()
        {
            List<Clases.Secciones_Estacionamiento> lista = new List<Clases.Secciones_Estacionamiento>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Secciones_estacion";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Secciones_Estacionamiento aux = new Clases.Secciones_Estacionamiento();
                    aux.exid = lector["id"].ToString();
                    aux.nombre = lector["nombre"].ToString();
                    aux.descripcion = lector["descripcion"].ToString();
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
        //actualizar la zona
        public bool actualizar(string nombre, string desc, string idx)
        {
            if (ver(nombre, idx))
            {

                String query = "UPDATE Secciones_estacion SET nombre = @p1, descripcion = @p2 WHERE id = @p3";
                SqlCommand comando = new SqlCommand();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;
                comando.Connection = Clases.Conexion.connecSQL;
                try
                {
                    comando.Parameters.AddWithValue("@p1", nombre);
                    comando.Parameters.AddWithValue("@p2", desc);
                    comando.Parameters.AddWithValue("@p3", idx);
                    comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
            else
            {
                return false;
            }
        }
        //ver si existe el dato
        private bool ver(string nombre, string idf)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Secciones_estacion where nombre = @p1 and id != @p2";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", nombre);
                comando.Parameters.AddWithValue("@p2", idf);
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    lector.Close();
                    return false;
                }
                else
                {
                    lector.Close();
                    return true;
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }
        //eliminar registro
        public int eliminar(string idx)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "DELETE Secciones_estacion WHERE id = @p1";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", idx);
                return comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        //buscar datos
        public List<Clases.Secciones_Estacionamiento> buscar(string datos)
        {
            List<Clases.Secciones_Estacionamiento> lista = new List<Clases.Secciones_Estacionamiento>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Secciones_estacion WHERE nombre LIKE '%' + @p1 + '%'";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", datos);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Secciones_Estacionamiento aux = new Clases.Secciones_Estacionamiento();
                    aux.exid = lector["id"].ToString();
                    aux.nombre = lector["nombre"].ToString();
                    aux.descripcion = lector["descripcion"].ToString();
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
        public int conteoZon()
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT COUNT(nombre) as dato FROM Secciones_estacion";
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
