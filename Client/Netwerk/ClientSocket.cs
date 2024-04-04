using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.X86;
using System.Linq;


namespace Client.Netwerk
{
    public class ClientSocket
    {
        protected static ClientSocket _instance = null;

        private Listener _client;
        private readonly string _RemoteAdres = "127.0.0.1";
        private readonly int _poort = 8080;
        private SecureChannel _channel;

        //tcp of udp socket
        private ClientSocket(bool IsTCP)
        {
            _channel = new SecureChannel();
            if (IsTCP)
                _client = new TCPClient(_RemoteAdres, _poort);
            else
                _client = new UDPClient(_RemoteAdres, _poort); ;
        }
        public static ClientSocket GetInstance(bool IsTCP)
        {
            if (_instance == null)
            {
                _instance = new ClientSocket(IsTCP);
            }
            return _instance;
        }

        public void Send(string Message)
        {
            // Encrypt string en send
            byte[] encrypted = _channel.Encrypt(Message + ";");
            _client.Send(encrypted);
        }
        public List<string> Receive()
        {
            // Recieve string en decrypt
            byte[] incomingData = _client.Receive();
            string decrypted = _channel.Decrypt(incomingData);
            List<string> data = decrypted.Split(";").ToList();
            data.RemoveAt(data.Count - 1);
            return data;
        }
    }
}
