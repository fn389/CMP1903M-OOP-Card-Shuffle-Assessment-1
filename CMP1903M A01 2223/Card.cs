using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        private int _value;
        private int _suit;
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        public int Suit
        {
            get
            {
                return _suit;
            }
            set
            {
               _suit = value;
            }
        }
        public Card(int _value, int _suit)
        {
            Value = _value;
            Suit = _suit;
        }
    }
}
