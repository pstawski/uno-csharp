using System;
using System.Collections.Generic;
using System.Text;

namespace Uno
{
    class UnoGame
    {
        // colors of the cards
        static string[] colors = new string[] { "Red", "Yellow", "Green", "Blue" };

        //values of the cards
        static string[] values = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Zero" };

        static UnoDeck unoDeck = new UnoDeck(colors, values);

        static List<UnoPlayer> players = new List<UnoPlayer>();
        
        static UnoCard topCard = new UnoCard();

        static UnoCard discard = new UnoCard();
        // constructor 

        public UnoGame()
        {
            unoDeck.Shuffle();
            //unoDeck.ListDeck();
            
        }

        public void Play()
        {
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
                //Console.ReadLine();
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

                //Console.ReadLine();

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
                //Console.ReadLine();
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
            
           // Console.ReadLine();
        }
            
            

        }
}