using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawPalsApp.Classes
{
    public class Higiene
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string IdMascota { get; set; }
        [MaxLength(100)]
        public string Higienes { get; set; }
    }
}
