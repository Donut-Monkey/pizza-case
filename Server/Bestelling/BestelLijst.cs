using Server.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Bestelling
{
    public class BestelLijst : Bestelling
    {
        private readonly List<BestelFormat> _orders;
        public BestelLijst()
        {
            _orders = new List<BestelFormat>();
        }
        public void Print()
        {
            for (int i = 0; i < _orders.Count; i++)
            {
                int j = i + 1;
                Console.WriteLine("Bestelling " + j + ": ");
                _orders[i].Print();
            }
        }
        public void Add(BestelFormat Bestelling)
        {
            _orders.Add(Bestelling);
        }

        public void AcceptBestellingVisitor(BestellingVisitor Visitor)
        {
            Visitor.VisitBestelLijst(this);
        }
    }
}
