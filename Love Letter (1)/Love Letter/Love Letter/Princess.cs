using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveLetter
{
    public class Princess : Card
    {
        public Princess(int val, Game g2) { value = val; g = g2; }

        override public string act()
        {
            g.setToCard1();

            if (g.players[g.playersTurn].card1 != null && g.players[g.playersTurn].card1.value == 8) { g.players[g.playersTurn].card1 = null; }
            else { g.players[g.playersTurn].card2 = null; }
            g.players[g.playersTurn].card1 = null;
            g.players[g.playersTurn].card2 = null;
            g.players[g.playersTurn].lost = true;
           return "Player " + g.playersTurn + " was eliminated for dropping the Princess.";
        }
    }
}
