using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveLetter
{
    public class Baron : Card
    {
        public Baron(int val, Game g2) { value = val; g = g2; }

        override public string act()
        {
            if (g.players[g.playersTurn].card1.value == 3) { g.players[g.playersTurn].card1 = null; }
            else { g.players[g.playersTurn].card2 = null; }
            g.setToCard1();

            int maxval;
            String output = "Player " + g.playersTurn + " played a Baron against Player " + parameters[0] + ".";
            if (g.players[g.playersTurn].card1 != null) { maxval = g.players[g.playersTurn].card1.value; }
            else { maxval = g.players[g.playersTurn].card2.value; }
            Console.WriteLine(g.players[parameters[0]].ToString());
            if (g.playersTurn == parameters[0]) { output = ("Baron was thrown away."); }
            else if (g.players[parameters[0]].card1 != null && g.players[parameters[0]].card1.value == maxval)
            {
                output += " It was a tie!";
            }
            else if (g.players[parameters[0]].card1 != null && g.players[parameters[0]].card1.value > maxval)
            {
                output += " Player " + parameters[0] + " beat Player " + g.playersTurn + "'s " + numToCard(maxval) + " with a " + numToCard(g.players[parameters[0]].card1.value) + ".";

                g.players[g.playersTurn].lost = true;
                g.players[g.playersTurn].card1 = null;
                g.players[g.playersTurn].card2 = null;
            }
            else if (g.players[parameters[0]].card1 != null && g.players[parameters[0]].card1.value < maxval)
            {
                output += " Player " + g.playersTurn + " beat Player " + parameters[0] + "'s " + numToCard(g.players[parameters[0]].card1.value) + " with a " + numToCard(maxval);

                g.players[parameters[0]].lost = true;
                g.players[parameters[0]].card1 = null;
                g.players[parameters[0]].card2 = null;
            }
            else
            {
                Console.WriteLine("NOT LESS GREATER OR EQUAL TO!!!!");
            }
            return output;

        }
    }
}
