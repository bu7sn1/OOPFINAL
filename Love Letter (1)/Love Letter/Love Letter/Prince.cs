using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveLetter
{
    public class Prince : Card
    {
        public Prince(int val, Game g2) { value = val; g = g2; }

        override public string act()
        {
            g.setToCard1();
            if (g.players[parameters[0]].card1.value == 8) { g.players[parameters[0]].card1 = null; g.players[parameters[0]].lost = true; }
            else if (g.players[parameters[0]].card2 != null && g.players[parameters[0]].card2.value == 8) { g.players[parameters[0]].card2 = null; g.players[parameters[0]].lost = true; }
            else
            {
                if (parameters[0] == g.playersTurn)
                {
                    g.players[parameters[0]].card1 = null;
                    g.players[parameters[0]].card2 = null;
                    g.drawCard(g.players[parameters[0]]);
                }
                else
                {
                    g.players[parameters[0]].card1 = null;
                    g.drawCard(g.players[parameters[0]]);
                }
            }

            if (g.players[g.playersTurn].card1 != null && g.players[g.playersTurn].card1.value == 5) { g.players[g.playersTurn].card1 = null; }
            else { g.players[g.playersTurn].card2 = null; }

            return "";
        }
    }
}
