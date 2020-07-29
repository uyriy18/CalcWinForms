using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shapes
{
    public partial class Calculator : Form
    {
        string operationPerformed = "";
        Double resultValue = 0;
        Double percentResultValue = 0;
        bool isOperationPerformrd = false;
        public Calculator()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((textBoxResult.Text == "0") || (isOperationPerformrd))
                textBoxResult.Clear();
            isOperationPerformrd = false;
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                textBoxResult.Text += e.KeyChar.ToString();
            }
            if(e.KeyChar == 43)
            {
                buttonPlus.PerformClick();
            }
            if (e.KeyChar == 45)
            {
                buttonMinus.PerformClick();
            }
            if (e.KeyChar == 42)
            {
                buttonMultiplie.PerformClick();
            }
            if (e.KeyChar == 47)
            {
                buttonDivision.PerformClick();
            }
            if(e.KeyChar == (char)Keys.Enter)
            {
                buttonEqual.PerformClick();
            }
            if(e.KeyChar == (char)Keys.Delete)
            {
                buttonClearEntries.PerformClick();
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                buttonDelete.PerformClick();
            }
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((textBoxResult.Text == "0") || (isOperationPerformrd))
                textBoxResult.Clear();
            isOperationPerformrd = false;
            Button button = (Button)sender;
            if(button.Text == ",")
            {
                if (!textBoxResult.Text.Contains(","))
                {
                    textBoxResult.Text += button.Text;
                }
            }
            else textBoxResult.Text += button.Text;
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(resultValue != 0)
            {
                buttonEqual.PerformClick();
                operationPerformed = button.Text;
                currentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformrd = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Convert.ToDouble(textBoxResult.Text);
                currentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformrd = true;
            }
            percentResultValue = double.Parse(textBoxResult.Text);
        }

        private void operatorClear(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
        }
        private void operatorClearEntry(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            resultValue = 0;
            currentOperation.Text = "";
        }
        private void countResult_click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    textBoxResult.Text = (resultValue + Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "-":
                    textBoxResult.Text = (resultValue - Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "x":
                    textBoxResult.Text = (resultValue * Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "/":
                    textBoxResult.Text = (resultValue / Double.Parse(textBoxResult.Text)).ToString();
                    break;
                default: break;
            }
            resultValue = Double.Parse(textBoxResult.Text);
            operationPerformed = "";
        }

        private void operatorPlusMinus_click(object sender, EventArgs e)
        {
            textBoxResult.Text = (double.Parse(textBoxResult.Text)*(-1)).ToString();
            currentOperation.Text = "";
            resultValue = 0;
        }

        private void operator_sqrt(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            resultValue = double.Parse(textBoxResult.Text);
            textBoxResult.Text = (Math.Sqrt(double.Parse(textBoxResult.Text))).ToString();
            currentOperation.Text = button.Text + resultValue;
            resultValue = 0;
        }

        private void click_pow(object sender, EventArgs e)
        {
            resultValue = double.Parse(textBoxResult.Text);
            textBoxResult.Text = (Math.Pow(double.Parse(textBoxResult.Text), 2)).ToString();
            currentOperation.Text = resultValue + "²";
        }

        private void click_percent(object sender, EventArgs e)
        {
            textBoxResult.Text = (percentResultValue * double.Parse(textBoxResult.Text) / 100).ToString();
            resultValue = double.Parse(textBoxResult.Text);
            currentOperation.Text += " " + textBoxResult.Text;
            if(currentOperation.Text.Contains('+')) textBoxResult.Text = (percentResultValue + resultValue).ToString();
            else if (currentOperation.Text.Contains('-')) textBoxResult.Text = (percentResultValue - resultValue).ToString();
            else if (currentOperation.Text.Contains('*')) textBoxResult.Text = (percentResultValue * resultValue).ToString();
            else if (currentOperation.Text.Contains('/')) textBoxResult.Text = (percentResultValue / resultValue).ToString();
            resultValue = 0;
            percentResultValue = 0;
            operationPerformed = null;
        }

        private void click_decimalDivide(object sender, EventArgs e)
        {
            resultValue = double.Parse(textBoxResult.Text);
            textBoxResult.Text = (1 / resultValue).ToString();
            resultValue = 0;
        }

        private void button_delete(object sender, EventArgs e)
        {
            if (textBoxResult.Text.Length > 0 && textBoxResult.Text != "0")
                textBoxResult.Text = textBoxResult.Text.Remove(textBoxResult.Text.Length - 1);
            else buttonClearEntries.PerformClick();
        }
    }
}
