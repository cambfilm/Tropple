using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gnogger_Tropple.Classes
{
    

    public class Card
    {
        public virtual string Type { get; set; } //

        public bool InPile { get; set; } //tells if card is in play

        public bool IsFaceUp { get; set; }

        public Card() { }

        public Card(string type)
        {
            Type = type;
        }

    }
}
