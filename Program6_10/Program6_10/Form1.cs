using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program6_10
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        string compChoice, myChoice, winner;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getCompChoice();
        }

        private void getCompChoice()
        {
            int n = random.Next(1, 4);
            switch (n)
            {
                case 1:
                    compChoice = "Rock";
                    break;
                case 2:
                    compChoice = "Paper";
                    break;
                case 3:
                    compChoice = "Scissors";
                    break;
            }
        }

        private void showWinner()
        {
            if (myChoice == compChoice)
                winner = "平手!";
            else if (myChoice == "Rock" && compChoice == "Scissors")
                winner = "玩家贏!";
            else if (myChoice == "Paper" && compChoice == "Rock")
                winner = "玩家贏!";
            else if (myChoice == "Scissors" && compChoice == "Paper")
                winner = "玩家贏!";
            else
                winner = "爛!!";

            label1.Text = "玩家選擇: " + myChoice + "\n" +
                          "電腦選擇: " + compChoice + "\n" +
                          winner;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myChoice = "Rock";
            showWinner();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myChoice = "Paper";
            showWinner();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myChoice = "Scissors";
            showWinner();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getCompChoice();
            label1.Text = "";
        }


    }
}
