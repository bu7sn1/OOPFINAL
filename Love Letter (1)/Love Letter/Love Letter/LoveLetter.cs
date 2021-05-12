using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoveLetter
{
    public partial class LoveLetter : Form
    {
        Game g;
        

        public LoveLetter()
        {
            InitializeComponent();
            this.button2.Enabled = false;
            this.button3.Enabled = false;
        }

        public void setNotification(String notification)
        {
            this.notif.Text = notification;
        }

        private void printDeck()
        {
            String s = "";
            List<Card> l = g.deck.ToList();
            for (int i = 0; i < l.Count; i++) { s += l[i] + "\n"; }
            label9.Text = s + " \n Total Cards: " + g.deck.Count();
        }
        private void printHands()
        {
            //String s = myObj == null ? "" : myObj.ToString();

            label1.Text = g.players[0].card1 == null ? "empty" : g.players[0].card1.ToString();
            label2.Text = g.players[0].card2 == null ? "empty" : g.players[0].card2.ToString();

            label3.Text = g.players[1].card1 == null ? "empty" : g.players[1].card1.ToString();
            label4.Text = g.players[1].card2 == null ? "empty" : g.players[1].card2.ToString();

            label5.Text = g.players[2].card1 == null ? "empty" : g.players[2].card1.ToString();
            label6.Text = g.players[2].card2 == null ? "empty" : g.players[2].card2.ToString();

            label7.Text = g.players[3].card1 == null ? "empty" : g.players[3].card1.ToString();
            label8.Text = g.players[3].card2 == null ? "empty" : g.players[3].card2.ToString();

        }
        private void initializeBtn(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            g = new Game();
            g.dealCards();
            printDeck();
            printHands();
            this.button2.Enabled = true;
            this.button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            //g.dealCards();
            g.drawCard(); // doPlayerTurn();
            printDeck();
            printHands();
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            int numOut = 0;
            for (int i = 0; i < g.numPlayers; i++) { if (g.players[i].lost == true) { numOut++; } }
            if (numOut >= 3)
            {
                for (int i = 0; i < g.numPlayers; i++) { if (g.players[i].lost == false) { g.players[i].score++; } }
                g.resetHands();
            }
            this.notif.Text = g.doPlayerTurn();
            printDeck();
            printHands();
            button3.Enabled = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void notif_Click(object sender, EventArgs e)
        {

        }
    }
}

