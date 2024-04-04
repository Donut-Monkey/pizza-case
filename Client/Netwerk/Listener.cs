using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Netwerk
{
    interface Listener
    {
        void Send(byte[] Data);
        byte[] Receive();
    }
}
