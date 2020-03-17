using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ParkingStorage_System.Clases
{
    class Estacionamiento
    {
        private string id;
        private string correlativo;
        private string idSeccion;
        private string idEstacion;  
        private string estado;
        private string exid;
        public string Id { get => id; set => id = value; }
        public string Correlativo { get => correlativo; set => correlativo = value; }
        public string IdSeccion { get => idSeccion; set => idSeccion = value; }
        public string IdEstacion { get => idEstacion; set => idEstacion = value; }   
        public string Estado { get => estado; set => estado = value; }
        public string Exid { get => exid; set => exid = value; }
        AError error = new AError();
        DialogResult result = new DialogResult();
        //para cargar el cmb de tipo estacionamiento
        public void cargarTEstacion(ComboBox cb)
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
                error.label2.Text = "Ocurrió un error en la ejecución,\nvuelva a inténtarlo más tarde";
                result = error.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
                throw;
            }
        }
        //para cargar el cmb de secciones
        public void cargarSeccion(ComboBox cb)
        {
            cb.Items.Clear();
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
                error.label2.Text = "Ocurrió un error en la ejecución,\nvuelva a inténtarlo más tarde";
                result = error.ShowDialog();
                if (result == DialogResult.OK)
                {

                }
                throw;
            }
        }
        public int existeEstacion(string correla, string idsecc, string idest)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "INSERT INTO Estacion (correlativo,id_seccion,id_tipo_estacion,estado) values (@p1,@p2,@p3,1)";
            comando.Connection = Clases.Conexion.connecSQL;
            if (obternerID(correla) != 0)
            {
                return 0;
            }
            try
            {
                comando.Parameters.AddWithValue("@p1", correla);
                comando.Parameters.AddWithValue("@p2", idsecc);
                comando.Parameters.AddWithValue("@p3", idest);
                comando.ExecuteNonQuery();
                return obternerID(correla);
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        //obtener id de la estacion
        public int obternerID(string name)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT id FROM Estacion WHERE correlativo = @p1";
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
        public List<Clases.Estacionamiento> read()
        {
            List<Clases.Estacionamiento> lista = new List<Clases.Estacionamiento>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT es.id,es.correlativo, sec.nombre as 'seccion', est.nombre as 'tipo',es.estado as 'estado' FROM Estacion es INNER JOIN Secciones_estacion sec ON es.id_seccion = sec.id INNER JOIN Tipo_estacionamiento est ON es.id_tipo_estacion = est.id";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Estacionamiento aux = new Clases.Estacionamiento();
                    aux.exid = lector["id"].ToString();
                    aux.correlativo = lector["correlativo"].ToString();
                    aux.idSeccion = lector["seccion"].ToString();
                    aux.idEstacion = lector["tipo"].ToString();
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Disponible";
                    }
                    else
                    {
                        aux.estado = "Ocupado";
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
        //actualizar la estacion
        public bool actualizar(string nombre, string idx)
        {
            if (ver(nombre, idx))
            {
                String query = "UPDATE Estacion SET correlativo = @p1 WHERE id = @p2";
                SqlCommand comando = new SqlCommand();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;
                comando.Connection = Clases.Conexion.connecSQL;
                try
                {
                    comando.Parameters.AddWithValue("@p1", nombre);
                    comando.Parameters.AddWithValue("@p2", idx);
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
            comando.CommandText = "SELECT * FROM Estacion where correlativo = @p1 and id != @p2";
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
        //buscar datos
        public List<Clases.Estacionamiento> buscar(string datos)
        {
            List<Clases.Estacionamiento> lista = new List<Clases.Estacionamiento>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT es.id,es.correlativo, sec.nombre as 'seccion', est.nombre as 'tipo',es.estado as 'estado' FROM Estacion es INNER JOIN Secciones_estacion sec ON es.id_seccion = sec.id INNER JOIN Tipo_estacionamiento est ON es.id_tipo_estacion = est.id WHERE correlativo LIKE '%' + @p1 + '%'";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", datos);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Estacionamiento aux = new Clases.Estacionamiento();
                    aux.exid = lector["id"].ToString();
                    aux.correlativo = lector["correlativo"].ToString();
                    aux.idSeccion = lector["seccion"].ToString();
                    aux.idEstacion = lector["tipo"].ToString();
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Disponible";
                    }
                    else
                    {
                        aux.estado = "Ocupado";
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
        //eliminar registro
        public int eliminar(string idx)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "DELETE Estacion WHERE id = @p1";
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
        //conteo de datos
        public int conteoEs()
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT COUNT(correlativo) as dato FROM Estacion";
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
        // obtener id de eliminacion
        public string idsx(string name)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT id FROM Estacion WHERE correlativo = @p1";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", name);
                lectura = comando.ExecuteReader();
                if (lectura.Read())
                {
                    string a = lectura["id"].ToString();
                    lectura.Close();
                    return a;
                }
                else
                {
                    lectura.Close();
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
