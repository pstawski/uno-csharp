using System;
using System.Collections.Generic;
using System.Text;

namespace Uno
{
    class UnoCard
     {
        public string cardValue { get; set; }
        public string cardColor { get; set; }

        public bool isJoker { get; set; }

        public bool isReverse { get; set; }
        public bool isPlus2 { get; set; }

       public override string  ToString()
        {
            string s = $"Value: {cardValue}, color: {cardColor}";
            return s;

        }

    };
}
