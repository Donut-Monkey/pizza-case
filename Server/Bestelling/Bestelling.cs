using Server.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Bestelling
{
    public interface Bestelling
    {
        void Print();
        void AcceptBestellingVisitor(BestellingVisitor Visitor);
    }
}
