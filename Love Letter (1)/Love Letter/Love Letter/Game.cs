using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveLetter
{
    public class Game
    {
        public Random r = new Random();
        public int numPlayers = 4;
        public Stack<Card> deck;
        public List<Player> players;
        public int playersTurn = 0;
        public Game() { resetGame(); }
       
        
        
        //reset whole game
        public void resetGame()
        {
            //for (int i = 0; i < numPlayers; i++) { players[i].score = 0; }
            resetHands();
            players = new List<Player>();
            for (int i = 0; i < numPlayers; i++) { players.Add(new Player(this)); }
        }
       
        
        
        //new round
        public void resetHands()
        {
            deck = new Stack<Card>();

            deck.Push(new Guard(1, this));
            deck.Push(new Guard(1, this));
            deck.Push(new Guard(1, this));
            deck.Push(new Guard(1, this));
            deck.Push(new Guard(1, this));

            deck.Push(new Priest(2, this));
            deck.Push(new Priest(2, this));

            deck.Push(new Baron(3, this));
            deck.Push(new Baron(3, this));

            deck.Push(new Handmaiden(4, this));
            deck.Push(new Handmaiden(4, this));

            deck.Push(new Prince(5, this));
            deck.Push(new Prince(5, this));

            deck.Push(new King(6, this));
            deck.Push(new Countess(7, this));
            deck.Push(new Princess(8, this));

            List<Card> shuffle = deck.ToList();
            r = new Random();
            for (int n = shuffle.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                Card temp = shuffle[n];
                shuffle[n] = shuffle[k];
                shuffle[k] = temp;
            }
            for (int i = 0; i < shuffle.Count; i++)
            {
                Console.WriteLine(shuffle[i]);
            }
            Console.WriteLine(shuffle);
            //while (deck != null) { deck.Pop(); }
            deck.Clear();
            for (int i = 0; i < shuffle.Count; i++)
            {
                Console.WriteLine(shuffle[i] + " _ ");
                deck.Push(shuffle[i]);
            }


        }
        
        
        public void dealCards()
        {
            Console.WriteLine(deck.Count());
            for (int i = 0; i < numPlayers; i++)
            {
                players[i].card1 = null;
                players[i].card2 = null;
                players[i].addCard(deck.Pop());
            }
        }
        public void drawCard(Player p)
        {
            if (deck.Count != 0)
            {
                p.addCard(deck.Pop());
            }
        }
        public void drawCard()
        {
            if (deck.Count == 0) { }
            else
            {
                players[playersTurn].addCard(deck.Pop());
            }
        }
        public string doPlayerTurn()
        {
            //drawCard();
            string output = players[playersTurn].playCard();

            playersTurn++;
            playersTurn %= numPlayers;
            setToCard1();
            while (players[playersTurn].lost == true) { playersTurn++; playersTurn %= numPlayers; }
            return output;
        }
        public void setToCard1()
        {
            for (int i = 0; i < numPlayers; i++)
            {
                if (players[i].card1 == null)
                {
                    players[i].card1 = players[i].card2; players[i].card2 = null;
                }
            }
        }

    }
}
