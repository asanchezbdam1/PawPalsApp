using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PawPalsApp.Classes
{
    /// <summary>
    /// Clase para la verificación de los campos de formularios.
    /// </summary>
    public class FieldVerifier
    {
        /// <summary>
        /// Verifica que el campo de contraseña es correcto.
        /// Para esto debe introducirse entre 8 y 20 caracteres,
        /// incluyendo letras minúsculas y números.
        /// </summary>
        /// <param name="text">Cadena de texto a comprobar</param>
        /// <returns>Si la contraseña tiene formato correcto o no.</returns>
        public static bool VerifyPassword(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            if (!Regex.IsMatch(text, "[a-z]+")) return false;
            if (!Regex.IsMatch(text, "\\d+")) return false;
            return Regex.IsMatch(text, "^[a-zA-Z0-9]{8,20}$");
        }

        /// <summary>
        /// Verifica si el campo de nombre de usuario
        /// tiene el formato correcto. Debe tener entre
        /// 3 y 20 caracteres y letras. Puede tener números.
        /// </summary>
        /// <param name="text">Cadena de texto a comprobar.</param>
        /// <returns>Si el nombre de usuario es correcto o no.</returns>
        public static bool VerifyTextField(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            if (!Regex.IsMatch(text, "[a-zA-Z]+")) return false;
            return Regex.IsMatch(text, "^[a-zA-Z0-9]{3,20}$");
        }
    }
}
