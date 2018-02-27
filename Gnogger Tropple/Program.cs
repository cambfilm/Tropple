using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gnogger_Tropple.Classes;

namespace Gnogger_Tropple
{
    class Program
    {
        static void Main(string[] args)
        {

            //Deck deck = new Deck(); // create starting deck
            //deck.Shuffle();

            //Pile oneA = new Pile(1); // create starting Piles
            //Pile oneB = new Pile(2);
            //Pile twoA = new Pile(1);
            //Pile twoB = new Pile(2);

            //Discard discard = new Discard(); //create discard pile

            //Player one = new Player(); //deal player one starting hand
            //Player two = new Player(); //deal player two starting hand



            //Console.WriteLine("---h--a--n--d---");
            //Console.Write(" 1 -" + one.CardsInHand[0].Type + "- ");
            //Console.Write(" 2 -" + one.CardsInHand[1].Type + "- ");
            //Console.Write(" 3 -" + one.CardsInHand[2].Type + "- ");
            //Console.Write(" 4 -" + one.CardsInHand[3].Type + "- ");
            //Console.WriteLine(" 5 -" + one.CardsInHand[4].Type + "- ");
            //Console.WriteLine("---h--a--n--d---");

            //Console.WriteLine();

            //Console.WriteLine("---h--a--n--d---");
            //Console.Write(" 1 -" + two.CardsInHand[0].Type + "- ");
            //Console.Write(" 2 -" + two.CardsInHand[1].Type + "- ");
            //Console.Write(" 3 -" + two.CardsInHand[2].Type + "- ");
            //Console.Write(" 4 -" + two.CardsInHand[3].Type + "- ");
            //Console.WriteLine(" 5 -" + two.CardsInHand[4].Type + "- ");
            //Console.WriteLine("---h--a--n--d---");

            //Console.WriteLine();

            //Console.WriteLine("Player One, Choose card to play...");
            //int input = int.Parse(Console.ReadLine());

            ////Card play = new Card(one.PlayCard(input).Type);

            //Console.WriteLine("Choose a pile to play card...");
            //input = int.Parse(Console.ReadLine());

            //if (input == 1)
            //{
            //    oneA.AddToPile(play);
            //}
            //else if (input == 2)
            //{
            //    oneB.AddToPile(play);
            //}

            Game game = new Game();

            game.PlayGame();




        }
    }
}
