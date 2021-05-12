using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoveLetter
{
    public class Player
    {
        public Game g;

        public List<int> unPlayed = new List<int>();

        public int[,] playerData;

        //public int num = 0;
        public Card choiceCard;
        //public int numplayers = 4;
        //public bool m_KnowCard;
        //public int PlayerNumber;

        public bool lost = false;
        public bool handmaided = false;
        public Card card1;
        public bool knowCard = false;
        public int[] knownCard;
        public int[] knownPrincess;
        public bool knowPrincess = false;
        public Card card2;

        List<CardInfo> cardKnowledge;

        public int score;
        struct CardInfo
        {
            int player;
            int value;
        }
        public Player(Game g2)
        {
            g = g2;
            cardKnowledge = new List<CardInfo>();

        }
        public void addCard(Card card)
        {
            if (card1 == null) { card1 = card; }
            else { card2 = card; }


        }
        public int findCard()
        {

            bool knowCard = false;
            //Princess forced moves
            if (card1.value == 8)
            {
                //Play card 2
                choiceCard = card2;
                return 2;
            }
            else if (card2.value == 8)
            {
                //Play card 1
                choiceCard = card1;
                return 1;
            }

            //Countess forced moves
            else if (card1.value == 7 && card2.value >= 5)
            {
                //Play card 1
                choiceCard = card1;
                return 1;
            }
            else if (card2.value == 7 && card1.value >= 5)
            {
                //Play card 2
                choiceCard = card2;
                return 2;
            }

            //Try to avoid playing King
            else if (card1.value == 6)
            {
                //Play card 2
                choiceCard = card2;
                return 2;
            }
            else if (card2.value == 6)
            {
                //Play card 1
                choiceCard = card1;
                return 1;
            }

            //Double card forced moves
            else if (card1.value == card2.value)
            {
                //Play card 1
                choiceCard = card2;
                return 2;
            }

            //Baron + Guard "forced moves"
            else if (card1.value == 3 && card2.value == 1)
            {
                //Play card 2
                choiceCard = card2;
                return 2;
            }
            else if (card2.value == 3 && card1.value == 1)
            {
                //Play card 1
                choiceCard = card1;
                return 1;
            }

            //Have a guard and know someone's card
            else if (card1.value == 1 && knowCard)
            {
                //Play card 1
                choiceCard = card1;
                return 1;
            }
            else if (card2.value == 1 && knowCard)
            {
                //Play card 2
                choiceCard = card2;
                return 2;
            }

            
            else if (card1.value == 4)
            {
                //Play card 1
                choiceCard = card1;
                return 1;
            }
            else if (card2.value == 4)
            {
                //Play card 2
                choiceCard = card2;
                return 2;
            }

            //Play prince if know princess
            else if (card1.value == 5 && knowPrincess)
            {
                //Play card 1
                choiceCard = card1;
                return 1;
            }
            else if (card2.value == 5 && knowPrincess)
            {
                //Play card 2
                choiceCard = card2;
                return 2;
            }

            //Play baron with a card of 5 or higher
            else if (card1.value == 3 && card2.value >= 5)
            {
                //Play card 1
                choiceCard = card1;
                return 1;
            }
            else if (card2.value == 3 && card1.value >= 5)
            {
                //Play card 2
                choiceCard = card2;
                return 2;
            }

            //Play priest in remaining cases
            else if (card1.value == 2)
            {
                //Play card 1
                choiceCard = card1;
                return 1;
            }
            else if (card2.value == 2)
            {
                //Play card 2
                choiceCard = card2;
                return 2;
            }

            //Play guard in remaining cases
            else if (card1.value == 1)
            {
                //Play card 1
                choiceCard = card1;
                return 1;
            }
            else if (card2.value == 1)
            {
                //Play card 2
                choiceCard = card2;
                return 2;
            }

            else
            {
                //This shouldn't happen, but just in case.
                Console.WriteLine("Decision tree failed, playing card 1");
                choiceCard = card1;
                return 1;
            }

        }
        public int numInstances(List<int> lis, int num)
        {
            int count = 0;
            foreach (int c in lis)
            {
                if (c == num) { count++; }
            }
            return count;
        }
        bool ingame(int playercount)
        {
            if (g.players[playercount].lost == false)
            {
                return (true);


            }
            else
            {
                return (false);
            }
        }
        public string playCard()
        {
            List<Card> iterate = g.deck.ToList();

            for (int i = 0; i < g.deck.Count(); i++) { unPlayed.Add(iterate[i].value); }
            for (int i = 0; i < g.numPlayers; i++)
            {
                if (g.playersTurn != i && g.players[i].lost == false) { unPlayed.Add(g.players[i].card1.value); }
            }
            double[] probability = new double[8];
            for (int i = 0; i < 8; i++) { Console.WriteLine(numInstances(unPlayed, i + 1) + " ____"); probability[i] = numInstances(unPlayed, i + 1) / unPlayed.Count; Console.WriteLine(probability[i]); }

            int[] param = new int[2];
            handmaided = false;
            //drawCard();
            
            int selectedCard = findCard();

            int cardValue = 0;
            if (1 == selectedCard)
            {
                cardValue = g.players[g.playersTurn].card1.value;
            }
            else
            {
                cardValue = g.players[g.playersTurn].card2.value;
            }
            switch (cardValue)
            {
                case 1:
                    double probabilityMax = -1;
                    int index = -1;
                    for (int i = 0; i < 8; i++)
                    {
                        if (probability[i] > probabilityMax) { index = i; }
                    }
                    param[1] = new Random().Next(2, 9); //index + 1;
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;

            }


            param[0] = (g.playersTurn + 1) % 4;
            bool targSelf = true;
            for (int i = 0; i < g.numPlayers; i++)
            {
                if (i != g.playersTurn)
                {
                    if (g.players[i].handmaided == true || g.players[i].lost == true) { }
                    else { targSelf = false; }
                }
            }


            if (targSelf) { param[0] = g.playersTurn; }
            else
            {
                while ((g.players[param[0]].lost == true && param[0] != g.playersTurn) || (g.players[param[0]].handmaided == true)) { param[0] = (param[0] + 1) % 4; }
            }
            

            if (selectedCard == 1)
            {
                card1.parameters = param;
                return card1.act();
            }
            else
            {
                card2.parameters = param;
                return card2.act();
            }

        }
    }
}
