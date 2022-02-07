using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PawPalsApp.Classes
{
    public class Mascotas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Imagen { get; set; }
        [MaxLength(50)]
        public DateTime Fecha { get; set; }
        public List<string> Ejercicios { get; set; }
        public List<string> Higiene { get; set; }
        public List<string> Dieta { get; set; }

    }
}
