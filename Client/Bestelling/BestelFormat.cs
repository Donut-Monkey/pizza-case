using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Bestelling
{
    public class BestelFormat
    {
        public string Naam { get; }
        public string Adres { get; }
        public string Woonplaats { get; }
        public Pizza[] Pizzas { get; }
        public int Aantal { get; }
        public int Toppings { get; }
        public DateTime Bestelmoment { get; }

        public BestelFormat(string naam, string adres, string woonplaats, Pizza[] pizzas, int aantal, int toppings, DateTime bestelmoment)
        {
            Naam = naam;
            Adres = adres;
            Woonplaats = woonplaats;
            Pizzas = pizzas;
            Aantal = aantal;
            Toppings = toppings;
            Bestelmoment = bestelmoment;
        }
    }
}