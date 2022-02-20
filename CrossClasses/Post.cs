using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossClasses
{
    /// <summary>
    /// Clase que modela una publicación.
    /// </summary>
    [Serializable]
    public class Post : INotifyPropertyChanged
    {
        /// <summary>
        /// ID de la publicación.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID de usuario que ha subido la publicación.
        /// </summary>
        public int UID { get; set; }

        /// <summary>
        /// Nombre del usuario que ha subido la publicación.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Número de "me gusta" que ha recibido la publicación.
        /// </summary>
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
                    }
        }

        /// <summary>
        /// Número de "no me gusta" que ha recibido la publicación.
        /// </summary>
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

        /// <summary>
        /// Imagen de la publicación en forma de array de bytes.
        /// </summary>
        public byte[] Img { get; set; }

        /// <summary>
        /// Ratio de Likes/Dislikes.
        /// </summary>
        public double Ratio { get { return Likes / (1.0 * (Likes + Dislikes)); } }

        /// <summary>
        /// Reacción del usuario actual a la publicación.
        /// </summary>
        private PostReaction reaction;
        public PostReaction Reaction { get => reaction; set {
                if (reaction != value)
                {
                    reaction = value;
                    OnPropertyChanged("Reaction");
                }
            } }

        /// <summary>
        /// Propiedad de solo lectura que devuelve verdadero
        /// si al usuario "le gusta" la publicación
        /// </summary>
        public bool Liked { get { return Reaction == PostReaction.LIKE; } }

        /// <summary>
        /// Propiedad de solo lectura que devuelve verdadero
        /// si al usuario "no le gusta" la publicación
        /// </summary>
        public bool Disliked { get { return Reaction == PostReaction.DISLIKE; } }

        /// <summary>
        /// Propiedad de solo lectura que devuelve verdadero
        /// si al usuario no "le gusta" la publicación
        /// </summary>
        public bool NotLiked { get { return !Liked; } }

        /// <summary>
        /// Propiedad de solo lectura que devuelve verdadero
        /// si al usuario no "no le gusta" la publicación
        /// </summary>
        public bool NotDisliked { get { return !Disliked; } }

        /// <summary>
        /// Evento que se lanza al cambiar una
        /// propiedad observada en la publicación.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Post()
        {
            Reaction = PostReaction.NONE;
            ID = 0;
            Username = String.Empty;
            Likes = 1;
            Dislikes = 1;
        }

        /// <summary>
        /// Método que invoca el evento de propiedad cambiada.
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad cambiada.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
