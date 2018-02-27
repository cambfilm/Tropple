using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnogger_Tropple.Classes
{
    public class Discard
    {
        public List<Card> CardsInDiscard { get; set; } = new List<Card>();

        public int DiscardCount { get => CardsInDiscard.Count; }

        public List<Card> Reshuffle()
        {
            List<Card> reshuffle = CardsInDiscard;
            CardsInDiscard.Clear();
            return reshuffle;
        }

        public void AddToDiscard(List<Card> cards)
        {
            CardsInDiscard.AddRange(cards);
        }

        public void AddToDiscard(Card card)
        {
            CardsInDiscard.Add(card);
        }
    }
}
