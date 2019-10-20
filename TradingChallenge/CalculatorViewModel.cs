using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingChallenge
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private int textBox;

        public int TextBox
        {
            get { return textBox; }
            set
            {
                textBox = value;
                RaisePropertyChanged("TextBox");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
