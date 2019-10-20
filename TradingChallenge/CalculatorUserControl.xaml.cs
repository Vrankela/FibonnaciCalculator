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
        private void AddOperation()
        {
            throw new NotImplementedException();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //TODO
        }
    }
}
