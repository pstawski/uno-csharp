using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Uno
{
    class UnoPlayer
    {
        public string Name { get; set; }

        private List<UnoCard> hand = [];

        static UnoDebugger debug = new();

        

        public void AddCard(UnoCard unoCard)
        {
            hand.Add(unoCard);
        }

        public UnoPlayer(string playerName)
        {
            Name = playerName;
            
            debug.DebugMessage(UnoDebugger.INFO, $"Player {this.Name} has joined the game." );
        }
        public void ListHand()
        {
            debug.DebugMessage(UnoDebugger.INFO, $"Player {this.Name}'s hand:");
            
            foreach (UnoCard u in hand)
            {
                debug.DebugMessage(UnoDebugger.INFO, u.ToString());
                
            }
            Console.ReadLine();
        }

        public UnoCard Play(UnoCard top, UnoDeck deck)
        {
            foreach (UnoCard u in this.hand)
            {
                if (Equals(u.cardColor, top.cardColor) | Equals(u.cardValue, top.cardValue))
                {
                    debug.DebugMessage(UnoDebugger.INFO, $"{this.Name} plays {u.cardValue} {u.cardColor}.");
                    

                    this.hand.Remove(u);
                    CheckForUno();
                    return u;
                }
        
            }
            // can not play, so draw
            UnoCard newCard = new();
            if (deck.Count() == 0)
            {
               debug.DebugMessage(UnoDebugger.ERROR, $"Deck is empty, cannot draw a card.");
                
                return null;
            }
            newCard = deck.GetCard();
            if (newCard == null)
            {
               debug.DebugMessage(UnoDebugger.ERROR,$"Draw returned NULL.");
            
                return null;
            }
            // check to see if we can immediately play the new card

            if (Equals(newCard.cardColor, top.cardColor) | Equals(newCard.cardValue, top.cardValue))
            {
               debug.DebugMessage(UnoDebugger.INFO,$"{this.Name} draws and immediately plays {newCard.cardValue} {newCard.cardColor}.");
               
                CheckForUno();
                return newCard;
            }


            // new card is no match with top card
            debug.DebugMessage(UnoDebugger.INFO ,$"{this.Name} draws and adds {newCard.cardValue} {newCard.cardColor} to their hand.");
          

            hand.Add(newCard);
            // No need to check for UNO here since we have just drawn a card and increased hand size.
           debug.DebugMessage(UnoDebugger.INFO , $"{this.Name} now has {hand.Count} cards.");
            
            return null;
        }

        void CheckForUno()
        {
            if (hand.Count == 1)
            {
                debug.DebugMessage(UnoDebugger.INFO , $"{Name} calls UNO!");
                
            }
            else
            {
                debug.DebugMessage(UnoDebugger.INFO , $"{Name} now has {hand.Count} cards.");
                
            }

        }

        public int CountHand()
        {
            return hand.Count;
        }
        
        

    }
}

