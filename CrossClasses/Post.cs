using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossClasses
{
    [Serializable]
    public class Post
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public byte[] Img { get; set; }
        public double Ratio { get { return Likes / (1.0 * (Likes + Dislikes)); } }

        public Post()
        {
            ID = 0;
            Username = String.Empty;
            Likes = 0;
            Dislikes = 0;
        }
    }
}
