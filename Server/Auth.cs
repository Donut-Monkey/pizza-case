using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Auth
    {
        //simpele beveiliging van server
        public static bool Authorize(string Key)
        {
            if (Key == "P1c4G0bR")
                return true;
            else
                return false;
        }
    }
}
