using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingStorage_System
{
    class Usuario
    {
        private string nombre;
        private string nombreUsuario;
        private string contra;
        private char tipoUsuario;
        private string estado;
        private string id;
        private string exid;
        public string Nombre { get => nombre; set => nombre = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contra { get => contra; set => contra = value; }
        public char TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Id { get => id; set => id = value; }
        public string Exid { get => exid; set => exid = value; }
    }
}
