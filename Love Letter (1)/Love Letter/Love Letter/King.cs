using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveLetter
{
    public class King : Card
    {
        public King(int val, Game g2) { value = val; g = g2; }

        public override string act()
        {
            g.setToCard1();

            if (g.players[g.playersTurn].card1 != null && g.players[g.playersTurn].card1.value == 6) { g.players[g.playersTurn].card1 = null; }
            else { g.players[g.playersTurn].card2 = null; }
            g.setToCard1();
            Card temp = g.players[g.playersTurn].card1;
            g.players[g.playersTurn].card1 = g.players[parameters[0]].card1;
            g.players[parameters[0]].card1 = temp;
            return "Player " + g.players[g.playersTurn] + " swapped cards with Player " + parameters[0];
        }
    }
}
