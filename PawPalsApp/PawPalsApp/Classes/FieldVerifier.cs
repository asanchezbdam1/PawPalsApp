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
            return Regex.Match(text, "^[a-zA-Z0-9]{8,20}$").Success;
        }

        public static bool VerifyTextField(string text)
        {
            if (text.Contains(" ")) return false;
            if (string.IsNullOrWhiteSpace(text)) return false;
            if (text.Length < 3 || text.Length > 20) return false;
            return true;
        }
    }
}
