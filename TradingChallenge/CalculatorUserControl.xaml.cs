using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TradingChallenge
{
    /// <summary>
    /// Interaction logic for CalculatorUserControl.xaml
    /// </summary>
    public partial class CalculatorUserControl : UserControl
    {
        private int _firstNumber;
        private string _operation = string.Empty;
        public CalculatorUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();

            if (int.TryParse(content, out int number))
            {
                TextBox.Text += content;
            }
        }

        private void ButtonOperation_Click(object sender, RoutedEventArgs e)
        {
            _operation = (sender as Button).Content.ToString();
            //I know I should implement a check to see if the first number starts with one or several zeros.
            _firstNumber = int.Parse(TextBox.Text);
            TextBox.Text = string.Empty;
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            _operation = string.Empty;
            _firstNumber = 0;
            TextBox.Text = string.Empty;
        }

        private void Button_Calculate(object sender, RoutedEventArgs e)
        {
            if (_operation == string.Empty)
            {
                return;
            }

            int result = 0;
            int secondNumber = int.Parse(TextBox.Text);

            if (_operation.Equals("+"))
            {
                result = _firstNumber + secondNumber;
            }

            if (_operation.Equals("-"))
            {
                result = _firstNumber - secondNumber;
            }

            if (_operation.Equals("∗"))
            {
                result = _firstNumber * secondNumber;
            }

            if (_operation.Equals("/"))
            {
                result = _firstNumber / secondNumber;
            }

            TextBox.Text = result.ToString();
        }


        private void ButtonFib_Click(object sender, RoutedEventArgs e)
        {
            var result = FibonacciCalculate(int.Parse(TextBox.Text));

            TextBox.Text = result.ToString();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            string actualdata = string.Empty;
            char[] entereddata = TextBox.Text.ToCharArray();
            foreach (char aChar in entereddata.AsEnumerable())
            {
                if (Char.IsDigit(aChar))
                {
                    actualdata = actualdata + aChar;
                }
                else
                {
                    actualdata.Replace(aChar, ' ');
                    actualdata.Trim();
                }
            }
            TextBox.Text = actualdata;
        }

        private static ulong FibonacciCalculate(int n)
        {
            const int ionMarketsExpectationAdjustment = 1;
            n -= ionMarketsExpectationAdjustment;

            double sqrt5 = Math.Sqrt(5);
            double p1 = (1 + sqrt5) / 2;
            double p2 = -1 * (p1 - 1);


            double n1 = Math.Pow(p1, n + 1);
            double n2 = Math.Pow(p2, n + 1);
            return (ulong)((n1 - n2) / sqrt5);
        }

    }
}
