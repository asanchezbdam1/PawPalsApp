using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CrossClasses
{
    /// <summary>
    /// Clase para la serialización o deserialización de
    /// objetos para su envío a través de un socket TCP.
    /// </summary>
    public static class ObjectSerializer
    {
        /// <summary>
        /// Constante con el tamaño máximo de imagen permitido.
        /// </summary>
        public const int MAX_IMAGE_SIZE = 50 * 1024;

        /// <summary>
        /// Método que serializa el objeto pasado como parámetro.
        /// </summary>
        /// <param name="obj">Objeto a serializar.</param>
        /// <returns>Array de bytes resultante de la serialización.</returns>
        public static byte[] SerializeObject(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Método que deserializa el objeto pasado como parámetro.
        /// </summary>
        /// <param name="arr">Array de bytes del objeto serializado.</param>
        /// <returns>Objeto resultante de deserializar.</returns>
        public static object DeserializeObject(byte[] arr)
        {
            if (arr == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(arr))
            {
                return bf.Deserialize(ms);
            }
        }

    }
}
