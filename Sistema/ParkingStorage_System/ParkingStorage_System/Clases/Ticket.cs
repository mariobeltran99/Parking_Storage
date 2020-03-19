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
        private string estado;
        private string correlativo;
        private string tipo;
        private string seccion;
        public int Id { get => id; set => id = value; }
        public string NombreEmpleado { get => nombreEmpleado; set => nombreEmpleado = value; }
        public string CodigoEmpleado { get => codigoEmpleado; set => codigoEmpleado = value; }
        public string CodigoQR { get => codigoQR; set => codigoQR = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public string HoraSalida { get => horaSalida; set => horaSalida = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Correlativo { get => correlativo; set => correlativo = value; }  
        public string Tipo { get => tipo; set => tipo = value; }
        public string Seccion { get => seccion; set => seccion = value; }

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
        //conteo de tickets expirados
        public int conteoTicexpi()
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lectura;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT COUNT(cod_QR) as dato FROM Ticket WHERE estado = 0";
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
        //ver tickets
        public List<Clases.Ticket> readall()
        {
            List<Clases.Ticket> lista = new List<Clases.Ticket>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Ticket aux = new Clases.Ticket();
                    aux.codigoQR = lector["cod_QR"].ToString();
                    aux.fecha = lector["fecha"].ToString();
                    aux.horaEntrada = lector["hora_entrada"].ToString();
                    if (lector["hora_salida"].ToString() == "")
                    {
                        aux.horaSalida = "N/A";
                    }
                    else
                    {
                        aux.horaSalida = lector["hora_salida"].ToString();
                    }
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Vigente";
                    }
                    else
                    {
                        aux.estado = "Expirado";
                    }
                    aux.correlativo = lector["correlativo"].ToString();
                    aux.tipo = lector["tipo"].ToString();
                    aux.seccion = lector["seccion"].ToString();
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
        //ver tickets activos
        public List<Clases.Ticket> readactivos()
        {
            List<Clases.Ticket> lista = new List<Clases.Ticket>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id WHERE ti.estado = 1";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Ticket aux = new Clases.Ticket();
                    aux.codigoQR = lector["cod_QR"].ToString();
                    aux.fecha = lector["fecha"].ToString();
                    aux.horaEntrada = lector["hora_entrada"].ToString();
                    if (lector["hora_salida"].ToString() == "")
                    {
                        aux.horaSalida = "N/A";
                    }
                    else
                    {
                        aux.horaSalida = lector["hora_salida"].ToString();
                    }
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Vigente";
                    }
                    else
                    {
                        aux.estado = "Expirado";
                    }
                    aux.correlativo = lector["correlativo"].ToString();
                    aux.tipo = lector["tipo"].ToString();
                    aux.seccion = lector["seccion"].ToString();
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
        //ver tickets expirados
        public List<Clases.Ticket> readexpi()
        {
            List<Clases.Ticket> lista = new List<Clases.Ticket>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id WHERE ti.estado = 0";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Ticket aux = new Clases.Ticket();
                    aux.codigoQR = lector["cod_QR"].ToString();
                    aux.fecha = lector["fecha"].ToString();
                    aux.horaEntrada = lector["hora_entrada"].ToString();
                    if (lector["hora_salida"].ToString() == "")
                    {
                        aux.horaSalida = "N/A";
                    }
                    else
                    {
                        aux.horaSalida = lector["hora_salida"].ToString();
                    }
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Vigente";
                    }
                    else
                    {
                        aux.estado = "Expirado";
                    }
                    aux.correlativo = lector["correlativo"].ToString();
                    aux.tipo = lector["tipo"].ToString();
                    aux.seccion = lector["seccion"].ToString();
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
        //ver tickets activos de empleados
        public List<Clases.Ticket> readactivosEmp()
        {
            List<Clases.Ticket> lista = new List<Clases.Ticket>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT CONCAT(cart.nombre,' ',cart.apellido) as nombrecompleto,cart.cod_parqueo,ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id INNER JOIN Detalle_ticket_trabajador det ON ti.id = det.id_ticket INNER JOIN Carnet_trabajadores cart ON det.id_trabajador = cart.id WHERE ti.estado = 1";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Ticket aux = new Clases.Ticket();
                    aux.nombreEmpleado = lector["nombrecompleto"].ToString();
                    aux.codigoEmpleado = lector["cod_parqueo"].ToString();
                    aux.codigoQR = lector["cod_QR"].ToString();
                    aux.fecha = lector["fecha"].ToString();
                    aux.horaEntrada = lector["hora_entrada"].ToString();
                    if (lector["hora_salida"].ToString() == "")
                    {
                        aux.horaSalida = "N/A";
                    }
                    else
                    {
                        aux.horaSalida = lector["hora_salida"].ToString();
                    }
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Vigente";
                    }
                    else
                    {
                        aux.estado = "Expirado";
                    }
                    aux.correlativo = lector["correlativo"].ToString();
                    aux.tipo = lector["tipo"].ToString();
                    aux.seccion = lector["seccion"].ToString();
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
        //ver tickets expirados de empleados
        public List<Clases.Ticket> readexpiEmp()
        {
            List<Clases.Ticket> lista = new List<Clases.Ticket>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT CONCAT(cart.nombre,' ',cart.apellido) as nombrecompleto,cart.cod_parqueo,ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id INNER JOIN Detalle_ticket_trabajador det ON ti.id = det.id_ticket INNER JOIN Carnet_trabajadores cart ON det.id_trabajador = cart.id WHERE ti.estado = 0";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Ticket aux = new Clases.Ticket();
                    aux.nombreEmpleado = lector["nombrecompleto"].ToString();
                    aux.codigoEmpleado = lector["cod_parqueo"].ToString();
                    aux.codigoQR = lector["cod_QR"].ToString();
                    aux.fecha = lector["fecha"].ToString();
                    aux.horaEntrada = lector["hora_entrada"].ToString();
                    if (lector["hora_salida"].ToString() == "")
                    {
                        aux.horaSalida = "N/A";
                    }
                    else
                    {
                        aux.horaSalida = lector["hora_salida"].ToString();
                    }
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Vigente";
                    }
                    else
                    {
                        aux.estado = "Expirado";
                    }
                    aux.correlativo = lector["correlativo"].ToString();
                    aux.tipo = lector["tipo"].ToString();
                    aux.seccion = lector["seccion"].ToString();
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
        //buscar tickets general
        public List<Clases.Ticket> readallbuscar(string dato)
        {
            List<Clases.Ticket> lista = new List<Clases.Ticket>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id WHERE ty.nombre LIKE '%' + @p1 + '%' OR sec.nombre LIKE '%' + @p1 + '%' OR ti.fecha LIKE '%' + @p1 + '%' OR ti.cod_QR LIKE '%' + @p1 + '%'";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", dato);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Ticket aux = new Clases.Ticket();
                    aux.codigoQR = lector["cod_QR"].ToString();
                    aux.fecha = lector["fecha"].ToString();
                    aux.horaEntrada = lector["hora_entrada"].ToString();
                    if (lector["hora_salida"].ToString() == "")
                    {
                        aux.horaSalida = "N/A";
                    }
                    else
                    {
                        aux.horaSalida = lector["hora_salida"].ToString();
                    }
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Vigente";
                    }
                    else
                    {
                        aux.estado = "Expirado";
                    }
                    aux.correlativo = lector["correlativo"].ToString();
                    aux.tipo = lector["tipo"].ToString();
                    aux.seccion = lector["seccion"].ToString();
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
        //buscar tickets activos
        public List<Clases.Ticket> readactivosbuscar(string dato)
        {
            List<Clases.Ticket> lista = new List<Clases.Ticket>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id WHERE ti.estado = 1 AND ty.nombre LIKE '%' + @p1 + '%' OR sec.nombre LIKE '%' + @p1 + '%' OR ti.fecha LIKE '%' + @p1 + '%' OR ti.cod_QR LIKE '%' + @p1 + '%'";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", dato);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Ticket aux = new Clases.Ticket();
                    aux.codigoQR = lector["cod_QR"].ToString();
                    aux.fecha = lector["fecha"].ToString();
                    aux.horaEntrada = lector["hora_entrada"].ToString();
                    if (lector["hora_salida"].ToString() == "")
                    {
                        aux.horaSalida = "N/A";
                    }
                    else
                    {
                        aux.horaSalida = lector["hora_salida"].ToString();
                    }
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Vigente";
                    }
                    else
                    {
                        aux.estado = "Expirado";
                    }
                    aux.correlativo = lector["correlativo"].ToString();
                    aux.tipo = lector["tipo"].ToString();
                    aux.seccion = lector["seccion"].ToString();
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
        //ver tickets expirados
        public List<Clases.Ticket> readexpibuscar(string dato)
        {
            List<Clases.Ticket> lista = new List<Clases.Ticket>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id WHERE ti.estado = 0 AND ty.nombre LIKE '%' + @p1 + '%' OR sec.nombre LIKE '%' + @p1 + '%' OR ti.fecha LIKE '%' + @p1 + '%' OR ti.cod_QR LIKE '%' + @p1 + '%'";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", dato);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Ticket aux = new Clases.Ticket();
                    aux.codigoQR = lector["cod_QR"].ToString();
                    aux.fecha = lector["fecha"].ToString();
                    aux.horaEntrada = lector["hora_entrada"].ToString();
                    if (lector["hora_salida"].ToString() == "")
                    {
                        aux.horaSalida = "N/A";
                    }
                    else
                    {
                        aux.horaSalida = lector["hora_salida"].ToString();
                    }
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Vigente";
                    }
                    else
                    {
                        aux.estado = "Expirado";
                    }
                    aux.correlativo = lector["correlativo"].ToString();
                    aux.tipo = lector["tipo"].ToString();
                    aux.seccion = lector["seccion"].ToString();
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
        //buscar tickets activos de empleados
        public List<Clases.Ticket> readactivosEmpbuscar(string dato)
        {
            List<Clases.Ticket> lista = new List<Clases.Ticket>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT CONCAT(cart.nombre,' ',cart.apellido) as nombrecompleto,cart.cod_parqueo,ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id INNER JOIN Detalle_ticket_trabajador det ON ti.id = det.id_ticket INNER JOIN Carnet_trabajadores cart ON det.id_trabajador = cart.id WHERE ti.estado = 1 AND ti.cod_QR LIKE '%' + @p1 + '%' OR ti.fecha LIKE '%' + @p1 + '%' OR cart.cod_parqueo LIKE '%' + @p1 + '%'";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", dato);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Ticket aux = new Clases.Ticket();
                    aux.nombreEmpleado = lector["nombrecompleto"].ToString();
                    aux.codigoEmpleado = lector["cod_parqueo"].ToString();
                    aux.codigoQR = lector["cod_QR"].ToString();
                    aux.fecha = lector["fecha"].ToString();
                    aux.horaEntrada = lector["hora_entrada"].ToString();
                    if (lector["hora_salida"].ToString() == "")
                    {
                        aux.horaSalida = "N/A";
                    }
                    else
                    {
                        aux.horaSalida = lector["hora_salida"].ToString();
                    }
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Vigente";
                    }
                    else
                    {
                        aux.estado = "Expirado";
                    }
                    aux.correlativo = lector["correlativo"].ToString();
                    aux.tipo = lector["tipo"].ToString();
                    aux.seccion = lector["seccion"].ToString();
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
        //buscar tickets expirados de empleados
        public List<Clases.Ticket> readexpiEmpbuscar(string dato)
        {
            List<Clases.Ticket> lista = new List<Clases.Ticket>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT CONCAT(cart.nombre,' ',cart.apellido) as nombrecompleto,cart.cod_parqueo,ti.cod_QR ,ti.fecha, ti.hora_entrada,ti.hora_salida,ti.estado, est.correlativo, ty.nombre as tipo, sec.nombre as seccion from Ticket ti INNER JOIN Estacion est ON ti.id_estacion = est.id INNER JOIN Tipo_estacionamiento ty ON est.id_tipo_estacion = ty.id INNER JOIN Secciones_estacion sec ON est.id_seccion = sec.id INNER JOIN Detalle_ticket_trabajador det ON ti.id = det.id_ticket INNER JOIN Carnet_trabajadores cart ON det.id_trabajador = cart.id WHERE ti.estado = 0 AND ti.cod_QR LIKE '%' + @p1 + '%' OR ti.fecha LIKE '%' + @p1 + '%' OR cart.cod_parqueo LIKE '%' + @p1 + '%'";
            comando.Connection = Clases.Conexion.connecSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Clases.Ticket aux = new Clases.Ticket();
                    aux.nombreEmpleado = lector["nombrecompleto"].ToString();
                    aux.codigoEmpleado = lector["cod_parqueo"].ToString();
                    aux.codigoQR = lector["cod_QR"].ToString();
                    aux.fecha = lector["fecha"].ToString();
                    aux.horaEntrada = lector["hora_entrada"].ToString();
                    if (lector["hora_salida"].ToString() == "")
                    {
                        aux.horaSalida = "N/A";
                    }
                    else
                    {
                        aux.horaSalida = lector["hora_salida"].ToString();
                    }
                    if (lector["estado"].ToString() == "True")
                    {
                        aux.estado = "Vigente";
                    }
                    else
                    {
                        aux.estado = "Expirado";
                    }
                    aux.correlativo = lector["correlativo"].ToString();
                    aux.tipo = lector["tipo"].ToString();
                    aux.seccion = lector["seccion"].ToString();
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
    }

}
