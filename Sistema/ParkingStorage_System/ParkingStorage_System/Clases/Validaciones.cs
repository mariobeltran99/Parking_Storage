using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
