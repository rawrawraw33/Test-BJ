using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BJ
{
    internal class Deck
    {
        private List<CardModel> _cards;
        private Random _rand;
        public Deck()
        {
            _cards = new List<CardModel>();
            _rand = new Random();
        }
        public void InitDeck()
        {
            _cards.Clear();
            for(var i = 2; i < 15; i++)
            {
                var name = i.ToString();
                if (i > 10)
                {
                    switch (i)
                    {
                        case 11:
                            name = "J";
                            break;
                        case 12:
                            name = "Q";
                            break;
                        case 13:
                            name = "K";
                            break;
                        case 14:
                            name = "A";
                            break;

                    }
                    
                }
                _cards.Add(new CardModel(name, CardSuit.Clubs));
                _cards.Add(new CardModel(name, CardSuit.Spades));
                _cards.Add(new CardModel(name, CardSuit.Hearts));
                _cards.Add(new CardModel(name, CardSuit.Diamonds));

            }
        }
        public CardModel TakeCard()
        {
            var index = _rand.Next(0, _cards.Count);
            CardModel card;
            
            try
            {
                card = _cards[index];
                _cards.Remove(card);
            }
            catch
            {
                InitDeck();
                return TakeCard();
            }
            
            return card;
        }
    }

}
