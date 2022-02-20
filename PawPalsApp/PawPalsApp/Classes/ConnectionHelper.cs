using CrossClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace PawPalsApp.Classes
{
    /// <summary>
    /// Clase que permite la conexión y envío
    /// de datos entre cliente y servidor.
    /// </summary>
    public class ConnectionHelper
    {
        /// <summary>
        /// Puerto al cuál va a intentar conectarse.
        /// </summary>
        private const int PORT = 12212;

        /// <summary>
        /// Tamaño del buffer, por defecto, 1MB.
        /// </summary>
        private const int BUFFER_SIZE = 1024 * 1024;

        /// <summary>
        /// Tamaño máximo de la imagen, por defecto, 50KB.
        /// </summary>
        public const int MAX_IMAGE_SIZE = ObjectSerializer.MAX_IMAGE_SIZE;

        /// <summary>
        /// Socket del cliente.
        /// </summary>
        private static Socket client;

        /// <summary>
        /// Establece conexión con el servidor.
        /// </summary>
        /// <returns>Verdadero si se conecta correctamente.</returns>
        public static bool StartConnection()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse("192.168.1.19");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, PORT);
                client = new Socket(ipAddress.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);
                client.Connect(remoteEP);
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        /// <summary>
        /// Método que envía el objeto y devuelve la respuesta.
        /// Este método establece una conexión cada vez que se ejecuta,
        /// que es cerrada al terminar.
        /// </summary>
        /// <param name="data">Objeto a enviar</param>
        /// <returns>Respuesta del servidor</returns>
        public static object Send(object data)
        {
            try
            {
                StartConnection();
                byte[] serialized = ObjectSerializer.SerializeObject(data);
                client.Send(serialized);
                byte[] packet = new byte[BUFFER_SIZE];
                Thread.Sleep(100);
                int bytes = client.Receive(packet);
                object result = ObjectSerializer.DeserializeObject(packet);
                Close();
                return result;
            } catch 
            {
                try
                {
                    Close();
                } catch { };
                return null;
            }
        }

        public static void Close()
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}
