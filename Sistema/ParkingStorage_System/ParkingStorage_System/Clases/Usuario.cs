using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ParkingStorage_System
{
    class Usuario
    {
        private string nombre;
        private string nombreUsuario;
        private string contra;
        private string tipoUsuario;
        private string estado;
        private string id;
        private string exid;
        public string Nombre { get => nombre; set => nombre = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contra { get => contra; set => contra = value; }
        public string TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Id { get => id; set => id = value; }
        public string Exid { get => exid; set => exid = value; }
        Clases.Validaciones validar = new Clases.Validaciones();
        //Iniciar sesion
        public bool loguear(string user, string contra)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Usuarios WHERE username = @p1 AND password = @p2";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", user);
                comando.Parameters.AddWithValue("@p2", validar.SHA256(contra));
                lectura = comando.ExecuteReader();
                if (lectura.Read())
                {
                    Id = lectura["id"].ToString();
                    lectura.Close();
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
        //Obtener el nombre de Usuario
        public Usuario ObtenerUsuario(int id)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            Usuario us = new Usuario();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Usuarios WHERE id = @p1";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", id);
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    us.exid = lector["id"].ToString();
                    us.nombre = lector["nombre"].ToString();
                    us.nombreUsuario = lector["username"].ToString();
                    us.tipoUsuario = lector["tipo_user"].ToString();                 
                    us.estado = lector["estado"].ToString();
                    lector.Close();
                    return us;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException)
            {
                return null;
            }
        }
        //verificar si existe el usuario
        public int existeUsuario(string nombre, string username, string pass, string tipoUser)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "INSERT INTO Usuarios(nombre,username,password,tipo_user,estado) values (@p1,@p2,@p3,@p4,1)";
            comando.Connection = Clases.Conexion.connecSQL;
            if (obternerID(username) != 0)
            {
                return 0;
            }
            try
            {
                comando.Parameters.AddWithValue("@p1", nombre);
                comando.Parameters.AddWithValue("@p2", username);
                comando.Parameters.AddWithValue("@p3", validar.SHA256(pass));
                comando.Parameters.AddWithValue("@p4", tipoUser);
                comando.ExecuteNonQuery();
                return obternerID(username);
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        //obtener el id del usuario a buscar
        public int obternerID(string user)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Usuarios WHERE username = @p1";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", user);
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
