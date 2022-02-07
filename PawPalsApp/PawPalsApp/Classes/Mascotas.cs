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
        public List<String> Ejercicios { get; set; }
        public List<String> Higiene { get; set; }
        public List<String> Dieta { get; set; }

    }
}
