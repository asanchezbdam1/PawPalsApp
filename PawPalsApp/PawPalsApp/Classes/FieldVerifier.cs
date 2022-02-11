using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PawPalsApp.Classes
{
    public class FieldVerifier
    {
        public static bool VerifyPassword(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;
            return Regex.IsMatch(text, "^[a-zA-Z0-9]{8,20}$");
        }

        public static bool VerifyTextField(string text)
        {
            /*if (text.Contains(" ")) return false;
            if (text.Length < 3 || text.Length > 20) return false;
            return true;*/
            if (string.IsNullOrWhiteSpace(text)) return false;
            return Regex.IsMatch(text, "^[a-zA-Z0-9]{3,20}$");
        }
    }
}
