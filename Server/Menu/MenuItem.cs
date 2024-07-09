using Server.Menu;
using Server;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Menu
{
    public interface IMenuItem
    {
        void Print();
    }
    public class MenuItem : IMenuItem
    {
        public string Naam { get; set; }
        public decimal Prijs { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Naam} - €{Prijs}");
        }
    }
    public class MenuCategorie : IMenuItem
    {
        private List<IMenuItem> _items = new List<IMenuItem>();

        public string Naam { get; set; }

        public void Add(IMenuItem item)
        {
            _items.Add(item);
        }

        public void Remove(IMenuItem item)
        {
            _items.Remove(item);
        }

        public void Print()
        {
            Console.WriteLine(Naam);
            foreach (var item in _items)
            {
                item.Print();
            }
        }
    }
    public class Pizza : IMenuItem
    {
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public List<IMenuItem> Toppings { get; set; } = new List<IMenuItem>();

        public void Print()
        {
            Console.WriteLine($"Pizza: {Naam} - €{Prijs}");
            Console.WriteLine("Toppings:");
            foreach (var topping in Toppings)
            {
                topping.Print();
            }
        }
    }

    public class Topping : IMenuItem
    {
        public string Naam { get; set; }
        public decimal Prijs { get; set; }

        public void Print()
        {
            Console.WriteLine($"- {Naam} - €{Prijs}");
        }
    }

}
//if (Auth.Authorize(request[0]) == true)
//{
//    // Voorbeeld van het omzetten van ontvangen gegevens naar een Pizza object
// pizza omzetten naar bestelling met daarin pizza met daarin toppings
//    Pizza pizza = new Pizza { Naam = "Margherita", Prijs = 10.00m };
//    pizza.Toppings.Add(new Topping { Naam = "Extra kaas", Prijs = 1.00m });
//    pizza.Toppings.Add(new Topping { Naam = "Pijnboompitten", Prijs = 0.50m });

//    // Voeg de pizza toe aan een categorie in de bestelling
//    MenuCategorie bestelling = new MenuCategorie { Naam = "Bestelling" };
//    bestelling.Add(pizza);

//    // Print de bestelling
//    bestelling.Print();
//}
