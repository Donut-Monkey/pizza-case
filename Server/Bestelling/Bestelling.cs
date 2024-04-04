using Server.Visitor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Bestelling
{
    public interface IBestelling
    {
        void Print();
        void AcceptBestellingVisitor(IBestellingVisitor Visitor);
    }
}
