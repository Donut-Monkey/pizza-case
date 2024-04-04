using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Server.Netwerk
{
	public class ServerSocket
	{
		protected static ServerSocket _instance = null;

		private Listener _listener;
		private readonly string _localAdres = "127.0.0.1";
		private readonly int _poort = 8080;
		private SecureChannel _channel;

		//switch tussen tcp en udp
		private ServerSocket(bool IsTCP)
		{
			_channel = new SecureChannel();
			if (IsTCP)
				_listener = new TCPServer(_localAdres, _poort);
			else
				_listener = new UDPServer(_localAdres, _poort);
		}

		//singleton pattern
		//altijd maar 1 instantie van
		//Singleton is a creational design pattern, which ensures that only one object of its kind exists and provides a single point of access to it for any other code.
		public static ServerSocket GetInstance(bool IsTCP)
		{
			if (_instance == null)
			{
				_instance = new ServerSocket(IsTCP);

			}
			return _instance;
		}
        public void Send(string Message)
        {
            // Encrypt string en send
            byte[] encrypted = _channel.Encrypt(Message + ";");
            //byte[] encrypted = _channel.Encrypt(Message);
            _listener.Send(encrypted);
        }
        public List<string> Receive()
        {
            // Recieve string en decrypt
            byte[] incomingData = _listener.Receive();
            string decrypted = _channel.Decrypt(incomingData);
            List<string> data = decrypted.Split(";").ToList();
            data.RemoveAt(data.Count - 1);
            return data;
        }
	}
}
