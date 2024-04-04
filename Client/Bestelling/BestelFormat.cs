using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Bestelling
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
    public class BestelFormat
    {
        public string Naam { get; }
        public string Adres { get; }
        public string Woonplaats { get; }
        public string[] Pizza { get; }
        public int Aantal { get; }
        public int Toppings { get; }
        public string[] ToppingBescrhijving { get; }
        public DateTime Bestelmoment { get; }

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

        //public void Print()
        //{
        //    Console.WriteLine
        //        (
        //        Naam + "\n" +
        //        Adres + "\n" +
        //        Woonplaats + "\n" +
        //        Pizza + "\n" +
        //        Aantal + "\n" +
        //        Toppings + "\n"
        //        );
        //    foreach (string Topping in ToppingBescrhijving)
        //    {
        //        Console.WriteLine(ToppingBescrhijving);
        //    }
        //    Console.WriteLine(Bestelmoment);
        //}
    }
}