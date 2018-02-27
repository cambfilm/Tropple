using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gnogger_Tropple.Classes;
using System.Collections.Generic;

namespace TroppleTests.Tests
{
    
    [TestClass][TestCategory ("Game")]
    public class GameTests
    {
        Game game;
        Card x1;
        Card x2;
        Card x3;
        Card y1;
        Card y2;
        Card z1;
        Card o1;
        Card d1;


        [TestInitialize]
        public void Initialize()
        {
            game = new Game();
            x1 = new Card("X");
            x2 = new Card("X");
            x3 = new Card("X");
            y1 = new Card("Y");
            y2 = new Card("Y");
            z1 = new Card("Z");
            o1 = new Card("O");
            d1 = new Card("D");
           
        }
        
        [TestMethod]
        public void DealHands_DealsFiveCardsToEachPlayer()
        {
            game.DealHands();

            int one = game.PlayerOne.CardsInHand.Count;
            int two = game.PlayerTwo.CardsInHand.Count;

            Assert.AreEqual(5, one);
            Assert.AreEqual(5, two);
        }

        [TestMethod]
        public void CurrentPlayerPlayCountToOne_OpposingToZero()
        {
            game.TurnStart(game.CurrentPlayer);

            int current = game.CurrentPlayer.PlayCount;
            int opposing = game.OpposingPlayer.PlayCount;

            Assert.AreEqual(1, current);
            Assert.AreEqual(0, opposing);
        }

        [TestMethod]
        public void SetStartingPlayer_SetsPlayCounts()
        {
            game.TurnStart(game.CurrentPlayer);

            int current = game.CurrentPlayer.PlayCount;
            int opposing = game.OpposingPlayer.PlayCount;

            Assert.AreEqual(1, current);
            Assert.AreEqual(0, opposing);
        }

        [TestMethod]
        public void TurnStart_GainsCurrentPlayerLife()
        {
            game.PlayerOne.PileA.AddToPile(y1);
            game.PlayerOne.PileA.AddToPile(y2);
            game.PlayerOne.PileA.AddToPile(y2);
            game.PlayerOne.PileA.AddToPile(y1);

            //game.PlayerOne.PileA.SetTypeCount();

            game.TurnStart(game.PlayerOne);

            int life = game.PlayerOne.HealthPoints;

            Assert.AreEqual(102, life);
        }

        [TestMethod]
        public void TurnStartDrawsTwoCardsForCurrentPlayer()
        {
            game.DealHands();

            game.TurnStart(game.PlayerOne);

            int result = game.PlayerOne.CardsInHand.Count;

            Assert.AreEqual(7, result);

        }

        [TestMethod]
        public void EndOfTurn_DealsDamageToOpposingPlayer()
        {
            game.PlayerOne.PileA.AddToPile(x1);
            game.PlayerOne.PileA.AddToPile(x2);
            game.PlayerOne.PileA.AddToPile(x3);
            game.PlayerOne.PileA.AddToPile(x2);

            //game.PlayerOne.PileA.SetTypeCount();

            game.TurnEnd();

            int life = game.PlayerTwo.HealthPoints;

            Assert.AreEqual(96, life);
        }

        [TestMethod]
        public void ClearPileAddsCardsInPileToDiscard_EmptiesPile()
        {
            Game game = new Game();
            Pile pile = game.PlayerOne.PileA;
            Discard discard = game.Discard;

            pile.AddToPile(x1);
            pile.AddToPile(x2);
            pile.AddToPile(x3);
            pile.AddToPile(y1);

            game.ClearPile(pile);

            int discardCount = discard.DiscardCount;
            int pileCount = pile.PileCount;

            Assert.AreEqual(4, discardCount);
            Assert.AreEqual(0, pileCount);
        }

        [TestMethod]
        public void TroppleX_RemovesAllXFromPile()
        {
            game.PlayerOne.IsCurrentPlayer = true;
            

            game.CurrentPlayer.PileA.AddToPile(x1);
            game.CurrentPlayer.PileA.AddToPile(x2);
            game.CurrentPlayer.PileA.AddToPile(x3);
            game.CurrentPlayer.PileA.AddToPile(x3);

            game.TroppleX(game.CurrentPlayer.PileA);
 
            int result = game.CurrentPlayer.PileA.XCount;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TroppleX_Deals15Damage()
        {
            Game game = new Game();
            Pile pile = game.PlayerOne.PileA;
            game.PlayerOne.IsCurrentPlayer = true;

            pile.AddToPile(x2);
            pile.AddToPile(x1);
            pile.AddToPile(x3);
            pile.AddToPile(x1);

            game.TroppleX(pile);
            
            int life = game.PlayerTwo.HealthPoints;

            Assert.AreEqual(85, life);
        }
    }
}
