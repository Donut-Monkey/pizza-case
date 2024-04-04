﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server.Netwerk
{
    class UDPServer : IListener
    {
        private UTF8Encoding utf8 = new UTF8Encoding();
        private UdpClient udpClient;
        private IPEndPoint groupEp;
        private Socket socket;

        public UDPServer(string adres, int poort)
        {
            utf8 = new UTF8Encoding();
            udpClient = new UdpClient(poort);
            groupEp = new IPEndPoint(IPAddress.Any, poort);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }
        //verstuur data
        public void Send(byte[] Data)
        {
            socket.SendTo(Data, groupEp);
        }
        //ontvang data
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

