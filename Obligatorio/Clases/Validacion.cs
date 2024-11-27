using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio.Clases
{
    public class Validacion
    {
        public static bool ValidarCedula(string cedula)
        {
            if (cedula.Length == 7)
            {
                cedula = "0" + cedula;
            }

            if (cedula.Length != 8) return false;

            // Pesos para la validación
            int[] pesos = { 2, 9, 8, 7, 6, 3, 4 };
            int suma = 0;

            // Multiplica cada dígito por su peso
            for (int i = 0; i < 7; i++)
            {
                suma += (cedula[i] - '0') * pesos[i];
            }

            // Calcula el dígito verificador
            int modulo = suma % 10;
            int digitoVerificador = modulo == 0 ? 0 : 10 - modulo;

            // Compara el dígito verificador con el último dígito de la cédula
            return digitoVerificador == (cedula[7] - '0');
        }
    }
}