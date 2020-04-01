using System;
using System.Collections.Generic;
using System.Drawing;
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
            Check(currentPlayer.ToString()); // check if player has won the game
            AImoves.Start(); // start the timer for AI's move
        }

        private void AImove(object sender, EventArgs e)
       {
           if (buttons.Count >= 0)
           {
               int index = rand.Next(buttons.Count); // RNG: next button selected
               if (buttons.Count == 0)
                {
                    buttons[index].Enabled = false; // assign RNG number to button
                }  
               currentPlayer = Player.O; // set AI to 'O' from player enum
               buttons[index].Text = currentPlayer.ToString(); // display 'O' on the button
               buttons[index].BackColor = System.Drawing.Color.DarkSalmon; // set color of bg
               buttons.RemoveAt(index); // remove button from selectable list
               Check(currentPlayer.ToString()); // check if winner yet
               AImoves.Stop(); // stop the timer                
           }
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

       // check if the player or AI won 
       // multiple large IF statements with winning possibilities
       private void Check(string playerIdentifier)
       {         
           bool isFirstRowChecked = button1.Text == playerIdentifier && button2.Text == playerIdentifier && button3.Text == playerIdentifier;
           bool isMiddleRowChecked = button4.Text == playerIdentifier && button5.Text == playerIdentifier && button6.Text == playerIdentifier;
           bool isLastRowChecked = button7.Text == playerIdentifier && button8.Text == playerIdentifier && button9.Text == playerIdentifier;
           bool isFirstColumnChecked = button1.Text == playerIdentifier && button4.Text == playerIdentifier && button7.Text == playerIdentifier;
           bool isMiddleColumnChecked = button2.Text == playerIdentifier && button5.Text == playerIdentifier && button8.Text == playerIdentifier;
           bool isLastColumnChecked = button3.Text == playerIdentifier && button6.Text == playerIdentifier && button9.Text == playerIdentifier;
           bool isDiagonalTopToBottomChecked = button1.Text == playerIdentifier && button5.Text == playerIdentifier && button9.Text == playerIdentifier;
           bool isDiagonalBottomToTopChecked = button3.Text == playerIdentifier && button5.Text == playerIdentifier && button7.Text == playerIdentifier;
            
           if ((String.Equals(playerIdentifier, "X")) && (isFirstRowChecked || isMiddleRowChecked || isLastRowChecked || isFirstColumnChecked || isMiddleColumnChecked || isLastColumnChecked || isDiagonalTopToBottomChecked || isDiagonalBottomToTopChecked))
            {
                AImoves.Stop();
                MessageBox.Show("Player Wins");
                playerWins++;
                label1.Text = "Player Wins - " + playerWins;
                resetGame();
            }
           else if ((String.Equals(playerIdentifier, "O")) && (isFirstRowChecked || isMiddleRowChecked || isLastRowChecked || isFirstColumnChecked || isMiddleColumnChecked || isLastColumnChecked || isDiagonalTopToBottomChecked || isDiagonalBottomToTopChecked))
            {
                AImoves.Stop();
                MessageBox.Show("Computer Wins");
                computerWins++;
                label2.Text = "AI Wins - " + computerWins;
                resetGame();
            }
            // refactored code above; old commented code below
            /* 1st 
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X") 
            {
                // if any statements above are true
                AImoves.Stop();
                MessageBox.Show("Player Wins");
                playerWins++;
                label1.Text = "Player Wins - " + playerWins;
                resetGame();
            } 
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
               || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
               || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
               || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
               || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
               || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
               || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
               || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
           {
               AImoves.Stop();
               MessageBox.Show("Computer Wins");
               computerWins++;
               label2.Text = "AI Wins - " + computerWins;
               resetGame();
            }*/
        }
    }
}
