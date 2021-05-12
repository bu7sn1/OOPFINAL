using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveLetter
{
    public class Guard : Card
    {
        public Guard(int val, Game g2) { value = val; g = g2; }

        override public string act()
        {
            g.setToCard1();
            String output = "Player " + g.playersTurn + " guessed that Player " + parameters[0] + " has a " + numToCard(parameters[1]) + ".";
            if (parameters[0] != g.playersTurn && g.players[parameters[0]].card1 != null && g.players[parameters[0]].card1.value == parameters[1])
            {
                g.players[parameters[0]].card1 = null;
                g.players[parameters[0]].card2 = null;
                g.players[parameters[0]].lost = true;
                output += " Player " + g.playersTurn + " was correct! Player " + parameters[0] + " is eliminated.";

            }
            else if (parameters[0] != g.playersTurn && g.players[parameters[0]].card2 != null && g.players[parameters[0]].card2.value == parameters[1])
            {
                g.players[parameters[0]].lost = true;
                g.players[parameters[0]].card1 = null;
                g.players[parameters[0]].card2 = null;
                output += " Player " + g.playersTurn + " was correct! Player " + parameters[0] + " is eliminated.";
            }
            else if (parameters[0] == g.playersTurn) { output = "Player " + g.playersTurn + " threw the guard away."; }
            else
            {
                output += " Player " + g.playersTurn + " was wrong with the Guard guess against Player " + parameters[0] + "!";
            }
            
            if (g.players[g.playersTurn].card1 != null && g.players[g.playersTurn].card1.value == 1) { g.players[g.playersTurn].card1 = null; }
            else { g.players[g.playersTurn].card2 = null; }

            return output;
        }
    }
}
