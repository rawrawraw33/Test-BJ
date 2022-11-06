using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BJ.NewFolder
{
    internal class PlayerModel
    {
        private string _name = "Player1";
        private List<CardModel> _hand;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("name cannot be empty");
                _name = value;
            }
        }
        public CardModel[] Hand
        {
            get
            {
                var array = new CardModel[_hand.Count];
                for (var i = 0; i < _hand.Count; i++)
                {
                    array[i] = new CardModel(_hand[i]);
                }
                return array;
            }
        }
        public int Score
        {
            get
            {
                var sum = 0;
                for (var i = 0; i < _hand.Count; i++)
                {
                    sum += _hand[i].Value;
                }
                return sum;
            }
        }
        public PlayerModel()
        {
            _hand = new List<CardModel>();
        }

        public void TakeCard(CardModel card) => _hand.Add(card);

       
        public void ClearHand() => _hand.Clear();
    }
}
