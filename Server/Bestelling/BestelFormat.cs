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
    public class BestelFormat : Bestelling
    {
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Woonplaats { get; set; }
        public string[] Pizza { get; set; }
        public int Aantal { get; set; }
        public int Toppings { get; set; }
        public string[] ToppingBescrhijving { get; set; }
        public DateTime Bestelmoment { get; set; }

        public BestelFormat() { }

        public BestelFormat(string naam, string adres, string woonplaats, string[] pizza, int aantal, int toppings, string[] toppingBescrhijving, DateTime bestelmoment)
        {
            Naam = naam;
            Adres = adres;
            Woonplaats = woonplaats;
            Pizza = pizza;
            Aantal = aantal;
            Toppings = toppings;
            ToppingBescrhijving = toppingBescrhijving;
            Bestelmoment = bestelmoment;
        }

        public void Print()
        {
            Console.Write
                (
                Naam + "\n" +
                Adres + "\n" +
                Woonplaats + "\n"
                );

            foreach (string pizza in Pizza)
            {
                Console.WriteLine(pizza);  
            }
            foreach (string topping in ToppingBescrhijving)
            {
                Console.WriteLine(topping);
            }
            Console.Write
                (
                Aantal + "\n" +
                Toppings + "\n"
                );

            Console.WriteLine(Bestelmoment);
            //print de extra toppings nu onderaan ipv na elke pizza
        }

        //belangrijk zodat compiler weet deze class bezocht wordt
        void Bestelling.AcceptBestellingVisitor(BestellingVisitor Visitor)
        {
            Visitor.VisitBestelFormat(this);
        }
    }
}
