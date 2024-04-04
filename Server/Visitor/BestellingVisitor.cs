using Server.Bestelling;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Visitor
{
    public interface IBestellingVisitor
    {
        void VisitBestelFormat(BestelFormat BestelFormat);

        void VisitBestelLijst(BestelLijst BestelLijst);
    }
}
