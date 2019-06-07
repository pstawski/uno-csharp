using System;
using System.Collections;
using System.Collections.Generic;

namespace Uno
{
    class Program
    {
        static void Main(string[] args)
        {
            // colors of the cards
            string[] colors = new string[] { "Red", "Yellow", "Green", "Blue" };

            //values of the cards
            string[] values = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Zero" };

            UnoDeck unoDeck = new UnoDeck(colors, values);

            unoDeck.Shuffle();
            //unoDeck.ListDeck();

            List<UnoPlayer> players = new List<UnoPlayer>();

            UnoPlayer barbara = new UnoPlayer("Barbara");
            UnoPlayer john = new UnoPlayer("John");
            UnoPlayer michael = new UnoPlayer("Michael");

            players.Add(barbara);
            players.Add(john);
            players.Add(michael);

            

           

            //now deal 7 cards to each player

            for (int deal = 0; deal < 7; deal++)
            {
                barbara.AddCard(unoDeck.GetCard());
                john.AddCard(unoDeck.GetCard());
                michael.AddCard(unoDeck.GetCard());
                }

            // the top card in the deck
            UnoCard topCard = new UnoCard();
            topCard = unoDeck.GetCard();

            Console.WriteLine();
            if (topCard != null)
            {
                Console.WriteLine("Top card: {0}.", topCard.ToString());
            }
            else
            {
                Console.WriteLine("Null Top Card!");
            }
            

            UnoCard discard = new UnoCard();
            
            while (unoDeck.Count() > 0)
            {
                discard = barbara.Play(topCard, unoDeck);
                Console.ReadLine();
                if (discard != null)
                {
                    topCard = discard;
                }

                if (barbara.CountHand() == 0)
                {
                    Console.WriteLine("Barbara wins!");
                    break;
                }

                discard = john.Play(topCard, unoDeck);
                Console.ReadLine();
                if (discard != null)
                {
                    topCard = discard;
                }

                if (john.CountHand() == 0)
                {
                    Console.WriteLine("John wins!");
                    break;
                }
                discard = michael.Play(topCard, unoDeck);
                Console.ReadLine();
                if (discard != null)
                {
                    topCard = discard;
                }

                if (michael.CountHand() == 0)
                {
                    Console.WriteLine("Michael wins!");
                    break;
                }
            }
            
            Console.ReadLine();

        }
    }
}
