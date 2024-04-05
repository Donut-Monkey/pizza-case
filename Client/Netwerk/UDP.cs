using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Client.Netwerk
{
    public class UDPClient : IListener
    {
        private UTF8Encoding utf8 = new UTF8Encoding();
        private UdpClient udpClient;
        private IPEndPoint groupEp;
        private Socket socket;

        public UDPClient(string adres, int poort)
        {
            utf8 = new UTF8Encoding();
            udpClient = new UdpClient(8081);
            groupEp = new IPEndPoint(IPAddress.Parse(adres), poort);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }
        public void Send(byte[] Data)
        {
            socket.SendTo(Data, groupEp);
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
    }
}
