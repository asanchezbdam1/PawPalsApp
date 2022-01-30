using System;
using System.Collections.Generic;
using System.Text;

namespace PawPalsApp.Classes
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Pwd { get; set; }
        public string Nombre { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public Usuario()
        {

        }
    }
}
