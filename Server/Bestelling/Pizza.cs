using System.Collections.Generic;

namespace Server.Bestelling
{
    public class Pizza
    {
        public string Naam { get; set; }
        //public string[] Toppings { get; set; }
        public List<string> Toppings { get; set; } = new List<string>();
    }
}