using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PawPalsApp.Classes
{
    public class ConnectionHelper
    {
        private const int PORT = 12012;
        public static void StartConnection()
        {
            try
            {
                //IPAddress ipAddress = IPAddress.Parse("192.168.1.19");
                IPAddress ipAddress = IPAddress.Parse("192.168.43.33");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, PORT);
                Socket client = new Socket(ipAddress.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);
                client.BeginConnect(remoteEP,
                        new AsyncCallback((IAsyncResult ar) => { }), client);
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
