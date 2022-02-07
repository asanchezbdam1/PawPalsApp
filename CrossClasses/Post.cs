using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossClasses
{
    [Serializable]
    public class Post
    {
        public int ID { get; set; }
        public int UID { get; set; }
        public string Username { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public byte[] Img { get; set; }
        public double Ratio { get { return Likes / (1.0 * (Likes + Dislikes)); } }
        public PostReaction Reaction { get; set; }
        public bool Liked { get { return Reaction == PostReaction.LIKE; } }
        public bool Disliked { get { return Reaction == PostReaction.DISLIKE; } }
        public bool NotLiked { get { return !Liked; } }
        public bool NotDisliked { get { return !Disliked; } }

        public Post()
        {
            Reaction = PostReaction.NONE;
            ID = 0;
            Username = String.Empty;
            Likes = 1;
            Dislikes = 1;
        }


    }
}
