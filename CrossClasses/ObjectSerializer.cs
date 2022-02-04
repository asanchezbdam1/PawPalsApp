using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CrossClasses
{
    public static class ObjectSerializer
    {

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

        public static byte[] NormalizeArray(byte[] arr, int len)
        {
            byte[] res = new byte[len];
            for (int i = 0; i < arr.Length; i++)
            {
                res[i] = arr[i];
            }
            return res;
        }
    }
}
