using Server.Bestelling;
using Server.Netwerk;
using Server.Visitor;

//using Server.Netwerk.ServerSocket;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

namespace Server
{
    class Server
    {
        private ServerSocket _socket;
        private BestelLijst _bestellingen;
        public Server()
        {
            //switch tcp/udp door instance op true/false
            _socket = ServerSocket.GetInstance(true);
            _bestellingen = new BestelLijst();
        }
        public void Start()
        {
            while (true)
            {
                List<string> request = _socket.Receive();
                Console.WriteLine("Data received: {0}", request);

                Console.WriteLine("Bestellingen:");

                // Check authorization
                if (Auth.Authorize(request[0]) == true)
                {
                    string inkomendeBestelling = request[1];
                    Console.WriteLine("inkomende bestelling: " + inkomendeBestelling);
                    string[] splitBestelling = inkomendeBestelling.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);                    
                    // Add incoming order to the list
                    // _bestellingen.Add(incomingOrder);
                    string combinedString = string.Join(",", inkomendeBestelling);
                    //string plainpizza = string.Join(",", pizzas[0]);
                    Console.WriteLine("lege regel");
                    BestelFormat bestelling = new BestelFormat();
                    var verwerkteBestelling = bestelling.ParseBestelling(splitBestelling);
                    //Console.WriteLine(netjes);
                    _bestellingen.Add(verwerkteBestelling);


                    PrintAllOrders();

                }

            }
        }

        public void PrintAllOrders()
        {
            PrintVisitor printVisitor = new PrintVisitor();
            _bestellingen.AcceptBestellingVisitor(printVisitor);
        }

    }
}
