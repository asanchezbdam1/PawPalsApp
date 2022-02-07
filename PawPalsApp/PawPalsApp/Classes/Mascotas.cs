using System;
using System.Collections.Generic;
using System.Text;

namespace PawPalsApp.Classes
{
    internal class Mascotas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public List<String> Ejercicios { get; set; }
        public List<String> Higiene { get; set; }
        public List<String> Dieta { get; set; }

    }
}
