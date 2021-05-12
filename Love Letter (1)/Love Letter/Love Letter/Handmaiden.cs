using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveLetter
{
    public class Handmaiden : Card
    {
        public Handmaiden(int val, Game g2) { value = val; g = g2; }

        override public string act()
        {
            g.setToCard1();
            g.players[g.playersTurn].handmaided = true;

            if (g.players[g.playersTurn].card1 != null && g.players[g.playersTurn].card1.value == 4) { g.players[g.playersTurn].card1 = null; }
            else { g.players[g.playersTurn].card2 = null; }

            return "";
        }
    }
}
