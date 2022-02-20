using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossClasses
{
    /// <summary>
    /// Clase que modela la reacción de
    /// un usuario a una publicación.
    /// </summary>
    [Serializable]
    public class PostReacted
    {
        /// <summary>
        /// ID de la publicación reaccionada.
        /// </summary>
        public int PostID { get; set; }

        /// <summary>
        /// ID del usuario que ha reaccionado.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Reacción del usuario a la publicación.
        /// </summary>
        public PostReaction Reaction { get; set; }
        public PostReacted() { }
    }
}
