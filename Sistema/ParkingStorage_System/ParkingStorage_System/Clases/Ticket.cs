using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingStorage_System.Clases
{
    class Ticket
    {
        private int id;
        private string codigoQR;
        private DateTime horaEntrada;
        private DateTime horaSalida;
        private int idEstacion;
        private string estado;
        private string imagen;
        public int Id { get => id; set => id = value; }
        public string CodigoQR { get => codigoQR; set => codigoQR = value; }
        public DateTime HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
        public DateTime HoraSalida { get => horaSalida; set => horaSalida = value; }
        public int IdEstacion { get => idEstacion; set => idEstacion = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Imagen { get => imagen; set => imagen = value; }
    }
}
