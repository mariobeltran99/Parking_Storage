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
        //mostrar datos
        public List<Usuario> read()
        {
            List<Usuario> lista = new List<Usuario>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT id,nombre,username,tipo_user,estado FROM Usuarios WHERE NOT username = 'admin'";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.exid = lector["id"].ToString();
                    aux.nombre = lector["nombre"].ToString();
                    aux.nombreUsuario = lector["username"].ToString();
                    if(lector["tipo_user"].ToString() == "A")
                    {
                        aux.tipoUsuario = "Administrador";
                    }
                    else
                    {
                        aux.tipoUsuario = "Secretaria";
                    }
                    if (lector["estado"].ToString() != "False")
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
        //ver si exite
        private bool ver(string nombre, string idf)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Usuarios where username = @p1 and id != @p2";
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
        //actualizar con contraseña
        public bool actualizar1(string nombre,string usuario, string contra,string tipouser, string idx)
        {
            if (ver(usuario, idx))
            {

                String query = "UPDATE Usuarios SET nombre = @p1, username = @p2, password = @p3, tipo_user = @p4 WHERE id = @p5";
                SqlCommand comando = new SqlCommand();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;
                comando.Connection = Clases.Conexion.connecSQL;
                try
                {
                    comando.Parameters.AddWithValue("@p1", nombre);
                    comando.Parameters.AddWithValue("@p2", usuario);
                    comando.Parameters.AddWithValue("@p3", validar.SHA256(contra));
                    comando.Parameters.AddWithValue("@p4", tipouser);
                    comando.Parameters.AddWithValue("@p5", idx);
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
        //actualizar sin contraseña
        public bool actualizar2(string nombre, string usuario, string tipouser, string idx)
        {
            if (ver(usuario, idx))
            {

                String query = "UPDATE Usuarios SET nombre = @p1, username = @p2, tipo_user = @p3 WHERE id = @p4";
                SqlCommand comando = new SqlCommand();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;
                comando.Connection = Clases.Conexion.connecSQL;
                try
                {
                    comando.Parameters.AddWithValue("@p1", nombre);
                    comando.Parameters.AddWithValue("@p2", usuario);
                    comando.Parameters.AddWithValue("@p3", tipouser);
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
            else
            {
                return false;
            }
        }
        //activar o desactivar usuario
        public int baja(string idx, bool activar)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "UPDATE Usuarios SET estado = @p1 WHERE id = @p2";
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
        public List<Usuario> buscar(string datos)
        {
            List<Usuario> lista = new List<Usuario>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT id,nombre,username,tipo_user,estado FROM Usuarios WHERE NOT username = 'admin' AND username LIKE '%'+ @p1 + '%' OR nombre LIKE '%' + @p1 + '%'";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", datos);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.exid = lector["id"].ToString();
                    aux.nombre = lector["nombre"].ToString();
                    aux.nombreUsuario = lector["username"].ToString();
                    if (lector["tipo_user"].ToString() == "A")
                    {
                        aux.tipoUsuario = "Administrador";
                    }
                    else
                    {
                        aux.tipoUsuario = "Secretaria";
                    }
                    if (lector["estado"].ToString() != "False")
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
                if(lista.Count == 0)
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
        public int conteoUs()
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT COUNT(username) as dato FROM Usuarios";
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
