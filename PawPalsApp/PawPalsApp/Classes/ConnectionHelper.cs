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
    public class ConnectionHelper
    {
        private const int PORT = 12212;
        private const int BUFFER_SIZE = 1024 * 1024;
        public const int MAX_IMAGE_SIZE = 50 * 1024;
        private static Socket client;
        public static bool StartConnection()
        {
            try
            {
                //IPAddress ipAddress = IPAddress.Parse("192.168.1.19");
                IPAddress ipAddress = IPAddress.Parse("192.168.43.33");
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

        public static object Send(object data)
        {
            StartConnection();
            byte[] serialized = ObjectSerializer.SerializeObject(data);
            //byte[] packet = ObjectSerializer.NormalizeArray(serialized, BUFFER_SIZE);
            client.Send(serialized);
            byte[] packet = new byte[BUFFER_SIZE];
            Thread.Sleep(100);
            int bytes = client.Receive(packet);
            object result = ObjectSerializer.DeserializeObject(packet);
            Close();
            return result;
        }

        public static void Close()
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}
