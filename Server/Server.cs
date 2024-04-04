using Server.Bestelling;
using Server.Netwerk;
//using Server.Netwerk.ServerSocket;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Server
{
    class Server
    {
        private ServerSocket _socket;
        private BestelLijst _orders;
        public Server()
        {
            //switch tcp/udp door instance op true/false
            _socket = ServerSocket.GetInstance(true);
            _orders = new BestelLijst();
        }
        public void Start()
        {
            while (true)
            {
                List<string> request = _socket.Receive();
                Console.WriteLine("Data received: {0}", request);
               
                // ontvang json data en zet het om in normale string. Als wachtwoord klopte, print dan uit.
                BestelFormat incomingOrder = JsonSerializer.Deserialize<BestelFormat>(request[1]);
                if (Auth.Authorize(request[0]) == true)
                {
                    _orders.Add(incomingOrder);
                }
                Console.Clear();
                Console.WriteLine("Bestellingen:");
                _orders.Print();
            }
        }
    }
}
