using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Netwerk
{
    //Listener interface is blauwdruk voor de server klasses
    interface IListener
    { 
        void Send(byte[] Data);
        byte[] Receive();
    }
}
