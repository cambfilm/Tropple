using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnogger_Tropple.Classes
{
    public class Player
    {
        public List<Card> CardsInHand { get; set; }

        public int PlayCount { get; set; } // amount of cards player is currrently able to play
        public int HealthPoints { get; set; } // starting HP for player
        public int Shield { get => GetShield(); } // starting amount of damage being blocked

        public Pile PileA { get; set; }
        public Pile PileB { get; set; }

        public int PlayerNumber { get; set; }

        public bool IsCurrentPlayer { get; set; }

        public void DrawCard(List<Card> cards)
        {
            CardsInHand.AddRange(cards);
        }

        public void DrawCard(Card card)
        {
            CardsInHand.Add(card);
        }

        public void PlayCard(int p, Pile pile) // plays a Card in position "p" to Pile number "pile"
        {
            if(CardsInHand.Count > 0)
            {
                Card play = CardsInHand[p - 1]; // assigns card being played to "play"

                CardsInHand.RemoveAt(p - 1); // removes card being played from hand

                PlayCount--; // subtracts a play count from players total

                pile.AddToPile(play); // returns card being played
            }

        }

        public Player(int playerNumber)
        {
            CardsInHand = new List<Card>();
            PlayCount = 0;
            HealthPoints = 100;
            PileA = new Pile(1);
            PileB = new Pile(2);
            PlayerNumber = playerNumber;
        }

        public Player()
        {
            CardsInHand = new List<Card>();
            PlayCount = 0;
            HealthPoints = 100;
            PileA = new Pile(1);
            PileB = new Pile(2);
        }

        public int GetShield()
        {
            int shield = 0;

            if (PileA.OCount >= 2)
            {
                shield += 2;
            }
            else if (PileA.OCount >= 4)
            {
                shield += 5;
            }

            if (PileB.OCount >= 2)
            {
                shield += 2;
            }
            else if (PileB.OCount >= 4)
            {
                shield += 5;
            }

            return shield;
        }


    }
}
