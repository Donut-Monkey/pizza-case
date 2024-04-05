using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Netwerk
{
    interface IListener
    {
        void Send(byte[] Data);
        byte[] Receive();
    }
}
