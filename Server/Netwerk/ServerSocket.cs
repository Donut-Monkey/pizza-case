using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Server.Netwerk
{
    //public
	//classes private houden
	/// <summary>
	///  getters en setters
	///  encrypt veranderen of weghalen
	/// </summary>
    class ServerSocket
    {
		protected static ServerSocket _instance = null;

		private Listener _listener;
		private readonly string _localAddres = "127.0.0.1";
		private readonly int _port = 8080;
		//private SecureChannel _channel;

		private ServerSocket(bool IsTCP)
		{
			//_channel = new SecureChannel();
			if (IsTCP)
				_listener = new TCPServer(_localAddres, _port);
			else
				_listener = new UDPServer(_localAddres, _port);
		}

		//singleton pattern
		//Singleton is a creational design pattern, which ensures that only one object of its kind exists and provides a single point of access to it for any other code.
		public static ServerSocket GetInstance(bool IsTCP)
		{
			if (_instance == null)
			{
				_instance = new ServerSocket(IsTCP);

			}
			return _instance;
		}

		public List<string> Receive()
		{
			byte[] incomingData = _listener.Receive();
			StreamReader sr = new StreamReader(stream);
			string data = sr.ReadLine();

			//List<string> data = _channel.Decrypt(incomingData).Split(';').ToList();
			//data.RemoveAt(data.Count - 1);
			//beep \/
			//List<string> data = incomingData.ToString();

			return incomingData;
			return data;
		}
		public void Send(string Message)
		{
			byte[] data = _channel.Encrypt(Message);
			_listener.Send(data);
		}
	}
}
