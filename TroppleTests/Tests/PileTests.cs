using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gnogger_Tropple.Classes;
using System.Collections.Generic;

namespace TroppleTests
{
    [TestClass][TestCategory ("Pile")]
    public class PileTests
    {
        //[TestMethod]
        //public void Pile_Type_CountWorksCorrectly()
        //{
        //    Pile count = new Pile(1);

        //    Card x1 = new Card("X");
        //    Card x2 = new Card("X");
        //    Card y1 = new Card("Y");
        //    Card y2 = new Card("Y");
        //    Card z1 = new Card("Z");

        //    count.AddToPile(x1);
        //    count.AddToPile(x2);
        //    count.AddToPile(y1);
        //    count.AddToPile(y2);
        //    count.AddToPile(z1);

        //    //count.SetTypeCount();

        //    Dictionary<string, int> result = new Dictionary<string, int>(count.TypeCount);

        //    CollectionAssert.AreEqual(new Dictionary<string, int> { { "X", 2 }, { "Y", 2 }, { "Z", 1 },{ "O", 0 },{ "D", 0 } }, result);
        //}

        [TestMethod]
        public void Pile_Card_CountWorksCorrectly()
        {
            Pile count = new Pile(1);

            Card x1 = new Card("X");
            Card x2 = new Card("X");
            Card y1 = new Card("Y");
            Card y2 = new Card("Y");
            Card z1 = new Card("Z");

            count.AddToPile(x1);
            count.AddToPile(x2);
            count.AddToPile(y1);
            count.AddToPile(y2);
            count.AddToPile(z1);

            int result = count.PileCount;

            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void AddCardToPile_AddsCardToBackOfPile()
        {
            Pile pile = new Pile(1);

            Card x1 = new Card("X");
            Card x2 = new Card("X");
            Card y1 = new Card("Y");
            Card y2 = new Card("Y");
            Card z1 = new Card("Z");

            pile.AddToPile(x1);
            pile.AddToPile(x2);
            pile.AddToPile(y1);
            pile.AddToPile(y2);
            pile.AddToPile(z1);

            Card result = pile.CardsInPile[4];

            Assert.AreEqual(z1, result);
        }

        [TestMethod]
        public void RemoveCardFromPile_RemovesFirstCard()
        {
            Pile pile = new Pile(1);

            Card x1 = new Card("X");
            Card x2 = new Card("X");
            Card y1 = new Card("Y");
            Card y2 = new Card("Y");
            Card z1 = new Card("Z");

            pile.AddToPile(x1);
            pile.AddToPile(x2);
            pile.AddToPile(y1);
            pile.AddToPile(y2);
            pile.AddToPile(z1);

            Card removed = pile.RemoveFromPile();

            Assert.AreEqual(x1, removed);
        }

        [TestMethod]
        public void RemoveCardFromPile_LowersCardsInPileCount()
        {
            Pile pile = new Pile(1);

            Card x1 = new Card("X");
            Card x2 = new Card("X");
            Card y1 = new Card("Y");
            Card y2 = new Card("Y");
            Card z1 = new Card("Z");

            pile.AddToPile(x1);
            pile.AddToPile(x2);
            pile.AddToPile(y1);
            pile.AddToPile(y2);
            pile.AddToPile(z1);

            pile.RemoveFromPile();

            int result = pile.PileCount;

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void RemoveThirdCardFromPile_RemovesThirdCard()
        {
            Pile pile = new Pile(1);

            Card x1 = new Card("X");
            Card x2 = new Card("X");
            Card y1 = new Card("Y");
            Card y2 = new Card("Y");
            Card z1 = new Card("Z");

            pile.AddToPile(x1);
            pile.AddToPile(x2);
            pile.AddToPile(y1);
            pile.AddToPile(y2);
            pile.AddToPile(z1);

            Card removed = pile.RemoveFromPile(3);

            Assert.AreEqual(y1, removed);
        }

        [TestMethod]
        public void Bump_AddsCardToBack_RemovesCardInFront()
        {
            Pile pile = new Pile(1);

            Card x1 = new Card("X");
            Card x2 = new Card("X");
            Card y1 = new Card("Y");
            Card y2 = new Card("Y");
            Card z1 = new Card("Z");
            Card o1 = new Card("O");

            pile.AddToPile(x1);
            pile.AddToPile(x2);
            pile.AddToPile(y1);
            pile.AddToPile(y2);
            pile.AddToPile(z1);

            Card bumped = pile.Bump(o1);
            Card added = pile.CardsInPile[4];

            Assert.AreEqual(o1, added);
            Assert.AreEqual(x1, bumped);
        }
    }
}
