using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gnogger_Tropple.Classes;
using System.Collections.Generic;

namespace TroppleTests.Tests
{
    [TestClass][TestCategory ("Discard")]
    public class DicardTests
    {
        [TestMethod]
        public void AddToDiscardListWorksMulitpleTimes()
        {
            Discard discard = new Discard();

            Card y1 = new Card("Y");
            Card y2 = new Card("Y");
            Card y3 = new Card("Y");
            Card y4 = new Card("Y");

            discard.AddToDiscard(y2);
            discard.AddToDiscard(y2);
            discard.AddToDiscard(y2);
            discard.AddToDiscard(y1);

            int result = discard.CardsInDiscard.Count;

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void RemoveFromPileAddsToDiscard()
        {
            Discard discard = new Discard();
            Pile pile = new Pile(1);

            Card y1 = new Card("Y");
            Card y2 = new Card("Y");
            Card y3 = new Card("Y");
            Card y4 = new Card("Y");

            pile.AddToPile(y1);
            pile.AddToPile(y2);
            pile.AddToPile(y3);
            pile.AddToPile(y4);

            discard.AddToDiscard(pile.RemoveFromPile(1));
            discard.AddToDiscard(pile.RemoveFromPile(1));
            discard.AddToDiscard(pile.RemoveFromPile(1));

            int result = discard.CardsInDiscard.Count;

            Assert.AreEqual(3, result);
        }

    }
}
