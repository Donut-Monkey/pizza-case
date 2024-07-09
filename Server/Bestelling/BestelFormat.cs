using Server.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks.Dataflow;
using static System.Net.Mime.MediaTypeNames;

namespace Server.Bestelling
{
    public class BestelFormat : IBestelling
    {
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Woonplaats { get; set; }
        public Pizza[] Pizzas { get; set; }
        public int Aantal { get; set; }
        public int Toppings { get; set; }
        public DateTime Bestelmoment { get; set; }

        //print bestelling in de console
        public void Print()
        {
            Console.WriteLine("Print methode aangeroepen in BestelFormat");
            Console.Write
                (
                "Naam: " + Naam + "\n" +
                "Adres: " + Adres + "\n" +
                "Woonplaats: " + Woonplaats + "\n" +
                "Aantal Pizza's: " + Aantal
                );

            foreach (Pizza pizza in Pizzas)
            {
                Console.WriteLine("Pizza: " + pizza.Naam);
                if (pizza.Toppings != null && pizza.Toppings.Count > 0)
                    foreach (string topping in pizza.Toppings)
                    {
                        Console.WriteLine("Topping: " + topping);
                    }
            }
            //Console.Write
            //    (
            //    "Aantal Pizza's: " + Aantal + "\n" +
            //    "Toppings: " + Toppings + "\n"
            //    );
            Console.WriteLine(Bestelmoment + "\n");
        }



        public void AcceptBestellingVisitor(IBestellingVisitor visitor)
        {
            visitor.VisitBestelFormat(this);
        }

        public BestelFormat ParseBestelling(string[] inkomendeBestelling)
        {
            // Bereken het aantal pizzas en toppings
            int aantalPizzas = Convert.ToInt32(inkomendeBestelling[4]);
            int totalToppings = Convert.ToInt32(inkomendeBestelling[5]);
            int k = 6;
            var bestelling = new BestelFormat
            {
                Naam = inkomendeBestelling[0],
                Adres = inkomendeBestelling[1],
                Woonplaats = inkomendeBestelling[2],
                Aantal = aantalPizzas,
                Toppings = totalToppings,
                Bestelmoment = Convert.ToDateTime(inkomendeBestelling[inkomendeBestelling.Length - 1])
            };            

            // Parsen van de pizza details
            List<Pizza> geparstePizzas = new List<Pizza>(); // Maak een lijst om alle geparste pizzas op te slaan
            int currentPizzaIndex = 0; // Houd de index van de huidige pizza bij
            for (int i = 3; i < inkomendeBestelling.Length - 1; i += totalToppings + 3) 
            {
                var pizza = new Pizza();
                //eerste pizza is altijd op [3] daarna hangt het af van het aantal toppings
                if (i == 3)
                {
                    pizza.Naam = inkomendeBestelling[i];
                } else
                {
                    pizza.Naam = inkomendeBestelling[k-3];
                }
               

                // Voor elke pizza, vul de toppings in
                // hoeveelheid toppings en locatie in bericht zijn variabel
                
                for (int j = 0; j < totalToppings; j++)
                {
                    pizza.Toppings.Add(inkomendeBestelling[k+j]);
                }
                //update k voor de plek van de toppings
                k += 3 + totalToppings;

                //failsafe
                if (k<inkomendeBestelling.Length)
                {
                    totalToppings = Convert.ToInt32(inkomendeBestelling[k-1]);
                }

                
                geparstePizzas.Add(pizza); // Voeg de geparste pizza toe aan de lijst
                currentPizzaIndex++; // Update de index van de huidige pizza

                //break de loop als failsafe
                if (currentPizzaIndex == aantalPizzas)
                    break;
            }

            // toevoegen van de geparste pizzas aan de bestelling
            bestelling.Pizzas = geparstePizzas.ToArray(); // Converteer de lijst naar een array en voe toe aan het bestelobject

            return bestelling;
        }

    }

}
