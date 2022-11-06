using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BJ
{
    public enum CardSuit
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }
    internal class CardModel
    {
        private string _name;
        private CardSuit _suit;
        private int _value;
        
        private string[] _names = new string[] {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        public string Name
        {
            get => _name;
            protected set
            {
                if (!_names.Contains(value))
                    throw new ArgumentException("nevernoe name karty");
                _name = value;
            }
        }
        public CardSuit Suit => _suit;
        public int Value => _value;


        public CardModel(string name, CardSuit suit)
        {
            Name = name;
            _suit = suit;

            int value;
            try
            {
                value = int.Parse(name);
            }
            catch
            {
                if (name == "J" || name == "Q" || name == "K")
                    value = 10;
                else
                    value = 11;
            }
            _value = value;
        }

        public CardModel(CardModel card) : this (card.Name , card.Suit)
        { }

    } }
