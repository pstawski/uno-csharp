using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Uno
{
    class UnoPlayer
    {
        public string Name { get; set; }

        private List<UnoCard> hand = new List<UnoCard>();

        public void AddCard(UnoCard unoCard)
        {
            hand.Add(unoCard);
        }

        public UnoPlayer(string playerName)
        {
            Name = playerName;
        }
        public void ListHand()
        {
            Console.WriteLine("Player {0}'s hand:", Name);
            foreach (UnoCard u in hand)
            {
                Console.WriteLine(u.ToString());
            }
            Console.ReadLine();
        }

        public UnoCard Play(UnoCard top, UnoDeck deck)
        {
            UnoCard newCard = new UnoCard();

            foreach (UnoCard u in hand)
            {
                if (Equals(u.cardColor, top.cardColor))
                {
                    Console.WriteLine("{0} plays {1} {2}.", Name, u.cardValue, u.cardColor);
                    hand.Remove(u);
                    CheckForUno();
                    return u;
                }
                if (Equals(u.cardValue, top.cardValue))
                {
                    Console.WriteLine("{0} plays {1} {2}.", Name, u.cardValue, u.cardColor);
                    hand.Remove(u);
                    CheckForUno();
                    return u;
                }
            }
            // can not play, so draw
            newCard = deck.GetCard();
            // check to see if we can immediately play the new card

            if (Equals(newCard.cardColor, top.cardColor))
            {
                Console.WriteLine("{0} draws and immediately plays {1} {2}.", Name, newCard.cardValue, newCard.cardColor);
                CheckForUno();
                return newCard;
            }
            if (Equals(newCard.cardValue, top.cardValue))
            {
                Console.WriteLine("{0} draws and immediately plays {1} {2}.", Name, newCard.cardValue, newCard.cardColor);
                CheckForUno();
                return newCard;
            }

            // new card is no match with top card
            Console.WriteLine("{0} draws and adds {1} {2} to their hand.", Name, newCard.cardValue, newCard.cardColor);
            hand.Add(newCard);
            // No need to check for UNO here since we have just drawn a card and increased hand size.
            return null;
        }

        void CheckForUno()
        {
            if (hand.Count == 1)
            {
                Console.WriteLine("{0} calls UNO!", Name);
            }
            else
            {
                Console.WriteLine("{0} now has {1} cards.", Name, hand.Count);
            }

        }

       public int CountHand()
        {
            return hand.Count;
        }

    }
}

