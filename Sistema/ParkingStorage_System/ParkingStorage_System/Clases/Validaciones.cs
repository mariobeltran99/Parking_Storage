using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParkingStorage_System.Clases
{
    class Validaciones
    {
        private string expresion;

        public bool validacionDUI(string text)
        {
            expresion = @"^[0-9]{8}\-?[0-9]{1}$";
            if (Regex.IsMatch(text, expresion))
            {
                if (Regex.Replace(text, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool validarOtraExpresion(string regex, string text)
        {
            expresion = regex;
            if (Regex.IsMatch(text, expresion))
            {
                if (Regex.Replace(text, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        //encriptar contraseña
        public string SHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
