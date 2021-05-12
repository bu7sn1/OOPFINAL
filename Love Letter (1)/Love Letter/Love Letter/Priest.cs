using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveLetter
{
    public class Priest : Card
    {
        public Priest(int val, Game g2) { value = val; g = g2; }

        override public string act()
        {
            g.setToCard1();
            string output = "";
            if (parameters[0] != g.playersTurn && g.players[parameters[0]].card1 != null)
            {
                output = "Player " + g.playersTurn + " priested Player " + parameters[0] + ". Player " + parameters[0] + "'s card: " + "" + g.players[parameters[0]].card1.value;

            }
            if (g.players[g.playersTurn].card1 != null && g.players[g.playersTurn].card1.value == 2) { g.players[g.playersTurn].card1 = null; }
            else { g.players[g.playersTurn].card2 = null; }

            return output;
        }
    }
}
