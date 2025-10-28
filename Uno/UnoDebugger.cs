using System;
using System.Collections.Generic;
using System.Text;

namespace Uno
{
    class UnoDebugger
    {
        // set up for debug messages

        public const int INFO = 1;
        public const int ERROR = 2;
        // desired level of debug output
        public const int DEBUGLEVEL = 2;


        public void DebugMessage(int level, string debugmessage)
        {
            if (level >= DEBUGLEVEL)
            {
                Console.WriteLine(debugmessage);
            }
        }
    }
}