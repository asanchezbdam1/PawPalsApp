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
        public byte[] Imagen { get; set; }

    }
}
