using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_BJ.NewFolder;

namespace Test_BJ
{
    internal class RoundController
    {

        private readonly Deck _deck;
        private readonly PlayerModel[]  _players;
        

        public RoundController(Deck deck, PlayerModel[] players)
        {
            _deck = deck;
            _players = players;
        }

        public void StartRound()
        {
            TakeCards();
            CalculateResults();

        }

        void TakeCards()
        {
            AllTakeCards(2);

            var flags = InitFlags(_players.Length);
            while (!CheckFlags(flags))
            {
                for (var i = 0; i < _players.Length; i++)
                {


                    if (i == 0 && !flags[0])
                    {
                        BankTurn(flags);
                    }
                    else
                    {
                        PlayerTurn(flags, i);
                    }
                }

            }
        }
        void AllTakeCards(int count)
        {
            for (var i = 0; i < _players.Length; i++)
            {
                for (var j = 0; j < count; j++)
                {
                    _players[i].TakeCard(_deck.TakeCard());
                }
            }
        }
        bool[] InitFlags(int count)
        {
            var flags = new bool[count];
            for (var i = 0; i < flags.Length; i++)
                flags[i] = false;
            return flags;
        }

        bool CheckFlags(bool[] flags)
        {
            var flag = true;
            for (var i = 0; i < flags.Length; i++)
            {
                flag &= flags[i];
            }
            return flag;
        }

        void BankTurn(bool[] flags)
        {
            if (_players[0].Score >= 15)
            {
                flags[0] = true;

            }
            else
            {
                _players[0].TakeCard(_deck.TakeCard());
            }
        }

        void PlayerTurn(bool[] flags, int index)
        {
            if (!flags[index])
            {
                while (true)
                {

                    Console.WriteLine($"Name: {_players[index].Name}\nScore: {_players[index].Score}\nTake card? 1 yes 2.no");
                    var choose = Console.ReadLine();
                    if (choose == "1")
                        _players[index].TakeCard(_deck.TakeCard());
                    else if (choose == "2")
                    {
                        flags[index] = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error. You should choose");
                    }
                }
            }
        }
        

        void CalculateResults()
        {
            var bank = _players[0];
            for (var i = 1; i < _players.Length; i++)
            {
                if (bank.Score <= 21)
                {
                    if (_players[i].Score > 21)
                        Console.WriteLine("Bank winner");
                    else
                    {
                        if (bank.Score > _players[i].Score)
                            Console.WriteLine("Bank winner");
                        else
                            Console.WriteLine($"{_players[i].Name} winner");
                    }
                }
                else
                {
                    if (bank.Score > _players[i].Score)
                        Console.WriteLine($"{_players[i].Name} winner");
                    else
                        Console.WriteLine("Bank winner");
                }
                Console.WriteLine($"{_players[i].Name}: {_players[i].Score}\n{bank.Name}: {bank.Score}");
               
            }

        }
    }
}
