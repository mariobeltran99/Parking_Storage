using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingStorage_System.Clases
{
    class Carnet
    {
        private int id;
        private string nombre;
        private string apellido;
        private string dui;
        private DateTime fechaRegistro;
        private DateTime fechaVencimiento;
        private string codigoParqueo;
        private string tipoTrabajador;
        private string estado;
        private string imagen;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Dui { get => dui; set => dui = value; }
        public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
        public DateTime FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public string CodigoParqueo { get => codigoParqueo; set => codigoParqueo = value; }
        public string TipoTrabajador { get => tipoTrabajador; set => tipoTrabajador = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Imagen { get => imagen; set => imagen = value; }
    }
}
