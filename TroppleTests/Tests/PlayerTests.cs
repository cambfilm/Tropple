using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gnogger_Tropple.Classes;

namespace TroppleTests.Tests
{
    [TestClass][TestCategory ("Player")]
    public class PlayerTests
    {
        [TestMethod]
        public void PlayerStartsWithEmptyHand()
        {
            Player player = new Player();

            int result = player.CardsInHand.Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void DrawCard_AddsCardToHand()
        {
            Pile pile = new Pile(1);
            Player player = new Player();

            Card x1 = new Card("X");
            Card x2 = new Card("X");
            Card y1 = new Card("Y");
            Card y2 = new Card("Y");
            Card z1 = new Card("Z");

            player.DrawCard(x2);

            Card result = player.CardsInHand[0];

            Assert.AreEqual(x2, result);
        }

        [TestMethod]
        public void PlayCard_AddsCardToPile()
        {
            Pile pile = new Pile(1);
            Player player = new Player();

            Card x1 = new Card("X");
            Card x2 = new Card("X");
            Card y1 = new Card("Y");
            Card y2 = new Card("Y");
            Card z1 = new Card("Z");

            player.DrawCard(x2);
            player.PlayCard(1, pile);

            Card pileResult = pile.CardsInPile[0];

            Assert.AreEqual(x2, pileResult);
        }

        [TestMethod]
        public void PlayCard_RemovesCardFromHand()
        {
            Pile pile = new Pile(1);
            Player player = new Player();

            Card x1 = new Card("X");
            Card x2 = new Card("X");
            Card y1 = new Card("Y");
            Card y2 = new Card("Y");
            Card z1 = new Card("Z");

            player.DrawCard(x2);
            player.PlayCard(1, pile);

            int result = player.CardsInHand.Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void PlayCard_CostsPlayerPlayCount()
        {
            Pile pile = new Pile(1);
            Player player = new Player();

            Card x1 = new Card("X");
            Card x2 = new Card("X");
            Card y1 = new Card("Y");
            Card y2 = new Card("Y");
            Card z1 = new Card("Z");

            player.PlayCount = 1;
            player.DrawCard(x2);
            player.PlayCard(1, pile);

            int result = player.PlayCount;

            Assert.AreEqual(0, result);
        }


    }
}
