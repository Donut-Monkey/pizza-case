using Server.Bestelling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Visitor
{
    public class PrintVisitor : IBestellingVisitor
    {
        public void VisitBestelFormat(BestelFormat bestelFormat)
        {
            Console.WriteLine("VisitBestelFormat aangeroepen");
            bestelFormat.Print();
        }

        public void VisitBestelLijst(BestelLijst bestelLijst)
        {
            bestelLijst.AcceptBestellingVisitor(this);

            //foreach (var bestelItem in bestelLijst._bestellingen)
            //{
            //    bestelItem.AcceptBestellingVisitor(this); // Roep AcceptBestellingVisitor aan op elk item in de lijst
            //}
        }

    }

}
