using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Client.Netwerk
{
    public class TCPClient : Listener
    {
        private UTF8Encoding utf8 = new UTF8Encoding();
        private TcpClient tcpClient = null;
        private NetworkStream stream = null;

        public TCPClient(string adres, int poort)
        {
            tcpClient = new TcpClient(adres, poort);
            stream = tcpClient.GetStream();
        }

        public void Send(byte[] Data)
        {
            if (stream != null)
            {
                stream.Write(Data, 0, Data.Length);
            }
            else
            {
                Console.WriteLine("Stream was null");
            }
        }
        public byte[] Receive()
        {
            byte[] data = new byte[256];
            try
            {
                stream.Read(data, 0, data.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return data;
        }
    }
}
