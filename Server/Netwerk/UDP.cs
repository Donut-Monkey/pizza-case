using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server.Netwerk
{
    class UDPServer : Listener
    {
        private UTF8Encoding utf8 = new UTF8Encoding();
        private UdpClient udpClient;
        private IPEndPoint groupEp;
        private Socket socket;

        public UDPServer(string adress, int port)
        {
            utf8 = new UTF8Encoding();
            udpClient = new UdpClient(port);
            groupEp = new IPEndPoint(IPAddress.Any, port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }
        public byte[] Receive()
        {
            byte[] data = null;
            try
            {
                data = udpClient.Receive(ref groupEp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return data;
        }

        public void Send(byte[] Data)
        {
            socket.SendTo(Data, groupEp);
        }
    }
}

