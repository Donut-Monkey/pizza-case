using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;

namespace Server.Netwerk
{
    class TCPServer : Listener
    {
        private UTF8Encoding utf8 = new UTF8Encoding();
        private TcpClient tcpClient = null;
        private TcpListener listener = null;
        private NetworkStream stream = null;
        string data = null;

        public TCPServer(string adress, int port)
        {
            listener = new TcpListener(IPAddress.Parse(adress), port);
            listener.Start();
        }

        public byte[] Receive()
        {
            //byte[] data = new byte[];
            byte[] bytes = new byte[256];
            try
            {
                if (tcpClient == null)
                    tcpClient = listener.AcceptTcpClient();
                if (stream == null)
                    stream = tcpClient.GetStream();
                stream.Read(bytes, 0, bytes.Length);

                return bytes;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return bytes;
        }

        public void Send(byte[] Data)
        {
            if (stream != null)
            {
                stream.Write(Data, 0, Data.Length);
            }
        }

    }
}

