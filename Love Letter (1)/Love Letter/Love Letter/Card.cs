using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveLetter
{
    public class Card
    {
        public int value;
        public Game g;
        public int[] parameters;
        public Card() { }
        public Card(int val, Game g2) { value = val; g = g2; }
        virtual public string act() { return ""; }
        public String numToCard(int num)
        {
            if (num == 1) { return "Guard"; }
            if (num == 2) { return "Priest"; }
            if (num == 3) { return "Baron"; }
            if (num == 4) { return "Handmaiden"; }
            if (num == 5) { return "Prince"; }
            if (num == 6) { return "King"; }
            if (num == 7) { return "Countess"; }
            else { return "Princess"; }
        }
    }
}
