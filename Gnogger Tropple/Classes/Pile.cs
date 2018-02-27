using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnogger_Tropple.Classes
{
    public class Pile
    {
        //Dictionary<string, int> typeCount = new Dictionary<string, int>
        //{
        //    {"X", 0 },
        //    {"Y", 0 },
        //    {"Z", 0 },
        //    {"O", 0 },
        //    {"D", 0 }
        //};

        // PROPERTIES

        //public delegate void PileEventHandler(Pile pile, EventArgs args);

        //public event PileEventHandler Troppled;

        public List<Card> CardsInPile { get; set; } = new List<Card>(); // list of cards in pile A

        public int XCount { get => CardsInPile.Count(c => c.Type == "X" || c.Type == "D"); }
        public int YCount { get => CardsInPile.Count(c => c.Type == "Y" || c.Type == "D"); }
        public int ZCount { get => CardsInPile.Count(c => c.Type == "Z" || c.Type == "D"); }
        public int OCount { get => CardsInPile.Count(c => c.Type == "O" || c.Type == "D"); }
        public int DCount { get => CardsInPile.Count(c => c.Type == "D"); }
        
        public int TypeCount(string type)
        {
            int count = 0;

            switch(type)
            {
                case "X":
                    count = XCount;
                    break;
                case "Y":
                    count = YCount;
                    break;
                case "Z":
                    count = ZCount;
                    break;
                case "O":
                    count = OCount;
                    break;
                case "D":
                    count = DCount;
                    break;
            }

            return count;
        }


        ////public int ZCount { get => CardsInPile.}

        ////public string[] AllTypes { get => CardsInPile.Select(c => c.Type).ToArray(); }



        //public int X_Count { get => TypeCount["X"]; }
        //public int Y_Count { get => TypeCount["Y"]; }
        //public int Z_Count { get => TypeCount["Z"]; }
        //public int O_Count { get => TypeCount["O"]; }
        //public int D_Count { get => TypeCount["D"]; }

        private bool HasTropX { get => XCount == 5; }
        private bool HasTropY { get => YCount == 5; }
        private bool HasTropZ { get => ZCount == 5; }
        private bool HasTropO { get => OCount == 5; }
        private bool HasTropD { get => DCount == 5; }

        public int PileCount { get => CardsInPile.Count; }

        public int Number { get; set; }

        public bool PileFull { get => PileCount == 5; }


        // CONSTRUCTOR

        public Pile(int pileNumber)
        {
            CardsInPile = new List<Card>();
            Number = pileNumber;
        }

        public Pile()
        {
            CardsInPile = new List<Card>();
        }

        // METHODS

        public Card AddToPile(Card card) //adds card to pile A. If there are Five cards in pile, the first card in pile is removed, goes to Discard
        {

            if (PileFull)
            {
                return Bump(card);
            }
            else
            {
                CardsInPile.Add(card);
                return null;
            }
            
           
        }

        /// <summary>
        /// 'Bumps' first card in pile out of pile.
        /// </summary>
        /// <param playedCard="card"></param>
        /// <returns discard></returns>
        public Card Bump(Card card)
        {
            Card discard = RemoveFromPile();
            CardsInPile.Add(card);
            return discard;
        }

        public Card RemoveFromPile() //removes one card from pile A or B, it goes to the Discard pile
        {
            Card discard = CardsInPile[0];

            CardsInPile.RemoveAt(0); // remove first Card in Pile

            return discard;
        }

        public Card RemoveFromPile(int position) // overload
        {
            Card discard = CardsInPile[position - 1];

            CardsInPile.RemoveAt(position - 1); // remove Card at position from Pile

            return discard;
        }

       /* string[] types = { "X", "Y", "Z", "O", "D" };*/ // array of types

        //private void SetTypeCount() // updates current count dictionary
        //{
        //    for (int i = 0; i < types.Length; i++)
        //    {
        //        int count = 0;

        //        foreach (Card card in CardsInPile)
        //        {
        //            if (card.Type == types[i])
        //            {
        //                count++;
        //            }
        //        }

        //        TypeCount[types[i]] = count;
        //    }
        //}

        public void Tropple(string type)
        {

        }


    }
}
