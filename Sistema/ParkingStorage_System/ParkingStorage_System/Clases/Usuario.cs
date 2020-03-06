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
    }
}
