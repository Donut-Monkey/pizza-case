using Client.Bestelling;
using Client.Netwerk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                //BestelFormat bestelling = new BestelFormat(naam, adres, woonplaats, pizzas.ToArray(), aantal, toppings, bestelmoment);
                //string jsonString = JsonSerializer.Serialize(bestelling);
                //Console.WriteLine("Je bestelling wordt verzonden...\n");    
                //socket.Send(wachtwoord + ";" + jsonString);

                //BestelFormat bestelling = new BestelFormat(naam, adres, woonplaats, pizzas.ToArray(), aantal, toppings, bestelmoment);
                //string plainpizza = ""; //= string.Join(",", pizzas[0]);
                //int count = 0;
                //foreach (Pizza item in pizzas)
                //{
                //    plainpizza += string.Join(",", item.Naam + "," + item.Toppings[count].ToString() + ",");
                //    //count++;
                //}
                //string plaintopping = string.Join(",", toppings);
                //string plainTextData = $"{naam};{adres};{woonplaats};{plainpizza};{aantal};{plaintopping};{bestelmoment}";
                //Console.WriteLine("Je bestelling wordt verzonden...\n");
                //socket.Send(wachtwoord + ";" + plainTextData);
                //P1c4G0bR

                // Maak bestelformat aan
                BestelFormat bestelling = new BestelFormat(naam, adres, woonplaats, pizzas.ToArray(), aantal, toppings, bestelmoment);

                // Bouw de string voor de pizzas inclusief toppings
                StringBuilder pizzaBuilder = new StringBuilder();
                foreach (Pizza item in pizzas)
                {
                    pizzaBuilder.AppendLine($"{item.Naam}\n{aantal /* hmm */}\n{item.Toppings.Length}");
                    for (int i = 0; i < item.Toppings.Length; i++)
                    {
                        //extra toppings toevoegen
                        pizzaBuilder.Append($"{item.Toppings[i]}\n");
                    }
                }

                pizzaBuilder.Remove(pizzaBuilder.Length - 1, 1); // Verwijder de laatste komma

                // Combineer alles in de eindstring
                //string plainTextData = $"{naam}{adres}{woonplaats}{pizzaBuilder.ToString()}{aantal}{toppings}{bestelmoment}"; Console.WriteLine("Je bestelling wordt verzonden...\n");
                string plainTextData = $"{naam}\n{adres}\n{woonplaats}\n{pizzaBuilder}\n{bestelmoment}"; 
                Console.WriteLine("Je bestelling wordt verzonden...\n");
                socket.Send(wachtwoord + ";" + plainTextData);
                //P1c4G0bR

            }
        }
    }
}
