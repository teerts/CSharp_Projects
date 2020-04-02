using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class Form1 : Form
    {
        Player currentPlayer;
        List<Button> buttons;
        Random rand = new Random();
        int playerWins = 0;
        int computerWins = 0;

        // Enumeration for player class (AI/HUMAN): X / O
        public enum Player
        {
            X, O
        }
        public Form1()
        {
            InitializeComponent();
            resetGame();
        }
        private void playerclick(object sender, EventArgs e)
        {
            var button = (Button)sender; // find the button that was clicked
            currentPlayer = Player.X; // set player to X from enum class
            button.Text = currentPlayer.ToString(); // change button text to X
            button.Enabled = false; // disable the button that was clicked
            button.BackColor = System.Drawing.Color.Cyan; // set player colour
            buttons.Remove(button); // remove the button from the list, so AI cannot use it
            DeclareWinnerAndReset(currentPlayer); // check if player has won the game
            AImoves.Start(); // start the timer for AI's move
        }

        private void AImove(object sender, EventArgs e)
        {
            int index = 0;
            bool isEmpty = buttons.Any();
            
            if (isEmpty)
            {
                index = rand.Next(buttons.Count); // RNG: next button selected
                buttons[index].Enabled = false; // assign RNG number to button
                currentPlayer = Player.O; // set AI to 'O' from player enum
                buttons[index].Text = currentPlayer.ToString(); // display 'O' on the button
                buttons[index].BackColor = System.Drawing.Color.DarkSalmon; // set color of bg
                buttons.RemoveAt(index); // remove button from selectable list                
            }
            DeclareWinnerAndReset(currentPlayer); // check if winner yet
            AImoves.Stop(); // stop the timer                
        }

       private void restartGame(object sender, EventArgs e)
       {
           // function is linked to reset button 
           resetGame();
       }

       private void loadbuttons()
       {
           // load all buttons into a List
           buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8 };
       }

       private void resetGame()
       {
           foreach (Control X in this.Controls)
           {
               // using the Tag defined in the form init all to True/?/Default Color
               if (X is Button && (string)X.Tag == "play")
               {
                   ((Button)X).Enabled = true;
                   ((Button)X).Text = "?";
                   ((Button)X).BackColor = default(Color);
               }
           }
           // insert all buttons into List array
           loadbuttons();
       }

        private bool CheckForWin(string playerIdentifier)
        {

            bool isFirstRowChecked = button1.Text == playerIdentifier && button2.Text == playerIdentifier && button3.Text == playerIdentifier;
            bool isMiddleRowChecked = button4.Text == playerIdentifier && button5.Text == playerIdentifier && button6.Text == playerIdentifier;
            bool isLastRowChecked = button7.Text == playerIdentifier && button8.Text == playerIdentifier && button9.Text == playerIdentifier;
            bool isFirstColumnChecked = button1.Text == playerIdentifier && button4.Text == playerIdentifier && button7.Text == playerIdentifier;
            bool isMiddleColumnChecked = button2.Text == playerIdentifier && button5.Text == playerIdentifier && button8.Text == playerIdentifier;
            bool isLastColumnChecked = button3.Text == playerIdentifier && button6.Text == playerIdentifier && button9.Text == playerIdentifier;
            bool isDiagonalTopToBottomChecked = button1.Text == playerIdentifier && button5.Text == playerIdentifier && button9.Text == playerIdentifier;
            bool isDiagonalBottomToTopChecked = button3.Text == playerIdentifier && button5.Text == playerIdentifier && button7.Text == playerIdentifier;

            List<bool> isWinnerCheckList = new List<bool>();

            //add all the bools to list
            isWinnerCheckList.Add(isFirstRowChecked);
            isWinnerCheckList.Add(isMiddleRowChecked);
            isWinnerCheckList.Add(isLastRowChecked);
            isWinnerCheckList.Add(isFirstColumnChecked);
            isWinnerCheckList.Add(isMiddleColumnChecked);
            isWinnerCheckList.Add(isLastColumnChecked);
            isWinnerCheckList.Add(isDiagonalTopToBottomChecked);
            isWinnerCheckList.Add(isDiagonalBottomToTopChecked);

            //loop though list and find the truth
            foreach (bool item in isWinnerCheckList)
            {
                if (item == true)
                {
                    return true;
                }
            }
            return false;
        }
        // check if the player or AI won 
       // multiple large IF statements with winning possibilities
       private void DeclareWinnerAndReset(Enum player)
       {
           string playerIdentifier = player.ToString();
          
            
           if ((String.Equals(playerIdentifier, "X")) && (CheckForWin(playerIdentifier)))
            {
                AImoves.Stop();
                MessageBox.Show("Player Wins");
                playerWins++;
                label1.Text = "Player Wins - " + playerWins;
                resetGame();
            }
           else if ((String.Equals(playerIdentifier, "O")) && (CheckForWin(playerIdentifier)))
            {
                AImoves.Stop();
                MessageBox.Show("Computer Wins");
                computerWins++;
                label2.Text = "AI Wins - " + computerWins;
                resetGame();
            }
        }
    }
}
