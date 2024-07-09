using Server.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Bestelling
{
    public class BestelLijst : IBestelling
    {
        private readonly List<BestelFormat> _bestellingen;
        public BestelLijst()
        {
            _bestellingen = new List<BestelFormat>();
        }
        public void Print()
        {
            for (int i = 0; i < _bestellingen.Count; i++)
            {
                //bestelling 0 is eerste bestelling
                int j = i + 1;
                Console.WriteLine("Bestelling " + j + ": ");
                _bestellingen[i].Print();
            }
        }
        public void Add(BestelFormat Bestelling)
        {
            _bestellingen.Add(Bestelling);
        }

        public void AcceptBestellingVisitor(IBestellingVisitor Visitor)
        {
            //Visitor.VisitBestelLijst(this);
            Console.WriteLine("AcceptBestellingVisitor aangeroepen in BestelLijst");
            foreach (var bestelling in _bestellingen)
            {
                bestelling.AcceptBestellingVisitor(Visitor);
            }
        }

    }
}
