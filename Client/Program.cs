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
            ClientSocket socket = ClientSocket.GetInstance(true);
            Console.WriteLine("Voer wachtwoord in:");
            string wachtwoord = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Bestelling:");
                Console.WriteLine("Vul je gegevens in.");
                Console.WriteLine("Naam:");
                string naam = Console.ReadLine();
                Console.WriteLine("Adres:");
                string adres = Console.ReadLine();
                Console.WriteLine("Woonplaats:");
                string woonplaats = Console.ReadLine();
                Console.WriteLine("Aantal pizza's:");
                int aantal = Convert.ToInt32(Console.ReadLine());
                //failsafe
                int toppings = 0;
                List<string> toppingBeschrijving = new List<string>();
                List<string> pizzaLijst = new List<string>();

                if (Convert.ToInt16(aantal) > 1)
                {
                    Console.WriteLine("Vul je pizza's in.");
                    for (int i = 1; i <= aantal; i++)
                    {
                        Console.WriteLine("Pizza " + i /*pizzaLijst.Count*/ + ":");
                        string pizzaInvoer = Console.ReadLine();
                        pizzaLijst.Add(pizzaInvoer);

                        Console.WriteLine("Toppings:");
                        toppings = Convert.ToInt32(Console.ReadLine());

                        if (Convert.ToInt16(toppings) > 0)
                        {
                            Console.WriteLine("Vul je toppings in.");
                            for (int j = 1; j <= toppings; j++)
                            {
                                Console.WriteLine("Topping " + j /*toppingBeschrijving.Count*/ + ":");
                                string toppingInvoer = Console.ReadLine();
                                toppingBeschrijving.Add(toppingInvoer);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Pizza:");
                    string pizza = Console.ReadLine();
                    pizzaLijst.Add(pizza);

                    Console.WriteLine("Toppings:");
                    toppings = Convert.ToInt32(Console.ReadLine());

                    if (Convert.ToInt16(toppings) > 0)
                    {
                        Console.WriteLine("Vul je toppings in.");
                        for (int j = 1; j <= toppings; j++)
                        {
                            Console.WriteLine("Topping " + j + ":");
                            string toppingInvoer = Console.ReadLine();
                            toppingBeschrijving.Add(toppingInvoer);
                        }
                    }
                }

                DateTime bestelmoment = DateTime.Now;

                BestelFormat bestelling = new BestelFormat(naam, adres, woonplaats, pizzaLijst.ToArray(), aantal, toppings, toppingBeschrijving.ToArray(), bestelmoment);
                string jsonString = JsonSerializer.Serialize<BestelFormat>(bestelling);
                Console.WriteLine("Jouw bestelling: " + jsonString);                
                socket.Send(wachtwoord + ";" + jsonString);
                //P1c4G0bR
            }
        }
    }
}
