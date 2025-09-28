using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Uno
{
    class UnoPlayer
    {
        public string PlayerName { get; set; }

        private List<UnoCard> hand = new List<UnoCard>();

        public void AddCard(UnoCard unoCard)
        {
            hand.Add(unoCard);
        }

        public UnoPlayer(string playerName)
        {
            PlayerName = playerName;
        }
        public void ListHand()
        {
            Console.WriteLine("Player {0}'s hand:", PlayerName);
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
                    Console.WriteLine("{0} plays {1} {2}.", PlayerName, u.cardValue, u.cardColor);
                    hand.Remove(u);
                    CheckForUno();
                    return u;
                }
                if (Equals(u.cardValue, top.cardValue))
                {
                    Console.WriteLine("{0} plays {1} {2}.", PlayerName, u.cardValue, u.cardColor);
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
                Console.WriteLine("{0} draws and immediately plays {1} {2}.", PlayerName, newCard.cardValue, newCard.cardColor);
                CheckForUno();
                return newCard;
            }
            if (Equals(newCard.cardValue, top.cardValue))
            {
                Console.WriteLine("{0} draws and immediately plays {1} {2}.", PlayerName, newCard.cardValue, newCard.cardColor);
                CheckForUno();
                return newCard;
            }

            // new card is no match with top card
            Console.WriteLine("{0} draws and adds {1} {2} to their hand.", PlayerName, newCard.cardValue, newCard.cardColor);
            hand.Add(newCard);
            //To Do: find a better name, because it is illogical to Check for Uno here since we have just drawn....
            CheckForUno();
            return null;
        }

        void CheckForUno()
        {
            if (hand.Count == 1)
            {
                Console.WriteLine("{0} calls UNO!", PlayerName);
            }
            else
            {
                Console.WriteLine("{0} now has {1} cards.", PlayerName, hand.Count);
            }

        }

       public int CountHand()
        {
            return hand.Count;
        }

    }
}

