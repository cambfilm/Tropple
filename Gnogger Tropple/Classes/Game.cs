using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Gnogger_Tropple.Classes
{
    public class Game
    {
        public Deck Deck { get; } = new Deck();

        public Player PlayerOne { get; }
        public Player PlayerTwo { get; }

        public bool IsPlayerOnesTurn { get => PlayerOne.IsCurrentPlayer; }
        public bool IsPlayerTwosTurn { get => PlayerTwo.IsCurrentPlayer; }

        //public Player CurrentPlayer { get => GetCurrentPlayer(); }
        //public Player OpposingPlayer { get => GetOpposingPlayer(); }

        public Player CurrentPlayer { get; set; } = new Player();
        public Player OpposingPlayer { get; set; } = new Player();

        //public Pile ThisPile { get => CurrentPlayer. }

        public Discard Discard { get; }

        public Game()
        {
            PlayerOne = new Player(1);
            PlayerTwo = new Player(2);

            SetStartingPlayer();
            SetCurrentPlayer();

            Pile p1A = PlayerOne.PileA;
            Pile p1B = PlayerOne.PileB;
            Pile p2A = PlayerTwo.PileA;
            Pile p2B = PlayerTwo.PileB;

            Discard = new Discard();
        }
        
        
        //-----------------------------------------\\

        public void PlayGame()
        {
            int turn = 0;
            DealHands();

            while(PlayerOne.HealthPoints > 0 && PlayerTwo.HealthPoints > 0)
            {
                PlayersTurn(CurrentPlayer);
                turn++;
                Console.WriteLine($"Player One HP : {PlayerOne.HealthPoints}");
                Console.WriteLine($"Player Two HP : {PlayerTwo.HealthPoints}");
                Console.WriteLine(turn);
                Thread.Sleep(200);
                Console.Clear();
            }

            if (PlayerOne.HealthPoints > 0)
            {
                Console.WriteLine("Player One wins");
            }
            else
            {
                Console.WriteLine("Plyaer Two wins");
            } 

        }

        //------------------------------------------\\

        public void PlayersTurn(Player player)
        {
            TurnStart(player);

            while (player.PlayCount > 0 && player.CardsInHand.Count > 0)
            {
                player.PlayCard(1, player.PileA);
            }

            TurnEnd();
        }

        public void TurnStart(Player player)
        { 
            GainLife();
            DrawTwo();

            player.PlayCount = 1 + TotalTypeCount(player, "Z"); // initialize play count
        }

        Player temp = new Player();

        public void TurnEnd()
        {
            DealDamage();
            // clear play count
            CurrentPlayer.PlayCount = 0;

            temp = CurrentPlayer;
            CurrentPlayer = OpposingPlayer;
            OpposingPlayer = temp;
        }
         
        public void DealHands() // deal each player five cards
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerOne.DrawCard(Deck.Deal(1));
                PlayerTwo.DrawCard(Deck.Deal(1));
            }
        }

        public void DrawTwo()
        {
            CurrentPlayer.DrawCard(Deck.Deal(2));
        }

        

        public void SetStartingPlayer()
        {
            Random r = new Random();

            int p = r.Next(1, 2);

            switch(p)
            {
                case 1:
                    PlayerOne.IsCurrentPlayer = true;
                    break;
                case 2:
                    PlayerTwo.IsCurrentPlayer = true;
                    break;
            }
        }

        public void SetCurrentPlayer()
        {
            if (IsPlayerOnesTurn)
            {
                CurrentPlayer = PlayerOne;
                OpposingPlayer = PlayerTwo;
            }
            else if (IsPlayerTwosTurn)
            {
                CurrentPlayer = PlayerTwo;
                OpposingPlayer = PlayerOne;
            }

            CurrentPlayer.PlayCount = 1;
            OpposingPlayer.PlayCount = 0;
        }

        //public Player GetCurrentPlayer()
        //{
        //    if(PlayerOne.IsCurrentPlayer)
        //    {
        //        return PlayerOne;
        //    }
        //    else if (PlayerTwo.IsCurrentPlayer)
        //    {
        //        return PlayerTwo;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public Player GetOpposingPlayer()
        {
            if (PlayerOne.IsCurrentPlayer)
            {
                return PlayerTwo;
            }
            else if (PlayerTwo.IsCurrentPlayer)
            {
                return PlayerOne;
            }
            else
            {
                return null;
            }
        }

        public void OnTropple(Pile pile, EventArgs e) //// EVENT HANDLER
        {
            
        }

        public int TotalTypeCount(Player player, string type) // type count "type" in both piles for Player "player"
        {
            return player.PileA.TypeCount(type) + player.PileB.TypeCount(type);
        }

        //public void ClearPile()
        //{
        //    Discard.AddToDiscard(ThisPile.CardsInPile);
        //    ThisPile.CardsInPile.Clear();
        //}

        public void ClearPile(Pile pile)
        {
            Discard.AddToDiscard(pile.CardsInPile);
            pile.CardsInPile.Clear();
        }

        //public Pile GetThisPile(Pile pile)
        //{
        //   return CurrentPlayer.
        //}

        int count = 0;

        public void DealDamage()
        {
            // check X count
            count = TotalTypeCount(CurrentPlayer, "X");
            // deal respective damage
            OpposingPlayer.HealthPoints -= (count - OpposingPlayer.Shield);
        }

        public void GainLife()
        {
            // check Y count
            count = TotalTypeCount(CurrentPlayer, "Y");
            // add to health
            CurrentPlayer.HealthPoints += count / 2;

        }
        
        public void TroppleX(Pile currentPile)
        {
            OpposingPlayer.HealthPoints -= (15 - OpposingPlayer.Shield);
            ClearPile(currentPile);
        }

        public void TroppleY(Pile pile)
        {
            CurrentPlayer.HealthPoints += 10;
            ClearPile(pile);
        }
        
        public void TroppleZ(Pile currentPile, Pile opposingPile)
        {
            ClearPile(opposingPile);
            ClearPile(currentPile);
        }

        
       
    }
}
