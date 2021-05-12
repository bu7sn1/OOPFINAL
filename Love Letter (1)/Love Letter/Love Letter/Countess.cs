using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveLetter
{
    public class Countess : Card
    {
        public Countess(int val, Game g2) { value = val; g = g2; }

        override public string act()
        {
            g.setToCard1();
            if (g.players[g.playersTurn].card1 != null && g.players[g.playersTurn].card1.value == 7) { g.players[g.playersTurn].card1 = null; }
            else { g.players[g.playersTurn].card2 = null; }
            return "Player " + g.players[g.playersTurn] + " dropped the Countess.";
        }
    }
}
