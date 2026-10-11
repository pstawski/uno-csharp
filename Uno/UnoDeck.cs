using System;
using System.Collections.Generic;
using System.Text;

namespace Uno
{
    class UnoDeck
    {
        private List<UnoCard> deck = [];
        private int nextCard = 0;

        public UnoDeck(string[] colors, string[] values)
        {

            // initialize the deck with color*number combinations
            foreach (string color in colors)
            {
                foreach (string value in values)
                {
                    // add two of each
                    for (int i = 0; i < 2; i++)
                    {
                        deck.Add(new UnoCard( value,  color,  UnoCardType.Number));
                    }
                }

                // add specials
                deck.Add(new UnoCard(CardValue: "Reverse", CardColor: color, CardType: UnoCardType.Reverse));

                deck.Add(new UnoCard("Plus Two", color, UnoCardType.Plus2));
            }
        }

        public int Count()
        {
            // number of items in the deck
            return deck.Count;
        }

        public void Shuffle()
        {
            UnoCard tmpCard = new();
            int magic = 255;
            int idx1;
            int idx2;
            Random rnd = new();

            for (int i = 0; i < magic; i++)
            {
                idx1 = rnd.Next(0, deck.Count);
                idx2 = rnd.Next(0, deck.Count);
                tmpCard = deck[idx1];
                deck[idx1] = deck[idx2];
                deck[idx2] = tmpCard;
            }

        }

        public UnoCard GetCard()
        {
            if (nextCard < deck.Count)
            {
                return deck[nextCard++];
            }
            // else
            return null;
        }

        public void ListDeck()
        {
            foreach (UnoCard card in deck)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
