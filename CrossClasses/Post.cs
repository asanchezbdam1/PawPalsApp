using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossClasses
{
    [Serializable]
    public class Post : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public int UID { get; set; }
        public string Username { get; set; }
        private int likes;
        public int Likes
        {
            get { return likes; }
            set {
                if (likes != value)
                {
                    likes = value;
                    OnPropertyChanged("Likes");
                }
                    } }
        private int dislikes;
        public int Dislikes
        {
            get { return dislikes; }
            set
            {
                if (dislikes != value)
                {
                    dislikes = value;
                    OnPropertyChanged("Dislikes");
                }
            }
        }
        public byte[] Img { get; set; }
        public double Ratio { get { return Likes / (1.0 * (Likes + Dislikes)); } }
        private PostReaction reaction;
        public PostReaction Reaction { get => reaction; set {
                if (reaction != value)
                {
                    reaction = value;
                    OnPropertyChanged("Reaction");
                }
            } }
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
