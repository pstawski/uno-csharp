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
            AddPlayers();
            Deal();
            // the top card in the deck

            topCard = unoDeck.GetCard();
            ShowTopCard();

            while (unoDeck.Count() > 0)
            {
                foreach (var player in players)
                {
                    discard = player.Play(topCard, unoDeck);
                    //Console.ReadLine();
                    if (discard != null)
                    {
                        topCard = discard;
                    }

                    if (player.CountHand() == 0)
                    {
                        Console.WriteLine($"{player.Name} wins!");
                        return;
                    }
                }
            }

        }
        static void AddPlayers()
        {
            // determine random number of players between 2 and 10
            int numPlayers = new Random().Next(2, 11); 

            for (int i = 0; i < numPlayers; i++)
            {
                players.Add(new UnoPlayer($"Player {i + 1}"));
            }

        }

        static void Deal()
        {
            //now deal 7 cards to each player

            for (int deal = 0; deal < 7; deal++)
            {
                foreach (var player in players)
                {
                    player.AddCard(unoDeck.GetCard());
                }
            }
        }
            
            static void ShowTopCard()
            {
                            Console.WriteLine();
            if (topCard != null)
            {
                Console.WriteLine("Top card: {0}.", topCard.ToString());
            }
            else
            {
                Console.WriteLine("Null Top Card!");
            }
            }
            

        }
}