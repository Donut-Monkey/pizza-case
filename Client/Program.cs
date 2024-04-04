using Client.Bestelling;
using Client.Netwerk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //switch tcp/udp door instance op true/false
            ClientSocket socket = ClientSocket.GetInstance(true);
            Console.WriteLine("Voer wachtwoord in:");
            string wachtwoord = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Bestelling:");
                Console.WriteLine("Vul je gegevens in.");
                Console.Write("Naam: ");
                string naam = Console.ReadLine();
                Console.Write("Adres: ");
                string adres = Console.ReadLine();
                Console.Write("Woonplaats: ");
                string woonplaats = Console.ReadLine();
                Console.Write("Aantal pizza's: ");
                int aantal = Convert.ToInt32(Console.ReadLine());
                int toppings = 0;
                List<Pizza> pizzas = new List<Pizza>();

                //ga door aantal pizzas heen
                string pizzaBericht = aantal > 1 ? "Vul je pizza's in" : "Vul je pizza in";
                Console.WriteLine(pizzaBericht);
                for (int i = 1; i <= aantal; i++)
                {
                    Pizza nieuwePizza = new Pizza();
                    Console.Write("Pizza " + i + ": ");
                    nieuwePizza.Naam = Console.ReadLine();

                    Console.Write("Aantal toppings: ");
                    toppings = Convert.ToInt32(Console.ReadLine());
                    if (Convert.ToInt16(toppings) > 0)
                    {
                        //ga door aantal toppings heen
                        List<string> nieuweToppings = new List<string>();
                        Console.WriteLine("Vul je toppings in.");
                        for (int j = 1; j <= toppings; j++)
                        {
                            Console.Write("Topping " + j + ": ");
                            nieuweToppings.Add(Console.ReadLine());
                        }
                        nieuwePizza.Toppings = nieuweToppings.ToArray();
                    }
                    pizzas.Add(nieuwePizza);
                }
                DateTime bestelmoment = DateTime.Now;

                //stuur bestelling
                BestelFormat bestelling = new BestelFormat(naam, adres, woonplaats, pizzas.ToArray(), aantal, toppings, bestelmoment);
                string jsonString = JsonSerializer.Serialize(bestelling);
                Console.WriteLine("Je bestelling wordt verzonden...\n");    
                socket.Send(wachtwoord + ";" + jsonString);
                //P1c4G0bR
            }
        }
    }
}
