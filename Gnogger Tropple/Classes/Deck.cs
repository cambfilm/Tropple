using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnogger_Tropple.Classes
{
    public class Deck
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public int DeckCount { get => Cards.Count; }
        
        public Deck()
        {
            string[] types = { "X", "Y", "Z", "O", "D" }; //types of cards

            foreach (string type in types) //creates 20 cards of each type
            {
                for (int i = 0; i < 20; i++)
                {
                    Card c = new Card(type);
                    Cards.Add(c);
                }
            }

            Shuffle();
        }

        public Random r = new Random();

        public void Shuffle()
        {
            for (int n = Cards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;
            }

        }

        public List<Card> Deal(int amount) //deals a card to player, removes one from deck
        {
            List<Card> cardsDealt = new List<Card>();

            for (int i = 0; i < amount; i++) //deals amount of cards from deck
            {
                if (Cards.Count > 0) //checks if there are any cards in the deck
                {
                    cardsDealt.Add(Cards[0]); //adds card from top of the deck to list of cards being dealt
                    Cards.Remove(cardsDealt[i]); //removes card being dealt from deck list
                }
            }
            return cardsDealt; //returns list of cards dealt
        }




    }
}
