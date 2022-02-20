using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossClasses
{
    /// <summary>
    /// Clase que modela la lista de publicaciones para
    /// el envío o recibimiento desde el servidor.
    /// </summary>
    [Serializable]
    public class PostList
    {
        /// <summary>
        /// Lista de publicaciones.
        /// </summary>
        public List<Post> Posts;

        /// <summary>
        /// ID del usuario que hace la solicitud.
        /// </summary>
        public int RequesterID;

        /// <summary>
        /// Indica si se pide el historial
        /// de publicaciones vistas.
        /// </summary>
        public bool History;

        /// <summary>
        /// Indica si se piden las
        /// publicaciones del usuario o no.
        /// </summary>
        public bool FromRequester;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public PostList()
        {
            Posts = new List<Post>();
            RequesterID = 0;
            FromRequester = false;
            History = false;
        }
    }
}
