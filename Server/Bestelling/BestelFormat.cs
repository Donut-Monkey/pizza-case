using Server.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Bestelling
{
    /*
    Naam, Adres en Woonplaats van klant
    Per pizza:
    - naam
    - aantal
    - extra topping (>=0)
    - beschrijving topping
    date/time bestelling
    */
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
            Console.Write
                (
                "Naam: " + Naam + "\n" +
                "Adres: " + Adres + "\n" +
                "Woonplaats: " + Woonplaats + "\n"
                );

            foreach (Pizza pizza in Pizzas)
            {
                Console.WriteLine("Pizza: " + pizza.Naam);
                if (pizza.Toppings != null && pizza.Toppings.Length > 0)
                    foreach (string topping in pizza.Toppings)
                    {
                        Console.WriteLine("Topping: " + topping);
                    }
            } 
            Console.Write
                (
                "Aantal Pizza's: " + Aantal + "\n" +
                "Toppings: " + Toppings + "\n"
                );
            Console.WriteLine(Bestelmoment + "\n");
        }
        void IBestelling.AcceptBestellingVisitor(IBestellingVisitor Visitor)
        {
            Visitor.VisitBestelFormat(this);
        }
    }
}
