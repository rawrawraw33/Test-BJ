using System;
using System.Numerics;
using System.Reflection;
using Test_BJ.NewFolder;

namespace Test_BJ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void InitGame()
            {

                var deck = new Deck();
                var bank = new PlayerModel() { Name = "Bank" };
                PlayerModel player1;

                while (true)
                {
                    Console.Write("Enter player name: ");
                    var name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))

                        Console.Write("name is empty ");
                    else
                    {
                        player1 = new PlayerModel() { Name = name };
                        break;
                    }

                }

                var round = new RoundController(deck, new PlayerModel[] { bank, player1 });

                round.StartRound();
            }
            
            InitGame();
        }
        
    }
}


        