using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingStorage_System.Clases
{
    class Estacionamiento
    {
        private int id;
        private int idSeccion;
        private int idEstacion;
        private string correlativo;

        public int Id { get => id; set => id = value; }
        public int IdSeccion { get => idSeccion; set => idSeccion = value; }
        public int IdEstacion { get => idEstacion; set => idEstacion = value; }
        public string Correlativo { get => correlativo; set => correlativo = value; }
    }
}
