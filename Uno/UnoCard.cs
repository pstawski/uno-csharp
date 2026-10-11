using System;
using System.Collections.Generic;
using System.Text;

namespace Uno
{
   public enum UnoCardType
    {
        Number,
        Reverse,
        Plus2,
        Joker
    }

    public record UnoCard (string CardValue, string CardColor, UnoCardType CardType)
     {/* 
        public required string CardValue { get; init; }
        public required string CardColor { get; init; }
        public required UnoCardType CardType { get; init; } */

        private readonly Dictionary<UnoCardType, string>  cardTypeString = new Dictionary<UnoCardType, string>
        {
            { UnoCardType.Number, "Number" },
            { UnoCardType.Reverse, "Reverse" },
            { UnoCardType.Plus2, "Plus Two" },
            { UnoCardType.Joker, "Joker" }
        };


/*         public UnoCard(string value, string color, UnoCardType type)
        {
            CardValue = value;
            CardColor = color;
            CardType = type;
        } */


       public override string  ToString()
        {
            
            return $"{CardValue} {CardColor} ({cardTypeString[CardType]})";

        }

    };
}
