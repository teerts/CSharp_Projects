using System;
using System.Windows.Forms;

namespace CalculatorApp
{    
    public partial class Form1 : Form
    {
        string input = string.Empty;
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        char operation;
        double result = 0.0; 

        public Form1()
        {
            InitializeComponent();
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            this.valueDisplayTextBox.Text = "";
            input += "0";
            this.valueDisplayTextBox.Text += input;
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            this.valueDisplayTextBox.Text = "";
            input += ".";
            this.valueDisplayTextBox.Text += input;
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            this.valueDisplayTextBox.Text = "";
            input += "3";
            this.valueDisplayTextBox.Text += input;
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            this.valueDisplayTextBox.Text = "";
            input += "7";
            this.valueDisplayTextBox.Text += input;
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            this.valueDisplayTextBox.Text = "";
            input += "8";
            this.valueDisplayTextBox.Text += input;
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            this.valueDisplayTextBox.Text = "";
            input += "9";
            this.valueDisplayTextBox.Text += input;
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            this.valueDisplayTextBox.Text = "";
            input += "4";
            this.valueDisplayTextBox.Text += input;
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            this.valueDisplayTextBox.Text = "";
            input += "5";
            this.valueDisplayTextBox.Text += input;
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            this.valueDisplayTextBox.Text = "";
            input += "6";
            this.valueDisplayTextBox.Text += input;
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            this.valueDisplayTextBox.Text = "";
            input += "1";
            this.valueDisplayTextBox.Text += input;
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            this.valueDisplayTextBox.Text = "";
            input += "2";
            this.valueDisplayTextBox.Text += input;
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            operand1 = input;
            operation = '/';
            input = string.Empty;
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            operand1 = input;
            operation = '*';
            input = string.Empty;
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            operand1 = input;
            operation = '+';
            input = string.Empty;
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            operand1 = input;
            operation = '-';
            input = string.Empty;
        }

        private void clearEntryButton_Click(object sender, EventArgs e)
        {
            this.valueDisplayTextBox.Text = "";
            this.input = string.Empty;
            this.operand1 = string.Empty;
            this.operand2 = string.Empty; 
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            operand2 = input;
            double num1, num2;
            double.TryParse(operand1, out num1);
            double.TryParse(operand2, out num2);

            this.valueDisplayTextBox.Text = "";
            this.input = string.Empty;
            this.operand1 = string.Empty;
            this.operand2 = string.Empty; 

            if (operation == '+')
            {
                result = num1 + num2;
                valueDisplayTextBox.Text = result.ToString();
            }
            else if (operation == '-')
            {
                result = num1 - num2;
                valueDisplayTextBox.Text = result.ToString();
            }
            else if (operation == '*')
            {
                result = num1 * num2;
                valueDisplayTextBox.Text = result.ToString();
            }
            else if (operation == '/')
            {
                if (num2 != 0)
                {
                    result = num1 / num2;
                    valueDisplayTextBox.Text = result.ToString();
                }
                else
                {
                    valueDisplayTextBox.Text = "DIV/Zero";
                }
            }
        }


    }
}
