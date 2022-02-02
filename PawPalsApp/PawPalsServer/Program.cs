﻿using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace PawPalsServer
{
    class Program
    {
        private static Socket socket;
        private static SqlConnection cn;
        public static ManualResetEvent control = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            //IPAddress ip = IPAddress.Parse("192.168.1.19");
            IPAddress ip = IPAddress.Parse("192.168.43.33");
            socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipend = new IPEndPoint(ip, 12012);
            try
            {
                socket.Bind(ipend);
                socket.Listen(100);
                while (true)
                {
                    control.Reset();
                    socket.BeginAccept(AcceptConnection, socket);
                    control.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private static void AcceptConnection(IAsyncResult ar)
        {
            control.Set();
            BufferObject state = new BufferObject();
            state.clientSocket = ((Socket)ar.AsyncState).EndAccept(ar);
            Console.WriteLine("Aceptado");
            state.clientSocket.BeginReceive(state.buffer, 0, BufferObject.BUFFER_SIZE, SocketFlags.None,
                new AsyncCallback((ar) => { }), state);
        }

        private static IPAddress GetIPAddress()
        {
            IPAddress ipAddress = null;
            try
            {
                foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                        netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    {
                        foreach (var addrInfo in netInterface.GetIPProperties().UnicastAddresses)
                        {
                            if (addrInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                ipAddress = addrInfo.Address;
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
            if (ipAddress == null)
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry("127.0.0.1");
                ipAddress = ipHostInfo.AddressList[0];
            }
            return ipAddress;
        }
    }

    public class BufferObject
    {
        public const int BUFFER_SIZE = 1024 * 1024;

        public byte[] buffer = new byte[BUFFER_SIZE];

        public Socket clientSocket = null;
    }
}
